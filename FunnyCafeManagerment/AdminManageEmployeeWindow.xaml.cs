using FunnyCafeManagerment_DataAccess.Contexts;
using FunnyCafeManagerment_DataAccess.Models;
using FunnyCafeManagerment_DataAccess.ViewModels;
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
using System.Xml;

namespace FunnyCafeManagerment
{
    /// <summary>
    /// Interaction logic for AdminManageEmployeeWindow.xaml
    /// </summary>
    public partial class AdminManageEmployeeWindow : Window
    {
        private User selectedUser;
        private User userToDelete; 
        public AdminManageEmployeeWindow()
        {
            InitializeComponent();
            LoadEmployeeData();
        }

        private void LoadEmployeeData()
        {
            using (var context = new FunnyCafeContext())
            {
                var employees = context.Users.ToList();
                customerDataGrid.ItemsSource = employees;
            }
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
                                    textBox.Text == "Nhập mật khẩu"))
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
                else if (textBox.Name == "PasswordTextBox" || textBox.Name == "EditPasswordTextBox")
                {
                    textBox.Text = "Nhập mật khẩu";
                }
            }
        }

        // Xử lý sự kiện khi nhấn vào nút Delete
        private void ShowDeleteForm_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is User user)
            {
                userToDelete = user;
                DeleteForm.Visibility = Visibility.Visible;
            }
        }

        private void HideDeleteForm_Click(object sender, RoutedEventArgs e)
        {
            DeleteForm.Visibility = Visibility.Collapsed;
        }
        private void ShowAddForm_Click(object sender, RoutedEventArgs e)
        {
            AddForm.Visibility = Visibility.Visible;
        }

        private void HideAddForm_Click(object sender, RoutedEventArgs e)
        {
            AddForm.Visibility = Visibility.Collapsed;
        }
        private void ShowEditForm_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is User user)
            {
                selectedUser = user;

                EditHoTenTextBox.Text = user.FullName;
                EditEmailTextBox.Text = user.Email;
                EditSoDienThoaiTextBox.Text = user.Phone;
                EditLuongTextBox.Text = user.Salary.ToString();

                EditGioiTinhComboBox.SelectedItem = EditGioiTinhComboBox.Items
                    .Cast<ComboBoxItem>()
                    .FirstOrDefault(item => item.Content.ToString() == user.Gender);

                EditTrangThaiComboBox.SelectedItem = EditTrangThaiComboBox.Items
                    .Cast<ComboBoxItem>()
                    .FirstOrDefault(item => item.Content.ToString() == user.Status);

                EditChucVuComboBox.SelectedItem = EditChucVuComboBox.Items
                    .Cast<ComboBoxItem>()
                    .FirstOrDefault(item => item.Content.ToString() == user.Role);

                EditNgaySinhDatePicker.SelectedDate = user.Dob;
                EditNgayBatDauDatePicker.SelectedDate = user.StartDay;
                EditLoginHoTenTextBox.Text = user.Username;
                EditPasswordTextBox.Text = user.Password;

                EditForm.Visibility = Visibility.Visible;
            }
        }

        private void HideEditForm_Click(object sender, RoutedEventArgs e)
        {
            EditForm.Visibility = Visibility.Collapsed;
        }
        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }        
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new FunnyCafeContext())
                {
                    string fullName = HoTenTextBox.Text;
                    string email = EmailTextBox.Text;
                    string phone = SoDienThoaiTextBox.Text;
                    string role = (ChucVuComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
                    int salary = int.Parse(LuongTextBox.Text);
                    string gender = (GioiTinhComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
                    DateTime dob = NgaySinhDatePicker.SelectedDate ?? DateTime.Now;
                    DateTime startDay = NgayBatDauDatePicker.SelectedDate ?? DateTime.Now;
                    string status = (TrangThaiComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
                    string username = LoginHoTenTextBox.Text;
                    string password = PasswordTextBox.Text;

                    var newUser = new User
                    {
                        FullName = fullName,
                        Email = email,
                        Phone = phone,
                        Role = role,
                        Salary = salary,
                        Gender = gender,
                        Dob = dob,
                        StartDay = startDay,
                        Status = status,
                        Username = username,
                        Password = password
                    };

                    context.Users.Add(newUser);
                    context.SaveChanges();

                    MessageBox.Show("Nhân viên đã được thêm thành công!");

                    LoadEmployeeData();

                    HideAddForm_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm nhân viên: " + ex.Message + "\n" + ex.InnerException?.Message);
            }
        }

        private void ShowSidebarForm_Click(object sender, RoutedEventArgs e)
        {
            SidebarForm.Visibility = Visibility.Visible;
            RightOverlay.Visibility = Visibility.Visible;

            var fadeIn = new DoubleAnimation(0, 0.5, TimeSpan.FromMilliseconds(300));
            DimBackground.BeginAnimation(OpacityProperty, fadeIn);
        }

        private void HideSidebarForm_Click(object sender, RoutedEventArgs e)
        {
            SidebarForm.Visibility = Visibility.Collapsed;

            var fadeOut = new DoubleAnimation(0.5, 0, TimeSpan.FromMilliseconds(300));
            fadeOut.Completed += (s, a) =>
            {
                RightOverlay.Visibility = Visibility.Collapsed;
            };
            DimBackground.BeginAnimation(OpacityProperty, fadeOut);
        }

        private void OpenAdminHomePageWindow(object sender, RoutedEventArgs e)
        {
            AdminHomePageWindow adminHomePageWindow = new AdminHomePageWindow();
            adminHomePageWindow.Show();
            this.Close();
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
            AdminManageCustomerWindow khachHangWindow = new AdminManageCustomerWindow();
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

        private void SaveEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedUser != null)
            {
                try
                {
                    using (var context = new FunnyCafeContext())
                    {
                        // Tìm nhân viên trong cơ sở dữ liệu
                        var userToUpdate = context.Users.FirstOrDefault(u => u.UserId == selectedUser.UserId);
                        if (userToUpdate != null)
                        {
                            // Cập nhật thông tin nhân viên
                            userToUpdate.FullName = EditHoTenTextBox.Text;
                            userToUpdate.Email = EditEmailTextBox.Text;
                            userToUpdate.Phone = EditSoDienThoaiTextBox.Text;
                            userToUpdate.Salary = int.Parse(EditLuongTextBox.Text);
                            userToUpdate.Gender = (EditGioiTinhComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
                            userToUpdate.Dob = EditNgaySinhDatePicker.SelectedDate ?? DateTime.Now;
                            userToUpdate.StartDay = EditNgayBatDauDatePicker.SelectedDate ?? DateTime.Now;
                            userToUpdate.Status = (EditTrangThaiComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
                            userToUpdate.Username = EditLoginHoTenTextBox.Text;
                            userToUpdate.Password = EditPasswordTextBox.Text;
                            userToUpdate.Role = (EditChucVuComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

                            // Lưu thay đổi vào cơ sở dữ liệu
                            context.SaveChanges();

                            MessageBox.Show("Thông tin nhân viên đã được cập nhật thành công!");

                            // Tải lại dữ liệu nhân viên
                            LoadEmployeeData();

                            // Ẩn form chỉnh sửa
                            HideEditForm_Click(sender, e);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi cập nhật thông tin nhân viên: " + ex.Message);
                }
            }
        }

        private void ConfirmDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (userToDelete != null)
            {
                try
                {
                    using (var context = new FunnyCafeContext())
                    {
                        var orders = context.Orders.Where(o => o.UserId == userToDelete.UserId).ToList();

                        foreach (var order in orders)
                        {
                            var orderDetails = context.OrderDetails.Where(od => od.OrderId == order.OrderId).ToList();
                            context.OrderDetails.RemoveRange(orderDetails);
                        }

                        context.Orders.RemoveRange(orders);

                        var user = context.Users.FirstOrDefault(u => u.UserId == userToDelete.UserId);
                        if (user != null)
                        {
                            context.Users.Remove(user); 
                            context.SaveChanges(); 

                            MessageBox.Show("Nhân viên đã được xóa thành công!");

                            LoadEmployeeData();
                        }
                    }
                }
                catch (Exception)
                {
                    // Xử lý lỗi mà không hiển thị message box
                }
                finally
                {
                    HideDeleteForm_Click(sender, e);
                }
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string searchText = textBox.Text.ToLower();

            using (var context = new FunnyCafeContext())
            {
                var filteredEmployees = context.Users
                    .Where(u => u.FullName.ToLower().Contains(searchText) || 
                                u.Email.ToLower().Contains(searchText))
                    .ToList();

                if (customerDataGrid != null)
                {
                    if (string.IsNullOrWhiteSpace(searchText) || searchText == "tìm kiếm")
                    {
                        LoadEmployeeData();
                    }
                    else
                    {
                        customerDataGrid.ItemsSource = filteredEmployees;
                    }
                }
            }
        }
    }
}
