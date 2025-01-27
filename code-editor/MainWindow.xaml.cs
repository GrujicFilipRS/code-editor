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

namespace code_editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ResizeButton_Click(object sender, RoutedEventArgs e)
        {
            switch (GetWindow(this).WindowState)
            {
                case WindowState.Normal:
                    GetWindow(this).WindowState = WindowState.Maximized;
                    break;
                case WindowState.Maximized:
                    GetWindow(this).WindowState = WindowState.Normal;
                    break;
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            GetWindow(this).WindowState = WindowState.Minimized;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            GetWindow(this).Close();
        }
    }
}
