using FunnyCafeManagerment_DataAccess.ViewModels;
using FunnyCafeManagerment_Service.Services;
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
		UserService userService;
		public LoginWindow()
		{
			userService = new UserService();
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

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
			if (txtUsername.Text != null && txtPassword.Password != null)
			{
				UserVM userVM = new()
				{
					Username = txtUsername.Text,
					Password = txtPassword.Password
				};

				var user = userService.Login(userVM);
				if (user != null && user.Role.Equals("Admin"))
				{
					userVM.UserId = user.UserId;
					userVM.FullName = user.FullName;
					App.MainViewModel.CurrentUser = userVM;

					AdminHomePageWindow aHP = new();
					this.Hide();
					aHP.Show();
					return;
				}
                if (user != null && user.Role.Equals("Nhân viên"))
                {
					userVM.UserId = user.UserId;
                    userVM.FullName = user.FullName;
                    App.MainViewModel.CurrentUser = userVM;

                    StaffHomePageWindow sHP = new();
                    this.Hide();
                    sHP.Show();
                    return;
                }
            }
			MessageBox.Show("Please enter invalid username or password", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);

			
        }
    }
}