using ScriptEditor.Elements;
using ScriptEditor.Managers;
using ScriptEditor.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptEditor
{
    static class Program
    {
        public static Config Config;
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Config = Config.Load();
            ECSFormUtility.MainMdiParent = new MasterForm();
            Application.Run(ECSFormUtility.MainMdiParent);
        }
    }
}
