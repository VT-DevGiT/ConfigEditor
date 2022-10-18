using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ConfigtEditor.Controls;
using ConfigtEditor.Utils;
using ConfigtEditor.Managers;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using ConfigtEditor.Commands;
using ConfigtEditor.Interfaces;
using ConfigtEditor.Elements;

namespace ConfigtEditor.ConfigEditor
{
    public partial class SynapseConfigEditorUC : ECSBarUserControl, IMultipleDisplay
    {
        #region Nested
        private class DelSectionCommand : BaseCommand<SymlSection>
        {
            #region Attributes & Properties
            protected override bool CanExecuteValue => Parameter != null && Parameter.Name != "Server";
            private SymlSectionManager _manager;


            #endregion

            #region Constructors & Destructor
            public DelSectionCommand(SymlSectionManager manager)
            {
                _manager = manager;
            }

            #endregion

            #region Methods
            protected override void ExecuteCommand()
            {
                _manager.Delete(Parameter);
            }
            #endregion

        }
        private class AddSectionCommand : BaseCommand
        {
            #region Attributes & Properties
            protected override bool CanExecuteValue => true;
            private SymlSectionManager _manager;


            #endregion

            #region Constructors & Destructor
            public AddSectionCommand(SymlSectionManager manager)
            {
                _manager = manager;
            }

            #endregion

            #region Methods
            protected override void ExecuteCommand()
            {
                string name = XtraInputBox.Show("Group name", "Section Name", "NewGroup");

                if (name == String.Empty)
                    return;

                _manager.CreateConfigSection(name);
            }
            #endregion

        }
        #endregion

        private static int NextHash = 0;
        private int hash = -1;

        public override int GetHashCode()
        {
            if (hash == -1)
            {
                hash = NextHash;
                NextHash++;
            }
            return hash;
        }

        private LoadConfigCommand loadCommand;
        private SaveConfigCommand saveCommand;
        private AddListItemCommand addItemCommand;
        private DeleteListItemCommand deleteItemCommand;
        private SymlSectionManager _managerSection = new SymlSectionManager();
        private SymlDetailManager _managerDetail = new SymlDetailManager();
        private ListControl<SymlSection> _listSection;
        private ListControl<SymlContentItem> _listDetail;

        public SynapseConfigEditorUC(bool permission = false)
        {
            InitializeComponent();
            InitListControl();
            InitCommands();
            if (permission)
            {
                AddPermissionCommand();
            }

        }

        private void AddPermissionCommand()
        {
            var addSectionCommand = new AddSectionCommand(_managerSection);
            var delSectionCommand = new DelSectionCommand(_managerSection);
            _listSection.Register("Add", addSectionCommand, "Add Section", true, true, shortcut: new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            _listSection.Register("Del", delSectionCommand, "Del Section", true, true, shortcut: new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
        }

        private void InitListControl()
        {
            _listDetail = new ListControl<SymlContentItem>(_managerDetail);
            _listDetail.GridView.OptionsView.RowAutoHeight = true;
            _panelDetail.Fill(_listDetail);
            addItemCommand = new AddListItemCommand(_managerDetail);
            _listDetail.Register("Add", addItemCommand, "Add", true, true, shortcut: new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            _listDetail.GridView.ShowingEditor += CustomShowEditor;
            _listDetail.GridView.CustomRowCellEdit += CustomRowCellEdit;
            foreach (GridColumn col in _listDetail.GridView.Columns)
            {
                if (col.FieldName != nameof(SymlContentItem.Value) && col.FieldName != nameof(SymlContentItem.Action))
                {
                    col.OptionsColumn.ReadOnly = true;
                    col.OptionsColumn.AllowEdit = false;

                }
            }
            //_listDetail.GridView.Columns[nameof(SymlContentItem.Name)].OptionsColumn.ReadOnly = true;
            //_listDetail.GridView.Columns[nameof(SymlContentItem.Name)].OptionsColumn.AllowEdit = false;
            _listDetail.GridView.SetFontColorFor<SymlContentItem>(nameof(SymlContentItem.Name), GetErrorColor);
            _listDetail.GridView.OptionsBehavior.ReadOnly = false;
            _listDetail.GridView.OptionsBehavior.Editable = true;
            _listDetail.GridView.OptionsCustomization.AllowFilter = false;
            _listDetail.GridView.OptionsCustomization.AllowSort = false;
            _listDetail.GridView.OptionsCustomization.AllowGroup = false;

            deleteItemCommand = new DeleteListItemCommand(_managerDetail);
            _listDetail.Register("Del", deleteItemCommand, "Del", true, true, shortcut: new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));

            _listSection = new ListControl<SymlSection>(_managerSection);
            _panelConfig.Fill(_listSection);
            _listSection.GridView.FocusedRowChanged += gridSection_FocusedRowChanged;


        }

        private Color? GetErrorColor(SymlContentItem elem)
        {
            return elem.SpaceError ? Color.Red : (Color?)null;
        }

        private void InitCommands()
        {
            loadCommand = new LoadConfigCommand(_managerSection);
            loadCommand.AfterExecute += (s, e) => saveCommand.OnCanExecuteChanged();
            saveCommand = new SaveConfigCommand(_managerSection);
            saveCommand.AfterExecute += (s, e) => MessageBox.Show("Config was saved");
            this.Register("Load", loadCommand, "Load", new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.Register("Save", saveCommand, "Save", new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
        }

        private void gridSection_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var item = _listSection.FocusedElement;
            if (item != null)
            {
                _managerDetail.LoadContent(item);
            }
        }

        #region Events
        private void CustomShowEditor(object sender, CancelEventArgs e)
        {
            SymlContentItem line = _listDetail.GridView.GetRow(_listDetail.GridView.FocusedRowHandle) as SymlContentItem;
            e.Cancel = true;
            switch (_listDetail.GridView.FocusedColumn.FieldName)
            {
                case nameof(SymlContentItem.Value):
                    e.Cancel = line.IsList || line.IsComment || String.IsNullOrWhiteSpace(line.Name);
                    break;
                case nameof(SymlContentItem.Action):
                    e.Cancel = line.GetCompletor == null;
                    break;
            } 
        }

        private void CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            var item = _listDetail.GridView.GetRow(e.RowHandle) as SymlContentItem;
            if (item != null && e.Column.FieldName == nameof(SymlContentItem.Value) && !item.IsList && !item.IsComment)
            {
                var completor = item.GetCompletor;

                /*
                 * TODO list :
                 * Edition des section de permition
                 * Fix le systeme de save car ne fonctione pas
                 * Message quand on quitte
                 * 
                 */

                if (completor != null)
                {
                    RepositoryItemComboBox comb = new RepositoryItemComboBox();
                    completor.ListValues.ForEach(p => comb.Items.Add(p));
                    e.RepositoryItem = comb;
                }
                else
                {
                    if (item.IsMultiLine)
                    {
                        var editor = new RepositoryItemMemoEdit();
                        e.RepositoryItem = editor;
                    }
                    else
                    {
                        var btn = new RepositoryItemTextEdit();
                        btn.ValidateOnEnterKey = true;
                        e.RepositoryItem = btn;
                    }
                }
            }
         }
        #endregion

    }
}
