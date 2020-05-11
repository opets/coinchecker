using System.Drawing;
using DevAge.Drawing.VisualElements;
using SourceGrid.Cells.Views;

namespace CC.COB.UI
{
    public static class GridHelper
    {
        public static IView CellViewNormal => new Cell
        {
            Background = new BackgroundLinearGradient(Color.LightGray, Color.White, 90)
        };

        public static IView CellViewAttention => new Cell
        {
            Background = new BackgroundLinearGradient(Color.LightGray, Color.GreenYellow, 90)
        };
    }
}