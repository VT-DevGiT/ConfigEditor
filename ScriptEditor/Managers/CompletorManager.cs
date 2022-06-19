using ScriptEditor.Elements;
using ScriptEditor.Interfaces;
using ScriptEditor.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptEditor.Managers
{
    internal class CompletorManager : FixedListManager<Completor>, IWriteManager
    {
        public object CurrentObject { get; set; }
        public Completor Current => CurrentObject as Completor;
        public void PrepareNew()
        {
            CurrentObject = new Completor();
            Current.CompletorType = CompletorType.ByValue;
        }

        public CompletorManager() : base(Config.Singleton.Completors)
        {

        }
        public override DelStatus Delete(Completor element)
        {
            var result = base.Delete(element);
            Config.Singleton.Save();
            return result;
        }
        public bool Save()
        {
            if (Current.IsNew())
            {
                Current.Id = Config.Singleton.GetCompletorId();
                Config.Singleton.Completors.Add(Current);
                LoadList(Config.Singleton.Completors);
                OnElementListUpdated();
            }
            Config.Singleton.Save();
            return true;
        }
    }
}
