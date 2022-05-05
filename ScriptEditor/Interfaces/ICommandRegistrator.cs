using DevExpress.XtraBars;


namespace ScriptEditor.Interfaces

{
    internal interface ICommandRegistrator
    {
        void Register(string commandKey, ICommand command, string caption, BarItemLinkAlignment cmdAlignment);
    }
}