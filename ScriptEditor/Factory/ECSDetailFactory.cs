using ScriptEditor.ConfigEditor;
using ScriptEditor.Controls;
using ScriptEditor.CustomClass;
using ScriptEditor.Interfaces;
using ScriptEditor.Utils;



namespace ScriptEditor.Factory
{
    public static class ECSDetailFactory
    {
        #region Methods - Global
        public static ECSUserControl CreateDetailControl(IWriteManager manager)
        {
            dynamic elem = manager.CurrentObject;
            return GetDetailControl(manager, elem);
        }

        private static ECSEditUserControl GetDetailControl(IWriteManager manager, object element)
        {
            ECSMessageBox.Show($"Detail for: {element}");
            return null;
        }
        #endregion
        #region private
        private static ECSEditUserControl GetDetailControl(IWriteManager manager, CustomSynapseClass element)
        {
            return new CustomSynapseClassEditUC(manager);
        }
        private static ECSEditUserControl GetDetailControl(IWriteManager manager, Room element)
        {
            return new RoomEditUC(manager);
        }
        #endregion
    }
}