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
using ConfigtEditor.Interfaces;

namespace ConfigtEditor.CustomClass
{
    public partial class CustomSynapseClassEditUC : ECSEditUserControl
    {
        private CustomSynapseClassManager _manager;
        public CustomSynapseClassEditUC() : base()
        {
            InitializeComponent();
        }

        public CustomSynapseClassEditUC(IWriteManager manager) : base(manager)
        {
            InitializeComponent();
            BindingDataSource.DataSource = manager.CurrentObject;
            _manager = manager as CustomSynapseClassManager;
        }

        public override bool BeforeSave()
        {
            if (_manager.CheckIdInvalid())
            {
                _idEdit.ErrorText = "This id is already used!";
                return false;
            }
            return base.BeforeSave();
        }
    }
}
