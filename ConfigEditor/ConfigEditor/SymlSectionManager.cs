using ConfigtEditor.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigtEditor.ConfigEditor
{
    public class SymlSectionManager : FixedListManager<SymlSection>
    {
        public SYML Syml { get; private set; }
        public void LoadSyml(string v)
        {
            Syml = new SYML(v);
            Syml.Load();
            LoadList(Syml.Sections.Keys.ToList().Select(p => new SymlSection(p, Syml.Sections[p].Content)).ToList());

        }

        internal void Save()
        {
            foreach (var element in ElementList)
            {
                Syml.Sections[element.Name].Content = element.GetContentText();
            }
            Syml.Store();
        }

        //Change it for Synapse 3
        private const string emptyPermissionSection = @"[/NAME/]
{
# If Enabled this Group will be assigned to all players, which are in no other Group
default: true
# If Enabled this Group will be assigned to Northwood staff players, which are in no other Group
northwood: false
# If Enabled this Group has Acces to RemoteAdmin
remoteAdmin: false
# The Badge which will be displayed in game
badge: NONE
# The Color which the Badge has in game
color: NONE
# If Enabled The Badge of this Group will be displayed instead of the global Badge
cover: false
# If Enabled the Badge is Hidden by default
hidden: false
# The KickPower the group has
kickPower: 0
# The KickPower which is required to kick the group
requiredKickPower: 1
# The Permissions which the group has
permissions:
- synapse.command.help
- synapse.command.plugins
# Gives the Group the Permissions of all Groups in this List
inheritance: 
# The UserID's of the Players in the Group
members:
}";
        internal void CreateConfigSection(string name)
        {
            if (Syml != null)
            {
                if (!ElementList.Any(p=>p.Name == name))
                {
                    var text = SYML.WriteSections(Syml.Sections);
                    string sectionWithName = emptyPermissionSection.Replace("/NAME/", name);
                    text += sectionWithName;
                    Syml.Sections = SYML.ParseString(text);
                    LoadList(Syml.Sections.Keys.ToList().Select(p => new SymlSection(p, Syml.Sections[p].Content)).ToList());
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("That group name is already here!");
                }
            }
        }
    }
}
