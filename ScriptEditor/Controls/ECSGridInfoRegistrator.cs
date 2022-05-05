using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;


namespace ScriptEditor.Controls
{
    public class ECSGridInfoRegistrator : GridInfoRegistrator
    {
        #region Attributes & Properties
        public override string ViewName
        {
            get { return nameof(ECSGridView); }
        }
        #endregion


        #region Constructors & Destructor
        #endregion


        #region Methods
        public override BaseView CreateView(GridControl grid)
        {
            return new ECSGridView(grid);
        }
        #endregion
    }
}