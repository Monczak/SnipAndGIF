using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SnipAndGIF.Classes
{
    public class CaptureRect
    {
        private double screenWidth, screenHeight;

        private Rect rect;

        public double width, height;
        public double x, y;

        public double ViewportWidth => width / screenWidth;
        public double ViewportHeight => height / screenHeight;
        public double ViewportX => x / screenWidth;
        public double ViewportY => y / screenHeight;

        public Rect GetRect()
        {
            if (rect == null) rect = new Rect();
            rect.X = ViewportX;
            rect.Y = ViewportY;
            rect.Width = ViewportWidth;
            rect.Height = ViewportHeight;

            return rect;
        }

        public CaptureRect(double _screenWidth, double _screenHeight)
        {
            screenWidth = _screenWidth;
            screenHeight = _screenHeight;
        }
    }
}
