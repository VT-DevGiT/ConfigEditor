using DevExpress.XtraBars;


namespace ConfigtEditor.Interfaces

{
    internal interface ICommandRegistrator
    {
        void Register(string commandKey, ICommand command, string caption, BarShortcut shortcut, BarItemLinkAlignment cmdAlignment);
    }
}