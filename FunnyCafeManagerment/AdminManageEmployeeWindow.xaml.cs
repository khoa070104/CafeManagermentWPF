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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FunnyCafeManagerment
{
    /// <summary>
    /// Interaction logic for AdminManageEmployeeWindow.xaml
    /// </summary>
    public partial class AdminManageEmployeeWindow : Window
    {
        public AdminManageEmployeeWindow()
        {
            InitializeComponent();
            List<Employee> employees = new List<Employee>
        {
                new Employee { ID = 1, HoTen = "Nguyễn Văn A", SoDienThoai = "0909123456", Email = "a@gmail.com", Sex = "Nam", DateOfBirth = "01/01/1990", StartDate = "01/01/2022", Position = "Nhân viên", Salary = 10000000, Status = "Đang làm việc" },
                new Employee { ID = 2, HoTen = "Trần Thị B", SoDienThoai = "0911123456", Email = "b@gmail.com", Sex = "Nữ", DateOfBirth = "02/02/1991", StartDate = "15/03/2021", Position = "Quản lý", Salary = 15000000, Status = "Đang làm việc" },
                new Employee { ID = 3, HoTen = "Lê Văn C", SoDienThoai = "0922123456", Email = "c@gmail.com", Sex = "Nam", DateOfBirth = "03/03/1992", StartDate = "10/06/2020", Position = "Nhân viên", Salary = 12000000, Status = "Nghỉ việc" },
                new Employee { ID = 4, HoTen = "Phạm Văn D", SoDienThoai = "0933123456", Email = "d@gmail.com", Sex = "Nam", DateOfBirth = "04/04/1993", StartDate = "20/09/2019", Position = "Nhân viên", Salary = 11000000, Status = "Đang làm việc" }
            };

            // Gán dữ liệu vào DataGrid
            customerDataGrid.ItemsSource = employees;
        }
        public class Employee
        {
            public int ID { get; set; }
            public string HoTen { get; set; }
            public string SoDienThoai { get; set; }
            public string Email { get; set; }
            public string Sex { get; set; }
            public string DateOfBirth { get; set; }
            public string StartDate { get; set; }
            public string Position { get; set; }
            public int Salary { get; set; }
            public string Status { get; set; }
        }

        private void searchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == "Tìm kiếm")
            {
                textBox.Text = "";
                textBox.Foreground = new SolidColorBrush(Colors.Black); // Đổi màu chữ khi người dùng nhập liệu
            }
        }

        // Xử lý sự kiện LostFocus cho searchTextBox
        private void searchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Tìm kiếm";
                textBox.Foreground = new SolidColorBrush(Colors.Gray); // Đổi lại màu chữ placeholder
            }
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Kiểm tra nếu nội dung của TextBox là placeholder
            if (textBox != null && (textBox.Text == "Nhập họ tên" || textBox.Text == "Nhập email" || textBox.Text == "Nhập giới tính" ||
                                    textBox.Text == "Nhập số điện thoại" || textBox.Text == "Nhập lương" ||
                                    textBox.Text == "Nhập họ tên đăng nhập" ||
                                    textBox.Text == "Nhập mật khẩu" || textBox.Text == "Xác nhận mật khẩu"))
            {
                textBox.Text = string.Empty;  // Xóa placeholder
                textBox.Foreground = new SolidColorBrush(Colors.Black);  // Đổi màu chữ thành đen khi nhập liệu
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Foreground = new SolidColorBrush(Colors.Gray);  // Đổi lại màu chữ thành xám khi không có dữ liệu

                // Đặt lại placeholder tùy thuộc vào tên của TextBox
                if (textBox.Name == "HoTenTextBox" || textBox.Name == "EditHoTenTextBox")
                {
                    textBox.Text = "Nhập họ tên";
                }
                else if (textBox.Name == "EmailTextBox" || textBox.Name == "EditEmailTextBox")
                {
                    textBox.Text = "Nhập email";
                }
                else if (textBox.Name == "SoDienThoaiTextBox" || textBox.Name == "EditSoDienThoaiTextBox")
                {
                    textBox.Text = "Nhập số điện thoại";
                }
                else if (textBox.Name == "LuongTextBox" || textBox.Name == "EditLuongTextBox")
                {
                    textBox.Text = "Nhập lương";
                }
                else if (textBox.Name == "LoginHoTenTextBox" || textBox.Name == "EditLoginHoTenTextBox")
                {
                    textBox.Text = "Nhập họ tên đăng nhập";
                }
                else if (textBox.Name == "GioiTinhTextBox" || textBox.Name == "EditGioiTinhTextBox")
                {
                    textBox.Text = "Nhập giới tính";
                }
            }
        }

        private void PasswordTextBoxVisible_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Kiểm tra nếu đây là TextBox của Add form hay Edit form
            if (textBox.Name == "PasswordTextBoxVisible")
            {
                PasswordTextBoxVisible.Visibility = Visibility.Collapsed;  // Ẩn TextBox (Add form)
                PasswordBox.Visibility = Visibility.Visible;  // Hiện PasswordBox (Add form)
                PasswordBox.Focus();  // Đặt focus vào PasswordBox (Add form)
            }
            else if (textBox.Name == "EditPasswordTextBoxVisible")
            {
                EditPasswordTextBoxVisible.Visibility = Visibility.Collapsed;  // Ẩn TextBox (Edit form)
                EditPasswordBox.Visibility = Visibility.Visible;  // Hiện PasswordBox (Edit form)
                EditPasswordBox.Focus();  // Đặt focus vào PasswordBox (Edit form)
            }
            else if (textBox.Name == "ConfirmPasswordTextBoxVisible")
            {
                ConfirmPasswordTextBoxVisible.Visibility = Visibility.Collapsed;  // Ẩn TextBox (Add form)
                ConfirmPasswordBox.Visibility = Visibility.Visible;  // Hiện PasswordBox (Add form)
                ConfirmPasswordBox.Focus();  // Đặt focus vào PasswordBox (Add form)
            }
            else if (textBox.Name == "EditConfirmPasswordTextBoxVisible")
            {
                EditConfirmPasswordTextBoxVisible.Visibility = Visibility.Collapsed;  // Ẩn TextBox (Edit form)
                EditConfirmPasswordBox.Visibility = Visibility.Visible;  // Hiện PasswordBox (Edit form)
                EditConfirmPasswordBox.Focus();  // Đặt focus vào PasswordBox (Edit form)
            }
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;

            // Kiểm tra nếu đây là PasswordBox của Add form hay Edit form
            if (string.IsNullOrEmpty(passwordBox.Password))
            {
                if (passwordBox.Name == "PasswordBox")
                {
                    PasswordBox.Visibility = Visibility.Collapsed;  // Ẩn PasswordBox (Add form)
                    PasswordTextBoxVisible.Visibility = Visibility.Visible;  // Hiện TextBox (Add form)
                }
                else if (passwordBox.Name == "EditPasswordBox")
                {
                    EditPasswordBox.Visibility = Visibility.Collapsed;  // Ẩn PasswordBox (Edit form)
                    EditPasswordTextBoxVisible.Visibility = Visibility.Visible;  // Hiện TextBox (Edit form)
                }
                else if (passwordBox.Name == "ConfirmPasswordBox")
                {
                    ConfirmPasswordBox.Visibility = Visibility.Collapsed;  // Ẩn PasswordBox (Add form)
                    ConfirmPasswordTextBoxVisible.Visibility = Visibility.Visible;  // Hiện TextBox (Add form)
                }
                else if (passwordBox.Name == "EditConfirmPasswordBox")
                {
                    EditConfirmPasswordBox.Visibility = Visibility.Collapsed;  // Ẩn PasswordBox (Edit form)
                    EditConfirmPasswordTextBoxVisible.Visibility = Visibility.Visible;  // Hiện TextBox (Edit form)
                }
            }
        }

        private void ConfirmPasswordTextBoxVisible_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Xử lý focus cho ConfirmPassword của Add form và Edit form
            if (textBox.Name == "ConfirmPasswordTextBoxVisible")
            {
                ConfirmPasswordTextBoxVisible.Visibility = Visibility.Collapsed;  // Ẩn TextBox (Add form)
                ConfirmPasswordBox.Visibility = Visibility.Visible;  // Hiện PasswordBox (Add form)
                ConfirmPasswordBox.Focus();  // Đặt focus vào PasswordBox (Add form)
            }
            else if (textBox.Name == "EditConfirmPasswordTextBoxVisible")
            {
                EditConfirmPasswordTextBoxVisible.Visibility = Visibility.Collapsed;  // Ẩn TextBox (Edit form)
                EditConfirmPasswordBox.Visibility = Visibility.Visible;  // Hiện PasswordBox (Edit form)
                EditConfirmPasswordBox.Focus();  // Đặt focus vào PasswordBox (Edit form)
            }
        }

        private void ConfirmPasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;

            // Kiểm tra nếu đây là ConfirmPasswordBox của Add form hay Edit form
            if (string.IsNullOrEmpty(passwordBox.Password))
            {
                if (passwordBox.Name == "ConfirmPasswordBox")
                {
                    ConfirmPasswordBox.Visibility = Visibility.Collapsed;  // Ẩn PasswordBox (Add form)
                    ConfirmPasswordTextBoxVisible.Visibility = Visibility.Visible;  // Hiện TextBox (Add form)
                }
                else if (passwordBox.Name == "EditConfirmPasswordBox")
                {
                    EditConfirmPasswordBox.Visibility = Visibility.Collapsed;  // Ẩn PasswordBox (Edit form)
                    EditConfirmPasswordTextBoxVisible.Visibility = Visibility.Visible;  // Hiện TextBox (Edit form)
                }
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // Hiển thị mật khẩu
            PasswordTextBoxVisible.Text = PasswordBox.Password;
            PasswordTextBoxVisible.Visibility = Visibility.Visible;
            PasswordBox.Visibility = Visibility.Collapsed;

            ConfirmPasswordTextBoxVisible.Text = ConfirmPasswordBox.Password;
            ConfirmPasswordTextBoxVisible.Visibility = Visibility.Visible;
            ConfirmPasswordBox.Visibility = Visibility.Collapsed;

            // Edit form
            EditPasswordTextBoxVisible.Text = EditPasswordBox.Password;
            EditPasswordTextBoxVisible.Visibility = Visibility.Visible;
            EditPasswordBox.Visibility = Visibility.Collapsed;

            EditConfirmPasswordTextBoxVisible.Text = EditConfirmPasswordBox.Password;
            EditConfirmPasswordTextBoxVisible.Visibility = Visibility.Visible;
            EditConfirmPasswordBox.Visibility = Visibility.Collapsed;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            // Ẩn mật khẩu
            PasswordBox.Password = PasswordTextBoxVisible.Text;
            PasswordBox.Visibility = Visibility.Visible;
            PasswordTextBoxVisible.Visibility = Visibility.Collapsed;

            ConfirmPasswordBox.Password = ConfirmPasswordTextBoxVisible.Text;
            ConfirmPasswordBox.Visibility = Visibility.Visible;
            ConfirmPasswordTextBoxVisible.Visibility = Visibility.Collapsed;

            // Edit form
            EditPasswordBox.Password = EditPasswordTextBoxVisible.Text;
            EditPasswordBox.Visibility = Visibility.Visible;
            EditPasswordTextBoxVisible.Visibility = Visibility.Collapsed;

            EditConfirmPasswordBox.Password = EditConfirmPasswordTextBoxVisible.Text;
            EditConfirmPasswordBox.Visibility = Visibility.Visible;
            EditConfirmPasswordTextBoxVisible.Visibility = Visibility.Collapsed;
        }

        // Xử lý sự kiện khi nhấn vào nút Delete
        private void ShowDeleteForm_Click(object sender, RoutedEventArgs e)
        {
            // Hiển thị form
            DeleteForm.Visibility = Visibility.Visible;
        }

        private void HideDeleteForm_Click(object sender, RoutedEventArgs e)
        {
            // Ẩn form
            DeleteForm.Visibility = Visibility.Collapsed;
        }
        private void ShowAddForm_Click(object sender, RoutedEventArgs e)
        {
            // Hiển thị form
            AddForm.Visibility = Visibility.Visible;
        }

        private void HideAddForm_Click(object sender, RoutedEventArgs e)
        {
            // Ẩn form
            AddForm.Visibility = Visibility.Collapsed;
        }
        private void ShowEditForm_Click(object sender, RoutedEventArgs e)
        {
            // Hiển thị form
            EditForm.Visibility = Visibility.Visible;
        }

        private void HideEditForm_Click(object sender, RoutedEventArgs e)
        {
            // Ẩn form
            EditForm.Visibility = Visibility.Collapsed;
        }
        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            // Đóng cửa sổ sau khi người dùng nhấn "Có"
            this.Close();
        }        
        // Hàm xử lý sự kiện cho nút "Thêm"
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // hiện slide bar
        private void ShowSidebarForm_Click(object sender, RoutedEventArgs e)
        {
            // Hiện SidebarForm và làm mờ phần còn lại
            SidebarForm.Visibility = Visibility.Visible;
            RightOverlay.Visibility = Visibility.Visible;

            // Tạo hiệu ứng mờ cho RightOverlay
            var fadeIn = new DoubleAnimation(0, 0.5, TimeSpan.FromMilliseconds(300));
            DimBackground.BeginAnimation(OpacityProperty, fadeIn);
        }

        private void HideSidebarForm_Click(object sender, RoutedEventArgs e)
        {
            // Ẩn SidebarForm và gỡ bỏ hiệu ứng mờ
            SidebarForm.Visibility = Visibility.Collapsed;

            // Tạo hiệu ứng làm mờ ngược cho RightOverlay
            var fadeOut = new DoubleAnimation(0.5, 0, TimeSpan.FromMilliseconds(300));
            fadeOut.Completed += (s, a) =>
            {
                RightOverlay.Visibility = Visibility.Collapsed;
            };
            DimBackground.BeginAnimation(OpacityProperty, fadeOut);
        }

        private void OpenSanPhamWindow(object sender, RoutedEventArgs e)
        {
            AdminManageProductWindow sanPhamWindow = new AdminManageProductWindow();
            sanPhamWindow.Show();
            this.Close();
        }

        private void OpenNhanVienWindow(object sender, RoutedEventArgs e)
        {
            AdminManageEmployeeWindow nhanVienWindow = new AdminManageEmployeeWindow();
            nhanVienWindow.Show();
            this.Close();
        }

        private void OpenBanWindow(object sender, RoutedEventArgs e)
        {
            AdminManageTableWindow banWindow = new AdminManageTableWindow();
            banWindow.Show();
            this.Close();
        }

        private void OpenKhachHangWindow(object sender, RoutedEventArgs e)
        {
            ManageCustomerWindow khachHangWindow = new ManageCustomerWindow();
            khachHangWindow.Show();
            this.Close();
        }

        private void OpenThongKeWindow(object sender, RoutedEventArgs e)
        {
            AdminManageRevenueWindow thongKeWindow = new AdminManageRevenueWindow();
            thongKeWindow.Show();
            this.Close();
        }

        private void OpenSuCoWindow(object sender, RoutedEventArgs e)
        {
            AdminManageProblemWindow suCoWindow = new AdminManageProblemWindow();
            suCoWindow.Show();
            this.Close();
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
    }
}
