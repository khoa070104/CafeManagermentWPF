using FunnyCafeManagerment_DataAccess.Contexts;
using FunnyCafeManagerment_DataAccess.Models;
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
        private int _currentEditingTableId; // Biến lưu trữ ID của bàn đang được chỉnh sửa

        public AdminManageTableWindow()
        {
            InitializeComponent();
            LoadTableData();
        }

        private void LoadTableData(string statusFilter = null)
        {
            using (var context = new FunnyCafeContext())
            {
                var tablesQuery = context.Tables.AsQueryable();

                if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "Tất cả")
                {
                    tablesQuery = tablesQuery.Where(t => t.Status == statusFilter);
                }

                var tables = tablesQuery
                    .Select(table => new
                    {
                        table.TableId,
                        TableName = table.TableName,
                        Status = table.Status,
                        StatusColor = table.Status == "Còn trống" ? "#3CB043" : "#FF0000",
                        TableImage = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/dining-table.png"), UriKind.Absolute))
                    })
                    .ToList();

                DataContext = tables;
            }
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            // Đặt lại style cho tất cả các nút về style mặc định
            ResetButtonStyles();

            // Áp dụng style được chọn cho nút vừa được nhấn
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                clickedButton.Style = (Style)FindResource("SelectedButtonStyle");
                string statusFilter = clickedButton.Content.ToString();
                LoadTableData(statusFilter);
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

        // Xử lý sự kiện khi nhấn vào nút Delete
        private void ShowDeleteForm_Click(object sender, RoutedEventArgs e)
        {
            // Lấy TableId từ đối tượng được chọn
            var button = sender as Button;
            var tableId = (button.DataContext as dynamic).TableId;
            DeleteTable(tableId);
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
            // Lấy TableId từ đối tượng được chọn
            var button = sender as Button;
            var table = button.DataContext as dynamic;
            _currentEditingTableId = table.TableId;

            // Điền thông tin hiện tại vào form chỉnh sửa
            EditTableNameTextBox.Text = table.TableName;
            EditTrangThaiComboBox.SelectedItem = EditTrangThaiComboBox.Items
                .Cast<ComboBoxItem>()
                .FirstOrDefault(item => item.Content.ToString() == table.Status);

            // Hiển thị form chỉnh sửa
            EditForm.Visibility = Visibility.Visible;
        }

        private void HideEditForm_Click(object sender, RoutedEventArgs e)
        {
            // Ẩn form
            EditForm.Visibility = Visibility.Collapsed;
        }

        private void SaveEditButton_Click(object sender, RoutedEventArgs e)
        {
            string newTableName = EditTableNameTextBox.Text;
            string newStatus = (EditTrangThaiComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            EditTable(_currentEditingTableId, newTableName, newStatus);
            HideEditForm_Click(sender, e);
        }

        private void EditTable(int tableId, string newTableName, string newStatus)
        {
            try
            {
                using (var context = new FunnyCafeContext())
                {
                    var tableToEdit = context.Tables.FirstOrDefault(t => t.TableId == tableId);
                    if (tableToEdit != null)
                    {
                        tableToEdit.TableName = newTableName;
                        tableToEdit.Status = newStatus;
                        context.SaveChanges();
                        MessageBox.Show("Bàn đã được cập nhật thành công.");
                        LoadTableData();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy b��n để cập nhật.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi cập nhật bàn: " + ex.Message);
            }
        }

        // Hàm xử lý sự kiện cho nút "Thêm"
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string tableName = TableNameTextBox.Text;
            string status = (TrangThaiComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            AddTable(tableName, status);
            HideAddForm_Click(sender, e);
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

        private void AddTable(string tableName, string status)
        {
            try
            {
                using (var context = new FunnyCafeContext())
                {
                    var newTable = new FunnyCafeManagerment_DataAccess.Models.Table
                    {
                        TableName = tableName,
                        Status = status
                    };

                    context.Tables.Add(newTable);
                    context.SaveChanges();
                    MessageBox.Show("Bàn mới đã được thêm thành công.");
                    LoadTableData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm bàn: " + ex.Message);
            }
        }

        private void DeleteTable(int tableId)
        {
            try
            {
                using (var context = new FunnyCafeContext())
                {
                    var tableToDelete = context.Tables.FirstOrDefault(t => t.TableId == tableId);
                    if (tableToDelete != null)
                    {
                        context.Tables.Remove(tableToDelete);
                        context.SaveChanges();
                        MessageBox.Show("Bàn đã được xóa thành công.");
                        LoadTableData();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy bàn để xóa.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi xóa bàn: " + ex.Message);
            }
        }
    }
}
