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
using static FunnyCafeManagerment.StaffManageOrderWindow;

namespace FunnyCafeManagerment
{
    /// <summary>
    /// Interaction logic for StaffManageOrderWindow.xaml
    /// </summary>
    public partial class StaffManageOrderWindow : Window
    {
        private List<ProductItem> productItems;

        public StaffManageOrderWindow()
        {
            InitializeComponent();
            LoadProductItemData();
        }
        private void LoadProductItemData()
        {
            // Tạo dữ liệu mẫu
            List<ProductItem> productItems = new List<ProductItem>
    {
        new ProductItem { STT = 1, TenSanPham = "Cà phê sữa", SoLuong = 2, DonGia = 25000 },
        new ProductItem { STT = 2, TenSanPham = "Trà đào", SoLuong = 1, DonGia = 30000 },
        new ProductItem { STT = 3, TenSanPham = "Sinh tố bơ", SoLuong = 1, DonGia = 45000 },
        new ProductItem { STT = 4, TenSanPham = "Nước ép cam", SoLuong = 3, DonGia = 35000 }
    };

            // Gán danh sách vào DataGrid
            OrderDataGrid.ItemsSource = productItems;
        }

        // Lớp ProductItem đại diện cho mỗi sản phẩm
        public class ProductItem
        {
            public int STT { get; set; }            // Số thứ tự
            public string TenSanPham { get; set; }  // Tên sản phẩm
            public int SoLuong { get; set; }        // Số lượng
            public decimal DonGia { get; set; }     // Đơn giá
            public decimal ThanhTien => SoLuong * DonGia; // Tính tự động thành tiền
        }

        // Xử lý sự kiện khi nhấn nút "-" (Giảm số lượng)
        private void DecreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int stt = (int)button.Tag;

            ProductItem selectedItem = productItems.FirstOrDefault(p => p.STT == stt);
            if (selectedItem != null && selectedItem.SoLuong > 0)
            {
                selectedItem.SoLuong--;
                OrderDataGrid.Items.Refresh(); // Làm mới DataGrid để cập nhật dữ liệu
            }
        }

        // Xử lý sự kiện khi nhấn nút "+" (Tăng số lượng)
        private void IncreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int stt = (int)button.Tag;

            ProductItem selectedItem = productItems.FirstOrDefault(p => p.STT == stt);
            if (selectedItem != null)
            {
                selectedItem.SoLuong++;
                OrderDataGrid.Items.Refresh(); // Làm mới DataGrid để cập nhật dữ liệu
            }
        }
        // Sự kiện khi nhấn nút "Bàn"
        private void BanButton_Click(object sender, RoutedEventArgs e)
        {
            // Hiển thị các row của Bàn và ẩn các row của Thực đơn
            BanRow.Visibility = Visibility.Visible;
            ThucDonRow.Visibility = Visibility.Collapsed;

            BanFilterRow.Visibility = Visibility.Visible;
            ThucDonFilterRow.Visibility = Visibility.Collapsed;

            // Cập nhật style của nút để phản ánh trạng thái đã chọn
            BanButton.Style = (Style)FindResource("SelectedHeaderButtonStyle");
            ThucDonButton.Style = (Style)FindResource("FilterHeaderButtonStyle");

            ButtonAll.Style = (Style)FindResource("SelectedFilterButtonStyle");
        }

        // Sự kiện khi nhấn nút "Thực đơn"
        private void ThucDonButton_Click(object sender, RoutedEventArgs e)
        {
            // Hiển thị các row của Thực đơn và ẩn các row của Bàn
            BanRow.Visibility = Visibility.Collapsed;
            ThucDonRow.Visibility = Visibility.Visible;

            BanFilterRow.Visibility = Visibility.Collapsed;
            ThucDonFilterRow.Visibility = Visibility.Visible;

            // Cập nhật style của nút để phản ánh trạng thái đã chọn
            ThucDonButton.Style = (Style)FindResource("SelectedHeaderButtonStyle");
            BanButton.Style = (Style)FindResource("FilterHeaderButtonStyle");

            ButtonAllMenu.Style = (Style)FindResource("SelectedFilterButtonStyle");
        }
        // Xử lý sự kiện cho các nút filter
        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            // Đặt lại tất cả các nút về trạng thái không chọn
            ButtonAll.Style = (Style)FindResource("FilterButtonStyle");
            ButtonBooked.Style = (Style)FindResource("FilterButtonStyle");
            ButtonAvailable.Style = (Style)FindResource("FilterButtonStyle");
            ButtonRepairing.Style = (Style)FindResource("FilterButtonStyle");

            ButtonAllMenu.Style = (Style)FindResource("FilterButtonStyle");
            ButtonCoffee.Style = (Style)FindResource("FilterButtonStyle");
            ButtonFreezee.Style = (Style)FindResource("FilterButtonStyle");
            ButtonFood.Style = (Style)FindResource("FilterButtonStyle");
            ButtonTea.Style = (Style)FindResource("FilterButtonStyle");
            ButtonOther.Style = (Style)FindResource("FilterButtonStyle");


            // Chuyển đổi nút được nhấn thành trạng thái chọn
            Button clickedButton = sender as Button;
            clickedButton.Style = (Style)FindResource("SelectedFilterButtonStyle");
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

        private void OpenBanHangWindow(object sender, RoutedEventArgs e)
        {
            StaffManageOrderWindow banHangWindow = new StaffManageOrderWindow();
            banHangWindow.Show();
            this.Close();
        }

        private void OpenLichSuWindow(object sender, RoutedEventArgs e)
        {
            StaffManageHistoryWindow lichSuWindow = new StaffManageHistoryWindow();
            lichSuWindow.Show();
            this.Close();
        }

        private void OpenSuCoWindow(object sender, RoutedEventArgs e)
        {
            StaffManageProblemWindow suCoWindow = new StaffManageProblemWindow();
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
