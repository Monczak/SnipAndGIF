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
using System.Windows.Navigation;
using System.Windows.Shapes;

using NHotkey;
using NHotkey.Wpf;

using SnipAndGIF.Helpers;

namespace SnipAndGIF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            HotkeyManager.Current.AddOrReplace("Start Capture", new KeyGesture(Key.G, ModifierKeys.Shift | ModifierKeys.Windows), OnCaptureHotkey);
        }

        private void OnCaptureHotkey(object sender, HotkeyEventArgs e)
        {
            ShowCaptureWindow();
        }

        private void CaptureButton_Click(object sender, RoutedEventArgs e)
        {
            ShowCaptureWindow();
        }

        private void ShowCaptureWindow()
        {
            Rect windowRect = WindowHelper.GetCurrentScreenBounds();

            CaptureWindow window = new CaptureWindow
            {
                Width = windowRect.Width,
                Height = windowRect.Height,
                Left = windowRect.Left,
                Top = windowRect.Top
            };

            window.Closed += OnCaptureWindowClosed;

            window.Show();
            Hide();
        }

        private void OnCaptureWindowClosed(object sender, EventArgs e)
        {
            Show();
        }
    }
}
