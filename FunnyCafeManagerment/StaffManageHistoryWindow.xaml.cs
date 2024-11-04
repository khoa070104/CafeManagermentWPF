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
using FunnyCafeManagerment_DataAccess.Contexts;
using FunnyCafeManagerment_DataAccess.Models;

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
            using (var context = new FunnyCafeContext())
            {
                var menuHistoryItems = context.Orders
                    .Select(order => new
                    {
                        STT = order.OrderId,
                        TenKhachHang = order.Customer != null ? order.Customer.FullName : "Khách vãng lai",
                        ThoiGian = order.OrderDate ?? DateTime.MinValue,
                        GiaTriHoaDon = order.OrderDetails
                            .Sum(od => (od.Quantity ?? 0) * (od.Product != null ? od.Product.Price ?? 0 : 0))
                    })
                    .ToList();

                HistoryItemDataGrid.ItemsSource = menuHistoryItems;
            }
        }
        public class MenuHistoryItem
        {
            public int STT { get; set; }
            public string TenKhachHang { get; set; }
            public DateTime ThoiGian { get; set; }
            public decimal GiaTriHoaDon { get; set; }
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
            if (HistoryItemDataGrid.SelectedItem is not null)
            {
                var selectedOrder = (dynamic)HistoryItemDataGrid.SelectedItem;
                LoadOrderDetails(selectedOrder.STT);
                OrderDetailForm.Visibility = Visibility.Visible;
            }
        }

        private void LoadOrderDetails(int orderId)
        {
            using (var context = new FunnyCafeContext())
            {
                var order = context.Orders
                    .Where(o => o.OrderId == orderId)
                    .Select(o => new
                    {
                        CustomerName = o.Customer != null ? o.Customer.FullName : "Khách vãng lai",
                        EmployeeName = o.User != null ? o.User.FullName : "Không rõ",
                        OrderDate = o.OrderDate,
                        TotalAmount = o.OrderDetails.Sum(od => (od.Quantity ?? 0) * (od.Product != null ? od.Product.Price ?? 0 : 0)),
                        Products = o.OrderDetails.Select(od => new
                        {
                            STT = od.OrderDetailId,
                            TenSanPham = od.Product != null ? od.Product.ProductName : "Không rõ",
                            SoLuong = od.Quantity,
                            DonGia = od.Product != null ? od.Product.Price : 0,
                            ThanhTien = (od.Quantity ?? 0) * (od.Product != null ? od.Product.Price ?? 0 : 0)
                        }).ToList()
                    })
                    .FirstOrDefault();

                if (order != null)
                {
                    HoTenTextBox.Text = order.CustomerName;
                    EmployeeBox.Text = order.EmployeeName;
                    ProductDataGrid.ItemsSource = order.Products;
                    OrderDateTextBlock.Text = $"Thời gian: {order.OrderDate:dd/MM/yyyy HH:mm:ss}";
                    TotalAmountTextBlock.Text = $"Tổng: {order.TotalAmount:N0} đ";
                }
            }
        }

        private void HideOrderDetailForm_Click(object sender, RoutedEventArgs e)
        {
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
