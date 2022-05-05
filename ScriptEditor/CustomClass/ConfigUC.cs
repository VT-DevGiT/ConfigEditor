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

namespace ScriptEditor.CustomClass
{
    public partial class ConfigUC : ECSUserControl
    {
        public ConfigUC()
        {
            InitializeComponent();
            var manager = new RoomManager();
            var listDetail = new ListControl<Room>(manager);
            listDetail.Register("Add", new ElementNewCommand<Room>(manager), "Add", true, true);
            listDetail.Register("Edit", new ElementEditCommand<Room>(manager), "Edit", true, true, true);
            listDetail.Register("Delete", new ElementDeleteCommand<Room>(manager), "Delete", true, true);
            listDetail.Register("Refresh", new ActionCommand(() => manager.LoadList()), "Refresh", true, true);
            //            listDetail.GridView.Columns.Add(col);
            panelRoom.Fill(listDetail);
        }
    }
}
