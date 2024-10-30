using FunnyCafeManagerment_DataAccess.Contexts;
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
    /// Interaction logic for AdminManageTableWindow.xaml
    /// </summary>
    public partial class AdminManageTableWindow : Window
    {
        public AdminManageTableWindow()
        {
            InitializeComponent();
            LoadTableData();
        }

        private void LoadTableData()
        {
            using (var context = new FunnyCafeContext())
            {
                var tables = context.Tables
                    .Select(table => new
                    {
                        table.TableId,
                        TableName = table.TableName,
                        //Seats = "1 ghế",
                        Status = table.Status,
                        StatusColor = table.Status == "Còn trống" ? "#3CB043" : "#FF0000"
                    })
                    .ToList();

                DataContext = tables;
            }
        }
        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == "Tìm kiếm")
            {
                textBox.Text = "";
                textBox.Foreground = new SolidColorBrush(Colors.Black); // Change color when focused
            }
        }

        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Tìm kiếm";
                textBox.Foreground = new SolidColorBrush(Colors.Gray); // Placeholder color
            }
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Kiểm tra nếu nội dung của TextBox là placeholder
            if (textBox != null && (textBox.Text == "Nhập tên sản phẩm" ||
                                    textBox.Text == "Nhập giá bán" ||
                                    textBox.Text == "Nhập số lượng" ||
                                    textBox.Text == "Nhập ghi chú"))
            {
                textBox.Text = string.Empty;  // Xóa placeholder
                textBox.Foreground = new SolidColorBrush(Colors.Black);  // Đổi màu chữ thành đen khi nhập liệu
            }
        }


        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Kiểm tra nếu TextBox trống và đặt lại placeholder tùy thuộc vào từng trường
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Foreground = new SolidColorBrush(Colors.Gray);  // Đổi lại màu chữ thành xám khi không có dữ liệu

                // Đặt lại placeholder tùy thuộc vào tên của TextBox
                if (textBox.Name == "TenSanPhamTextBox")
                {
                    textBox.Text = "Nhập tên sản phẩm";
                }
                else if (textBox.Name == "GiaBanTextBox")
                {
                    textBox.Text = "Nhập giá bán";
                }
                else if (textBox.Name == "SoLuongTextBox")
                {
                    textBox.Text = "Nhập số lượng";
                }
                else if (textBox.Name == "GhiChuTextBox")
                {
                    textBox.Text = "Nhập ghi chú";
                }
                else if (textBox.Name == "EditTenSanPhamTextBox")
                {
                    textBox.Text = "Nhập tên sản phẩm";
                }
                else if (textBox.Name == "EditGiaBanTextBox")
                {
                    textBox.Text = "Nhập giá bán";
                }
                else if (textBox.Name == "EditSoLuongTextBox")
                {
                    textBox.Text = "Nhập số lượng";
                }
                else if (textBox.Name == "EditGhiChuTextBox")
                {
                    textBox.Text = "Nhập ghi chú";
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Đặt lại style cho tất cả các nút về style mặc định
            ResetButtonStyles();

            // Áp dụng style được chọn cho nút vừa được nhấn
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                clickedButton.Style = (Style)FindResource("SelectedButtonStyle");
            }
        }

        private void ResetButtonStyles()
        {
            // Lặp qua tất cả các Button trong MenuStackPanel để đặt lại style
            foreach (var child in MenuStackPanel.Children)
            {
                if (child is Button btn)
                {
                    btn.Style = (Style)FindResource("MenuButtonStyle");
                }
            }
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
        // Hàm xử lý sự kiện cho nút "Thêm"
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void MinimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
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
