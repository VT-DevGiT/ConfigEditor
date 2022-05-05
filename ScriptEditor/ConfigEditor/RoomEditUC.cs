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
using ScriptEditor.CustomClass;
using ScriptEditor.Interfaces;

namespace ScriptEditor.ConfigEditor
{
    public partial class RoomEditUC : ECSEditUserControl
    {
        public RoomEditUC()
        {
            InitializeComponent();
        }
        public RoomEditUC(IWriteManager room) : base(room)
        {
            InitializeComponent();
            this.Text = "Room";
            this.BindingDataSource.DataSource = room.CurrentObject;
        }
    }
}
