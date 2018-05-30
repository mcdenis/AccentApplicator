using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drawing = System.Drawing;
using UI = Windows.UI;

namespace AccentApplicator.Core
{
    internal static class ColorUtils
    {
        public static Drawing.Color ToDrawingColor(this UI.Color uiColor)
        {
            return Drawing.Color.FromArgb(uiColor.A, uiColor.R, uiColor.G, uiColor.B);
        }
    }
}
