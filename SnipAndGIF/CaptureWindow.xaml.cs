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

namespace SnipAndGIF
{
    /// <summary>
    /// Interaction logic for CaptureWindow.xaml
    /// </summary>
    public partial class CaptureWindow : Window
    {
        public static RoutedCommand ExitCaptureCommand = new RoutedCommand();

        public CaptureWindow()
        {
            InitializeComponent();

            ExitCaptureCommand.InputGestures.Add(new KeyGesture(Key.Escape));
            CommandBindings.Add(new CommandBinding(ExitCaptureCommand, ExitCapture));
            CommandBindings.Add(new CommandBinding(ExitCaptureCommand, ExitCapture));

            MouseDown += CaptureWindow_MouseDown;
            MouseUp += CaptureWindow_MouseUp;
            MouseMove += CaptureWindow_MouseMove;
        }

        private void CaptureWindow_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void CaptureWindow_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine($"Mouse up! {e.GetPosition(Owner)}");
        }

        private void CaptureWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine($"Mouse down! {e.GetPosition(Owner)}");
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
    }
}
