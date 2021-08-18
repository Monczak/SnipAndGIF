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
        }

        private void ExitCapture(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
    }
}
