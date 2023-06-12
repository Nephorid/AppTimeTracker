using System.Windows;
using System.Windows.Input;

namespace AppTimeTracker
{
    public partial class CustomInputDialog : Window
    {
        public string GameName { get; private set; }

        public CustomInputDialog()
        {
            InitializeComponent();
        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void MoveWindow(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (WindowState == WindowState.Maximized)
                {
                    WindowState = WindowState.Normal;
                    Point mousePos = PointToScreen(Mouse.GetPosition(this));
                    Left = mousePos.X - ActualWidth / 2;
                    Top = 0;
                    DragMove();
                }
                else
                {
                    DragMove();
                }
            }
        }
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            GameName = txtGameName.Text;
            Close();
        }
    }
}
