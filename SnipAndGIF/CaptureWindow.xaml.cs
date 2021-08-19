using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;
using Microsoft.Toolkit.Uwp.Notifications;

using SnipAndGIF.Classes;
using SnipAndGIF.Helpers;

namespace SnipAndGIF
{
    /// <summary>
    /// Interaction logic for CaptureWindow.xaml
    /// </summary>
    public partial class CaptureWindow : Window
    {
        public static RoutedCommand ExitCaptureCommand = new RoutedCommand();

        public CaptureRect captureRect;
        private bool drawingRect = false;

        private Point startingPoint;
        private Rect screenBounds;

        public double boundsThickness = 1;

        public CaptureWindow()
        {
            InitializeComponent();

            ExitCaptureCommand.InputGestures.Add(new KeyGesture(Key.Escape));
            CommandBindings.Add(new CommandBinding(ExitCaptureCommand, ExitCapture));
            CommandBindings.Add(new CommandBinding(ExitCaptureCommand, ExitCapture));

            MouseDown += CaptureWindow_MouseDown;
            MouseUp += CaptureWindow_MouseUp;
            MouseMove += CaptureWindow_MouseMove;
            
            screenBounds = WindowHelper.GetCurrentScreenBounds();
            Debug.WriteLine($"{screenBounds.Width} {screenBounds.Height}");
            captureRect = new CaptureRect(screenBounds.Width, screenBounds.Height);

            DataContext = captureRect;
            DrawCaptureRect();
        }

        private void CaptureWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawingRect)
            {
                Point position = e.GetPosition(this);
                UpdateCaptureRect(position);

                DrawCaptureRect();
            }
        }

        private void UpdateCaptureRect(Point position)
        {
            if (position.X > startingPoint.X)
            {
                captureRect.width = position.X - captureRect.x;
            }
            else
            {
                captureRect.width = startingPoint.X - position.X;
                captureRect.x = position.X;
            }

            if (position.Y > startingPoint.Y)
            {
                captureRect.height = position.Y - captureRect.y;
            }
            else
            {
                captureRect.height = startingPoint.Y - position.Y;
                captureRect.y = position.Y;
            }
        }

        private void CaptureWindow_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Point position = e.GetPosition(this);
            Debug.WriteLine($"Mouse up! {position}");

            drawingRect = false;
            ReleaseMouseCapture();
        }

        private void CaptureWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point position = e.GetPosition(this);
            Debug.WriteLine($"Mouse down! {position}");
            captureRect.x = position.X;
            captureRect.y = position.Y;

            startingPoint = position;

            drawingRect = true;
            CaptureMouse();
        }

        private void ExitCapture(object sender, ExecutedRoutedEventArgs e)
        {
            CreateToast();
            Close();
        }

        private void CreateToast()
        {
            ToastContentBuilder builder = new ToastContentBuilder();
            builder.AddText("hallo");
            builder.Show();
        }

        private void DrawCaptureRect()
        {
            CaptureRectGeometry.Rect = captureRect.GetRect();

            double boundsX = CaptureRectGeometry.Rect.Left * screenBounds.Width - boundsThickness;
            double boundsY = CaptureRectGeometry.Rect.Top * screenBounds.Height - boundsThickness;

            double width = CaptureRectGeometry.Rect.Width * screenBounds.Width + boundsThickness * 2;
            double height = CaptureRectGeometry.Rect.Height * screenBounds.Height + boundsThickness * 2;

            CaptureRectBounds.Margin = new Thickness(
                boundsX,
                boundsY,
                screenBounds.Width - boundsX - width,
                screenBounds.Height - boundsY - height
            );
        }
    }
}
