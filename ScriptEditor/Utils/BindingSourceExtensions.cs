using System.Windows.Forms;


namespace ConfigtEditor.Utils
{
    internal static class BindingSourceExtensions
    {

        #region Attributes & Properties
        #endregion

        #region Constructors & Destructor
        #endregion

        #region Methods
        public static void Refresh(this BindingSource source)
        {
            var current = source.DataSource;
            source.DataSource = current.GetType();
            source.DataSource = current;
        }
        #endregion

    }
}
