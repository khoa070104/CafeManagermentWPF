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

namespace FunnyCafeManagerment
{
	public partial class LoginWindow : Window
	{
		public LoginWindow()
		{
			InitializeComponent();
		}
		private void MinimizeWindow_Click(object sender, RoutedEventArgs e)
		{
			this.WindowState = WindowState.Minimized;
		}

		// Sự kiện phóng to cửa sổ
		private void MaximizeWindow_Click(object sender, RoutedEventArgs e)
		{
			if (this.WindowState == WindowState.Maximized)
			{
				this.WindowState = WindowState.Normal;
			}
			else
			{
				this.WindowState = WindowState.Maximized;
			}
		}

		// Sự kiện đóng cửa sổ
		private void CloseWindow_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void ForgetPasswordButton_Click(object sender, RoutedEventArgs e)
		{
			ForgetWindow forgetWindow = new ForgetWindow();
			forgetWindow.ShowDialog();
        }

		private void RegisterButton_Click(object sender, RoutedEventArgs e)
		{
			RegisterWindow registerWindow = new RegisterWindow();
			this.Hide();
			registerWindow.Show();
		}
	}
}