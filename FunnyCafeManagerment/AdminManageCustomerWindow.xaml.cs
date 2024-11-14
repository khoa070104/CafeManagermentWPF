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
using System.Collections.Generic;
using System.Windows.Media.Animation;
using FunnyCafeManagerment_DataAccess.Contexts;
using FunnyCafeManagerment_DataAccess.Models;

namespace FunnyCafeManagerment
{
    /// <summary>
    /// Interaction logic for AdminManageCustomerWindow.xaml
    /// </summary>
    public partial class AdminManageCustomerWindow : Window
    {
        private Customer _selectedCustomer;

        public AdminManageCustomerWindow()
        {
            InitializeComponent();
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            using (var context = new FunnyCafeContext())
            {
                var customers = context.Customers.ToList();
                customerDataGrid.ItemsSource = customers;
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

        // Xử lý sự kiện khi nhấn vào nút Delete
        private void ShowDeleteForm_Click(object sender, RoutedEventArgs e)
        {
            // Lấy khách hàng được chọn từ DataGrid
            _selectedCustomer = customerDataGrid.SelectedItem as Customer;

            if (_selectedCustomer != null)
            {
                // Hiển thị form xóa
                DeleteForm.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để xóa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void HideDeleteForm_Click(object sender, RoutedEventArgs e)
        {
            // Ẩn form xóa
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
            // Lấy khách hàng được chọn từ DataGrid
            _selectedCustomer = customerDataGrid.SelectedItem as Customer;

            if (_selectedCustomer != null)
            {
                // Hiển thị thông tin khách hàng trong EditForm
                EditHoTenTextBox.Text = _selectedCustomer.FullName;
                EditEmailTextBox.Text = _selectedCustomer.Email;
                EditSoDienThoaiTextBox.Text = _selectedCustomer.PhoneNumber;
                EditChiTieuTextBox.Text = _selectedCustomer.Spending?.ToString() ?? string.Empty;
                EditGhiChuTextBox.Text = _selectedCustomer.Notes;

                // Hiển thị form chỉnh sửa
                EditForm.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để chỉnh sửa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedCustomer != null)
            {
                // Cập nhật thông tin khách hàng
                _selectedCustomer.FullName = EditHoTenTextBox.Text;
                _selectedCustomer.Email = EditEmailTextBox.Text;
                _selectedCustomer.PhoneNumber = EditSoDienThoaiTextBox.Text;
                _selectedCustomer.Spending = decimal.TryParse(EditChiTieuTextBox.Text, out var spending) ? spending : (decimal?)null;
                _selectedCustomer.Notes = EditGhiChuTextBox.Text;

                // Lưu thay đổi vào cơ sở dữ liệu
                using (var context = new FunnyCafeContext())
                {
                    context.Customers.Update(_selectedCustomer);
                    context.SaveChanges();
                }

                // Cập nhật lại DataGrid
                LoadCustomerData();

                // Ẩn form chỉnh sửa
                EditForm.Visibility = Visibility.Collapsed;
            }
        }

        private void HideEditForm_Click(object sender, RoutedEventArgs e)
        {
            // Ẩn form
            EditForm.Visibility = Visibility.Collapsed;
        }
        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedCustomer != null)
            {
                // Xóa khách hàng khỏi cơ sở dữ liệu
                using (var context = new FunnyCafeContext())
                {
                    context.Customers.Remove(_selectedCustomer);
                    context.SaveChanges();
                }

                // Cập nhật lại DataGrid
                LoadCustomerData();

                // Ẩn form xóa
                DeleteForm.Visibility = Visibility.Collapsed;
            }
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Kiểm tra nếu nội dung của TextBox là placeholder (Nhập...)
            if (textBox != null && (textBox.Text == "Nhập họ tên" || textBox.Text == "Nhập email" ||
                                    textBox.Text == "Nhập chi tiêu" || textBox.Text == "Nhập số điện thoại" ||
                                    textBox.Text == "Nhập ghi chú"))
            {
                textBox.Text = string.Empty;  // Xóa placeholder
                textBox.Foreground = new SolidColorBrush(Colors.Black);  // Đổi màu chữ thành đen khi nhập liệu

                // Ẩn TextBlock liên quan
                TextBlock relatedTextBlock = this.FindName($"tb_{textBox.Name}") as TextBlock;
                if (relatedTextBlock != null)
                {
                    relatedTextBlock.Visibility = Visibility.Collapsed;  // Ẩn TextBlock
                }
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Foreground = new SolidColorBrush(Colors.Gray);  // Đổi lại màu chữ thành xám khi không có dữ liệu

                // Đặt lại placeholder tùy thuộc vào tên của TextBox
                if (textBox.Name == "HoTenTextBox")
                {
                    textBox.Text = "Nhập họ tên";
                }
                else if (textBox.Name == "EmailTextBox")
                {
                    textBox.Text = "Nhập email";
                }
                else if (textBox.Name == "ChiTieuTextBox")
                {
                    textBox.Text = "Nhập chi tiêu";
                }
                else if (textBox.Name == "SoDienThoaiTextBox")
                {
                    textBox.Text = "Nhập số điện thoại";
                }
                else if (textBox.Name == "GhiChuTextBox")
                {
                    textBox.Text = "Nhập ghi chú";
                }

                // Hiển thị lại TextBlock liên quan nếu có
                TextBlock relatedTextBlock = this.FindName($"tb_{textBox.Name}") as TextBlock;
                if (relatedTextBlock != null)
                {
                    relatedTextBlock.Visibility = Visibility.Visible;  // Hiển thị lại TextBlock
                }
            }
        }
        // Hàm xử lý sự kiện cho nút "Thêm"
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new FunnyCafeContext())
                {
                    // Chuyển đổi truy vấn sang client-side evaluation
                    bool isEmailExists = context.Customers
                        .AsEnumerable() // Chuyển đổi sang client-side evaluation
                        .Any(c => c.Email.Equals(EmailTextBox.Text, StringComparison.OrdinalIgnoreCase));

                    if (isEmailExists)
                    {
                        MessageBox.Show("Email đã tồn tại. Vui lòng chọn email khác.");
                        return;
                    }

                    // Tạo đối tượng Customer mới
                    var newCustomer = new Customer
                    {
                        FullName = HoTenTextBox.Text,
                        Email = EmailTextBox.Text,
                        PhoneNumber = SoDienThoaiTextBox.Text,
                        Spending = decimal.TryParse(ChiTieuTextBox.Text, out var spending) ? spending : (decimal?)null,
                        Notes = GhiChuTextBox.Text
                    };

                    // Lưu vào cơ sở dữ liệu
                    context.Customers.Add(newCustomer);
                    context.SaveChanges();
                }

                // Cập nhật lại DataGrid
                LoadCustomerData();

                // Ẩn form thêm
                AddForm.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm khách hàng: " + ex.Message);
            }
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

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string searchText = textBox.Text.ToLower();

            using (var context = new FunnyCafeContext())
            {
                var filteredCustomers = context.Customers
                    .Where(c => c.FullName.ToLower().Contains(searchText) || 
                                c.Email.ToLower().Contains(searchText) ||
                                c.PhoneNumber.ToLower().Contains(searchText))
                    .ToList();

                if (customerDataGrid != null)
                {
                    if (string.IsNullOrWhiteSpace(searchText) || searchText == "tìm kiếm")
                    {
                        LoadCustomerData();
                    }
                    else
                    {
                        customerDataGrid.ItemsSource = filteredCustomers;
                    }
                }
            }
        }
    }
}
