using ConfigEditor.Utils;
using ConfigtEditor.Elements;
using ConfigtEditor.Managers;
using ConfigtEditor.Utils;
using DevExpress.Office.Crypto;
using DevExpress.Skins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfigtEditor
{
    static class Program
    {
        //public static Config Config;
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Config.Load();
            SetTheme();
            ECSFormUtility.MainMdiParent = new MasterForm();
            Application.Run(ECSFormUtility.MainMdiParent);
        }

        static void SetTheme()
        {
            if (Theme.ShouldSystemUseDarkMode())
            {
                Theme.SetSkin(19);
            }
            else
            {
                Theme.SetSkin(18);
            }
        }
    }
}
