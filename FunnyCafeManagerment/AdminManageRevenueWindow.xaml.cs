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
    /// Interaction logic for AdminManageRevenueWindow.xaml
    /// </summary>
    public partial class AdminManageRevenueWindow : Window
    {
        public AdminManageRevenueWindow()
        {
            InitializeComponent();
            LoadRevenueItemData();
        }
        private void LoadRevenueItemData()
        {
            // Tạo dữ liệu mẫu
            List<MenuRevenueItem> menuRevenueItems = new List<MenuRevenueItem>
    {
        new MenuRevenueItem { ID = 1, Ngay = DateTime.Now.AddDays(-1), DoanhThu = 150000 },
        new MenuRevenueItem { ID = 2, Ngay = DateTime.Now.AddDays(-2), DoanhThu = 200000 },
        new MenuRevenueItem { ID = 3, Ngay = DateTime.Now.AddDays(-3), DoanhThu = 100000 },
        new MenuRevenueItem { ID = 4, Ngay = DateTime.Now.AddDays(-4), DoanhThu = 250000 }
    };

            // Gán danh sách vào DataGrid
            RevenueItemDataGrid.ItemsSource = menuRevenueItems;
        }

        public class MenuRevenueItem
        {
            public int ID { get; set; }        // ID của giao dịch hoặc đơn hàng
            public DateTime Ngay { get; set; }  // Ngày giao dịch
            public decimal DoanhThu { get; set; } // Doanh thu của đơn hàng
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            // Tạo một đối tượng của HistoryWindow và mở nó
            AdminManageHistoryWindow historyWindow = new AdminManageHistoryWindow();
            historyWindow.Show();
            this.Close();
        }
        private void Revenue_Click(object sender, RoutedEventArgs e)
        {
            // Tạo một đối tượng của RevenueWindow và mở nó
            AdminManageRevenueWindow revenueWindow = new AdminManageRevenueWindow();
            revenueWindow.Show();
            this.Close();
        }
        private void Favorite_Click(object sender, RoutedEventArgs e)
        {
            // Tạo một đối tượng của FavoriteWindow và mở nó
            AdminManageFavoriteWindow favoriteWindow = new AdminManageFavoriteWindow();
            favoriteWindow.Show();
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
