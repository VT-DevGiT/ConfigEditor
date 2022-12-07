﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigtEditor.Interfaces
{
    public interface IWriteManager
    {
        object CurrentObject { get; set; }

        void PrepareNew();
        bool Save();
    }
}
