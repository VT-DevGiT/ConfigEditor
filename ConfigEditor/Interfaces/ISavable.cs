using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigEditor.Interfaces
{
    internal interface ISavable
    {
        bool NeedToSave { get; }
        bool CancelClose { get; }
    }
}
