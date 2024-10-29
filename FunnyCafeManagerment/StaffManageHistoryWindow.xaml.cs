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
    /// Interaction logic for StaffManageHistoryWindow.xaml
    /// </summary>
    public partial class StaffManageHistoryWindow : Window
    {
        public StaffManageHistoryWindow()
        {
            InitializeComponent();
            LoadHistoryItemData();
        }
        private void LoadHistoryItemData()
        {
            // Tạo dữ liệu mẫu
            List<MenuHistoryItem> menuHistoryItems = new List<MenuHistoryItem>
    {
        new MenuHistoryItem { STT = 1, TenKhachHang = "Nguyễn Văn A", ThoiGian = DateTime.Now.AddHours(-1), GiaTriHoaDon = 150000 },
        new MenuHistoryItem { STT = 2, TenKhachHang = "Trần Thị B", ThoiGian = DateTime.Now.AddHours(-2), GiaTriHoaDon = 200000 },
        new MenuHistoryItem { STT = 3, TenKhachHang = "Lê Văn C", ThoiGian = DateTime.Now.AddHours(-3), GiaTriHoaDon = 100000 },
        new MenuHistoryItem { STT = 4, TenKhachHang = "Phạm Thị D", ThoiGian = DateTime.Now.AddHours(-4), GiaTriHoaDon = 250000 }
    };

            // Gán danh sách vào DataGrid
            HistoryItemDataGrid.ItemsSource = menuHistoryItems;

            // Tạo danh sách sản phẩm mẫu
            List<Product> products = new List<Product>
            {
                new Product { STT = 1, TenSanPham = "Sản phẩm A", SoLuong = 10, DonGia = 20000 },
                new Product { STT = 2, TenSanPham = "Sản phẩm B", SoLuong = 5, DonGia = 30000 },
                new Product { STT = 3, TenSanPham = "Sản phẩm C", SoLuong = 20, DonGia = 15000 },
                new Product { STT = 4, TenSanPham = "Sản phẩm D", SoLuong = 15, DonGia = 25000 }
            };

            // Đặt ItemsSource cho DataGrid
            ProductDataGrid.ItemsSource = products;
        }
        public class MenuHistoryItem
        {
            public int STT { get; set; }
            public string TenKhachHang { get; set; }
            public DateTime ThoiGian { get; set; }
            public decimal GiaTriHoaDon { get; set; }
        }
        public class Product
        {
            public int STT { get; set; }
            public string TenSanPham { get; set; }
            public int SoLuong { get; set; }
            public decimal DonGia { get; set; }
            public decimal ThanhTien => SoLuong * DonGia; // Tính thành tiền
        }
        private void History_Click(object sender, RoutedEventArgs e)
        {
            // Tạo một đối tượng của HistoryWindow và mở nó
            StaffManageHistoryWindow historyWindow = new StaffManageHistoryWindow();
            historyWindow.Show();
            this.Close();
        }
        private void Favorite_Click(object sender, RoutedEventArgs e)
        {
            // Tạo một đối tượng của FavoriteWindow và mở nó
            StaffManageFavoriteWindow favoriteWindow = new StaffManageFavoriteWindow();
            favoriteWindow.Show();
            this.Close();
        }
        private void ShowOrderDetailForm_Click(object sender, RoutedEventArgs e)
        {
            // Hiển thị form
            OrderDetailForm.Visibility = Visibility.Visible;
        }

        private void HideOrderDetailForm_Click(object sender, RoutedEventArgs e)
        {
            // Ẩn form
            OrderDetailForm.Visibility = Visibility.Collapsed;
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

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            // Đóng cửa sổ sau khi người dùng nhấn "Có"
            this.Close();
        }

        // Xử lý sự kiện click cho nút "Không"
        private void NoButton_Click(object sender, RoutedEventArgs e)
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

        private void OpenStaffHomePageWindow(object sender, RoutedEventArgs e)
        {
            StaffHomePageWindow staffHomePageWindow = new StaffHomePageWindow();
            staffHomePageWindow.Show();
            this.Close();
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
