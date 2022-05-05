using ScriptEditor.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptEditor.ConfigEditor
{
    public class AddRoomCommand : BaseCommand<SymlContentItem>
    {
        protected override bool CanExecuteValue => base.CanExecuteValue
            && Parameter.IsRoomEdit && !Program.Config.ValideRooms.Contains(Parameter.Value);

        protected override void ExecuteCommand()
        {
            Program.Config.AddRoom(Parameter);
        }
    }
}
