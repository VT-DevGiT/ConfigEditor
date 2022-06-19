using ScriptEditor.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptEditor.ConfigEditor
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

    }
}
