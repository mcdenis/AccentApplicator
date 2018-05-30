using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AccentApplicator.Core
{
    internal class NativeMethods
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetSysColors(int cElements, int[] lpaElements, int[] lpaRgbValues);

        [DllImport("uxtheme.dll", SetLastError = true)]
        public static extern int GetThemeSysColor(IntPtr hTheme, int iColorId);
    }
}
