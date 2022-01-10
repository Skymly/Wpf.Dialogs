using Dialogs;
using System.Windows;
using System.Windows.Input;

namespace DialogSample
{
    /// <summary>
    /// MyDialogWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MyDialogWindow : Window,IDialogWindow
    {
        public MyDialogWindow()
        {
            InitializeComponent();
        }

        public IDialogResult Result { get; set; }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton== MouseButtonState.Pressed)
            {
                DragMove();
            }

        }
    }
}
