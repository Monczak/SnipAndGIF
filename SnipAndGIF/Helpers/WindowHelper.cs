using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SnipAndGIF.Helpers
{
    public static class WindowHelper
    {
        public static Rect GetCurrentScreenBounds()
        {
            return new Rect(SystemParameters.VirtualScreenLeft, SystemParameters.VirtualScreenTop, SystemParameters.VirtualScreenWidth, SystemParameters.VirtualScreenHeight);
        }
    }
}
