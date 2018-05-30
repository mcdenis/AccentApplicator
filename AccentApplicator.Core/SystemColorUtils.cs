using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace AccentApplicator.Core
{
    internal class SystemColorUtils
    {
        public static Color GetDefaultSystemColor(SystemColorId systemColorId)
        {
            //Note that GetThemeSysColor still works even when it is passed a null theme handle.
            //In that case, however, it just returns the value of GetSysColor, which would be 
            //the current color, not the default one, hence why we throw an exception if visual 
            //styles are not enabled.
            if (!VisualStyleRenderer.IsSupported)
            {
                throw new InvalidOperationException("Can't get the current theme color because visual styles are not enabled.");
            }

            //Here, the Button element is an arbitrary choice. We just need a theme handle.
            var vsRenderer = new VisualStyleRenderer(VisualStyleElement.Button.PushButton.Normal);
            var win32Color = NativeMethods.GetThemeSysColor(vsRenderer.Handle, (int)systemColorId);

            return ColorTranslator.FromWin32(win32Color);
        }
    }
}
