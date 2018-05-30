using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.ViewManagement;

namespace AccentApplicator.Core
{
    public class AccentColor
    {
        public void GetAccentColor()
        {
            var settings = new UISettings();
            settings.GetColorValue(UIColorType.Accent);
            //var lol = Windows.UI.Color();
        }
    }
}
