using DevExpress.LookAndFeel;
using DevExpress.Skins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConfigEditor.Utils
{
    internal class Theme
    {
        [DllImport("UXTheme.dll", SetLastError = true, EntryPoint = "#138")]
        public static extern bool ShouldSystemUseDarkMode();

        public static void SetSkin(uint index)
        {
            List<SkinContainer> list = SkinManager.Default.Skins.Cast<SkinContainer>().ToList();
            if (index >= 0 && index < list.Count())
            {
                UserLookAndFeel.Default.SetSkinStyle(list[(int)index].SkinName);
            }
        }
    }
}
