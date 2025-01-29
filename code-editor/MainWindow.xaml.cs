using System.Windows;

namespace code_editor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MaxHeight = SystemParameters.WorkArea.Height + SystemParameters.WindowCaptionHeight;
        }
    }
}