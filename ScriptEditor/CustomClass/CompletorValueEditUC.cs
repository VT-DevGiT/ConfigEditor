﻿using System;
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
using ConfigtEditor.Managers;

namespace ConfigtEditor.CustomClass
{
    public partial class CompletorValueEditUC : ECSEditUserControl
    {
        private CompletorValueManager _manager;

        public CompletorValueEditUC()
        {
            InitializeComponent();
        }
        public CompletorValueEditUC(IWriteManager manager) : base(manager)
        {
            InitializeComponent();
            BindingDataSource.DataSource = manager.CurrentObject;
            _manager = manager as CompletorValueManager;
        }
    }
}
