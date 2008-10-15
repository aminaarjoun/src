using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Interop;

namespace Glassy
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            //Glass.ExtendGlassFrame(this, new Thickness(-1));
            //IntPtr hwnd = new WindowInteropHelper(this).Handle;
            //HwndSource.FromHwnd(hwnd).AddHook(new HwndSourceHook(WndProc));
        }
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled) {
            if (msg == WM_DWMCOMPOSITIONCHANGED) {
                Glass.ExtendGlassFrame(this, new Thickness(-1));
                handled = true;
            }
            return IntPtr.Zero;
        }
        private const int WM_DWMCOMPOSITIONCHANGED = 0x031E;

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
