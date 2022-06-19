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
using ScriptEditor.Controls;
using ScriptEditor.Utils;
using ScriptEditor.Managers;
using DevExpress.XtraGrid.Columns;
using ScriptEditor.Commands;
using ScriptEditor.ConfigEditor;
using ScriptEditor.Elements;

namespace ScriptEditor.CustomClass
{
    public partial class ConfigUC : ECSUserControl
    {
        public ConfigUC()
        {
            InitializeComponent();
            var managerComp = new CompletorManager();
            var listCompletor = new ListControl<Completor>(managerComp);
            listCompletor.Register("Add", new ElementNewCommand<Completor>(managerComp), "Add", true, true);
            listCompletor.Register("Edit", new ElementEditCommand<Completor>(managerComp), "Edit", true, true, true);
            listCompletor.Register("Delete", new ElementDeleteCommand<Completor>(managerComp), "Delete", true, true);
            //listCompletor.Register("Refresh", new ActionCommand(() => managerComp.LoadList()), "Refresh", true, true);
            listCompletor.GridView.GridControl.ShowOnlyPredefinedDetails = true;
            panelCompletor.Fill(listCompletor);

            var managerValueComp = new CompletorValueManager();
            var listCompletorValue = new ListControl<CompletorValue>(managerValueComp);
            listCompletorValue.Register("Add", new ElementNewCommand<CompletorValue>(managerValueComp), "Add", true, true);
            listCompletorValue.Register("Edit", new ElementEditCommand<CompletorValue>(managerValueComp), "Edit", true, true, true);
            listCompletorValue.Register("Delete", new ElementDeleteCommand<CompletorValue>(managerValueComp), "Delete", true, true);

            panelValues.Fill(listCompletorValue);
            managerValueComp.LoadList(listCompletor.FocusedElement);

            listCompletor.GridView.FocusedRowChanged += (s, e) => managerValueComp.LoadList(listCompletor.FocusedElement);
            /*
            var manager = new RoomManager();
            var listDetail = new ListControl<Room>(manager);
            listDetail.Register("Add", new ElementNewCommand<Room>(manager), "Add", true, true);
            listDetail.Register("Edit", new ElementEditCommand<Room>(manager), "Edit", true, true, true);
            listDetail.Register("Delete", new ElementDeleteCommand<Room>(manager), "Delete", true, true);
            listDetail.Register("Refresh", new ActionCommand(() => manager.LoadList()), "Refresh", true, true);
            //            listDetail.GridView.Columns.Add(col);
            panelValues.Fill(listDetail);
            */
        }
    }
}
