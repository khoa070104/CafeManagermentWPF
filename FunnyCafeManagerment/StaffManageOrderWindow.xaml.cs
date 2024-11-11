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
using FunnyCafeManagerment_DataAccess.Contexts;
using System.Collections.ObjectModel;
using FunnyCafeManagerment_DataAccess.Models;
using Table = FunnyCafeManagerment_DataAccess.Models.Table;
using Microsoft.EntityFrameworkCore;

namespace FunnyCafeManagerment
{
    /// <summary>
    /// Interaction logic for StaffManageOrderWindow.xaml
    /// </summary>
    public partial class StaffManageOrderWindow : Window
    {
        private List<ProductItem> productItems;
        private ObservableCollection<InvoiceProductItem> invoiceItems;
        private decimal totalAmount;
        private int? selectedCustomerId;

        public StaffManageOrderWindow()
        {
            InitializeComponent();
            LoadTableData();
            LoadProductData();
            InitializeInvoice();
            loadDataGrid();
            UpdateTotalAmount();
        }
        private void InitializeInvoice()
        {
            invoiceItems = new ObservableCollection<InvoiceProductItem>();
            OrderDataGrid.ItemsSource = invoiceItems;
            invoiceItems.CollectionChanged += (s, e) => UpdateTotalAmount();
        }
        private void ProductItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border border && border.DataContext is Product product)
            {
                string productName = product.ProductName ?? "Không rõ";
                decimal price = product.Price ?? 0;
                AddProductToInvoice(productName, price);
            }
        }
        private void addbtn_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                var dataContext = button.DataContext;
                if (dataContext != null)
                {
                    // Thử chuyển đổi kiểu dữ liệu
                    var product = new Product
                    {
                        ProductName = (string)dataContext.GetType().GetProperty("ProductName")?.GetValue(dataContext, null),
                        Price = (decimal?)dataContext.GetType().GetProperty("Price")?.GetValue(dataContext, null) ?? 0
                    };

                    // Thêm sản phẩm vào hóa đơn
                    AddProductToInvoice(product.ProductName, product.Price);
                }
            }
        }

        private void AddProductToInvoice(string productName, decimal? price)
        {
            var existingItem = invoiceItems.FirstOrDefault(item => item.TenSanPham == productName);
            if (existingItem != null)
            {
                existingItem.SoLuong++;
            }
            else
            {
                invoiceItems.Add(new InvoiceProductItem
                {
                    STT = invoiceItems.Count + 1,
                    TenSanPham = productName,
                    DonGia = price ?? 0m,
                    SoLuong = 1
                });
            }
            OrderDataGrid.Items.Refresh();
            UpdateTotalAmount();
         }

        private void LoadTableData()
        {
            using (var context = new FunnyCafeContext())
            {
                var tables = context.Tables
                    .Select(table => new TableDisplayInfo
                    {
                        TableId = table.TableId,
                        TableName = table.TableName,
                        Status = table.Status,
                        StatusColor = table.Status == "Còn trống" ? "#3CB043" : "#FF0000", // Màu sắc dựa trên trạng thái
                        TableImage = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/dining-table.png"), UriKind.Absolute))
                    })
                    .ToList();

                BanRowItemsControl.ItemsSource = tables;
            }
        }

        public void loadDataGrid()
        {
            OrderDataGrid.ItemsSource = invoiceItems;
        }

        private void LoadProductData()
        {
            using (var context = new FunnyCafeContext())
            {
                var products = context.Products
                    .Select(product => new
                    {
                        product.ProductId,
                        ProductName = product.ProductName,
                        Price = product.Price ?? 0,
                        ProductImage = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, product.ProductImage.TrimStart('/')), UriKind.Absolute))
                        //Quantity = 100 
                    })
                    .ToList();

                ThucDonRow.DataContext = products;
            }
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

        public class InvoiceProductItem
        {
            public int STT { get; set; }
            public string TenSanPham { get; set; }
            public int SoLuong { get; set; } = 1; 
            public decimal DonGia { get; set; }
            public decimal ThanhTien => SoLuong * DonGia;
        }

        public class TableDisplayInfo
        {
            public int TableId { get; set; }
            public string TableName { get; set; }
            public string Status { get; set; }
            public string StatusColor { get; set; }
            public BitmapImage TableImage { get; set; }
        }

        // Xử lý sự kiện khi nhấn nút "-" (Giảm số lượng)
        private void DecreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int stt)
            {
                var item = invoiceItems.FirstOrDefault(p => p.STT == stt);
                if (item != null && item.SoLuong > 1)
                {
                    item.SoLuong--;
                    OrderDataGrid.Items.Refresh();
                    UpdateTotalAmount();
                }
            }
        }

        // Xử lý sự kiện khi nhấn nút "+" (Tăng số lượng)
        private void IncreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int stt)
            {
                var item = invoiceItems.FirstOrDefault(p => p.STT == stt);
                if (item != null)
                {
                    item.SoLuong++;
                    OrderDataGrid.Items.Refresh();
                    UpdateTotalAmount();
                }
            }
        }
        // Sự kiện khi nhấn nút "Bàn"
        private void BanButton_Click(object sender, RoutedEventArgs e)
        {
            BanRow.Visibility = Visibility.Visible;
            ThucDonRow.Visibility = Visibility.Collapsed;

            BanFilterRow.Visibility = Visibility.Visible;
            ThucDonFilterRow.Visibility = Visibility.Collapsed;

            BanButton.Style = (Style)FindResource("SelectedHeaderButtonStyle");
            ThucDonButton.Style = (Style)FindResource("FilterHeaderButtonStyle");

            // Đảm bảo chỉ có một nút filter được chọn
            if (ButtonBooked.Style == (Style)FindResource("SelectedFilterButtonStyle"))
            {
                ButtonBooked.Style = (Style)FindResource("SelectedFilterButtonStyle");
            }
            else if (ButtonAvailable.Style == (Style)FindResource("SelectedFilterButtonStyle"))
            {
                ButtonAvailable.Style = (Style)FindResource("SelectedFilterButtonStyle");
            }
            else if (ButtonRepairing.Style == (Style)FindResource("SelectedFilterButtonStyle"))
            {
                ButtonRepairing.Style = (Style)FindResource("SelectedFilterButtonStyle");
            }
            else
            {
                ButtonAll.Style = (Style)FindResource("SelectedFilterButtonStyle");
            }
        }

        // Sự kiện khi nhấn nút "Thực đơn"
        private void ThucDonButton_Click(object sender, RoutedEventArgs e)
        {
            BanRow.Visibility = Visibility.Collapsed;
            ThucDonRow.Visibility = Visibility.Visible;

            BanFilterRow.Visibility = Visibility.Collapsed;
            ThucDonFilterRow.Visibility = Visibility.Visible;

            ThucDonButton.Style = (Style)FindResource("SelectedHeaderButtonStyle");
            BanButton.Style = (Style)FindResource("FilterHeaderButtonStyle");

            // Đảm bảo chỉ có một nút filter được chọn
            if (ButtonCoffee.Style == (Style)FindResource("SelectedFilterButtonStyle"))
            {
                ButtonCoffee.Style = (Style)FindResource("SelectedFilterButtonStyle");
            }
            else if (ButtonFreezee.Style == (Style)FindResource("SelectedFilterButtonStyle"))
            {
                ButtonFreezee.Style = (Style)FindResource("SelectedFilterButtonStyle");
            }
            else if (ButtonFood.Style == (Style)FindResource("SelectedFilterButtonStyle"))
            {
                ButtonFood.Style = (Style)FindResource("SelectedFilterButtonStyle");
            }
            else if (ButtonTea.Style == (Style)FindResource("SelectedFilterButtonStyle"))
            {
                ButtonTea.Style = (Style)FindResource("SelectedFilterButtonStyle");
            }
            else if (ButtonOther.Style == (Style)FindResource("SelectedFilterButtonStyle"))
            {
                ButtonOther.Style = (Style)FindResource("SelectedFilterButtonStyle");
            }
            else
            {
                ButtonAllMenu.Style = (Style)FindResource("SelectedFilterButtonStyle");
            }
        }
        // Xử lý sự kiện cho các nút filter
        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            // Đặt lại tất cả các nút về trạng thái không chọn
            ButtonAll.Style = (Style)FindResource("FilterButtonStyle");
            ButtonBooked.Style = (Style)FindResource("FilterButtonStyle");
            ButtonAvailable.Style = (Style)FindResource("FilterButtonStyle");
            ButtonRepairing.Style = (Style)FindResource("FilterButtonStyle");

            // Chuyển đổi nút được nhấn thành trạng thái chọn
            Button clickedButton = sender as Button;
            clickedButton.Style = (Style)FindResource("SelectedFilterButtonStyle");

            // Lọc bàn dựa trên trạng thái
            string status = clickedButton.Content.ToString();
            FilterTables(status);
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
            if (sender is Button button && button.DataContext is InvoiceProductItem itemToRemove)
            {
                // Xóa sản phẩm khỏi danh sách hóa đơn
                invoiceItems.Remove(itemToRemove);

                // Cập nhật lại DataGrid
                OrderDataGrid.Items.Refresh();

            }
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
        private void HideOrderDetailForm_Click(object sender, RoutedEventArgs e)
        {
            // Ẩn form
            OrderDetailForm.Visibility = Visibility.Collapsed;
        }

        private void AddTable_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is TableDisplayInfo table)
            {
                SelectedTableTextBlock.Text = $"{table.TableName}";
            }
        }

        private void UpdateTotalAmount()
        {
            totalAmount = invoiceItems.Sum(item => item.ThanhTien);
            TotalAmountTextBlock.Text = $"{totalAmount:N0} đ";
        }

        private void OpenCustomerWindow_Click(object sender, RoutedEventArgs e)
        {
            StaffManageCustomerWindow customerWindow = new StaffManageCustomerWindow();
            customerWindow.ShowDialog();
        }

        public void SetCustomer(int customerId, string customerName)
        {
            // Cập nhật tên khách hàng hiển thị
            CustomerNameTextBlock.Text = customerName;
            
            // Lưu ID khách hàng đã chọn
            selectedCustomerId = customerId;
        }

        private void ShowOrderDetailForm_Click(object sender, RoutedEventArgs e)
        {
            // Cập nhật thông tin khách hàng và sản phẩm vào OrderDetailForm
            HoTenTextBox.Text = CustomerNameTextBlock.Text;

            // Hiển thị tên nhân viên hiện tại
            EmployeeBox.Text = App.MainViewModel.CurrentUser.FullName;

            // Bind danh sách sản phẩm từ hóa đơn vào DataGrid trong OrderDetailForm
            ProductDataGrid.ItemsSource = invoiceItems;

            // Tính tổng tiền
            decimal totalAmount = invoiceItems.Sum(item => item.ThanhTien);
            OrderDetailTotalAmountTextBlock.Text = $"{totalAmount:N0} đ";

            // Lấy thời gian hiện tại
            DateTime currentTime = DateTime.Now;
            CurrentTimeTextBlock.Text = $"Thời gian: {currentTime:dd/MM/yyyy HH:mm:ss}";

            // Lưu thông tin vào cơ sở dữ liệu
            SaveOrderToDatabase();

            // Hiển thị form chi tiết hóa đơn
            OrderDetailForm.Visibility = Visibility.Visible;
        }

        private void SaveOrderToDatabase()
        {
            using (var context = new FunnyCafeContext())
            {
                // Tạo đối tượng Order mới
                var order = new Order
                {
                    UserId = App.MainViewModel.CurrentUser.UserId,
                    CustomerId = selectedCustomerId,
                    OrderDate = DateTime.Now
                };

                // Thêm Order vào cơ sở dữ liệu
                context.Orders.Add(order);
                context.SaveChanges();

                // Lưu từng sản phẩm trong hóa đơn vào OrderDetail
                foreach (var item in invoiceItems)
                {
                    var productId = GetProductIdByName(item.TenSanPham);
                    if (productId.HasValue)
                    {
                        var orderDetail = new OrderDetail
                        {
                            OrderId = order.OrderId,
                            ProductId = productId.Value,
                            Quantity = item.SoLuong
                        };

                        context.OrderDetails.Add(orderDetail);

                        // Kiểm tra và cập nhật ProductFavorite
                        var productFavorite = context.ProductFavorites
                            .FirstOrDefault(pf => pf.ProductID == orderDetail.ProductId);

                        if (productFavorite != null)
                        {
                            productFavorite.Quantity += item.SoLuong;
                            productFavorite.Revenue += item.SoLuong * item.DonGia;
                        }
                        else
                        {
                            var newProductFavorite = new ProductFavorite
                            {
                                ProductID = orderDetail.ProductId,
                                Quantity = item.SoLuong,
                                Revenue = item.SoLuong * item.DonGia
                            };
                            context.ProductFavorites.Add(newProductFavorite);
                        }
                    }
                }

                // Cập nhật hoặc thêm mới vào bảng Revenue
                var today = DateTime.Today;
                var revenue = context.Revenues.FirstOrDefault(r => r.RevenueDate == today);
                if (revenue != null)
                {
                    revenue.TotalRevenue += totalAmount;
                }
                else
                {
                    var newRevenue = new Revenue
                    {
                        RevenueDate = today,
                        TotalRevenue = totalAmount
                    };
                    context.Revenues.Add(newRevenue);
                }

                // Cập nhật Spending của Customer
                if (selectedCustomerId.HasValue)
                {
                    var customer = context.Customers.FirstOrDefault(c => c.CustomerId == selectedCustomerId.Value);
                    if (customer != null)
                    {
                        customer.Spending = (customer.Spending ?? 0) + totalAmount;
                    }
                }

                // Lưu thay đổi vào cơ sở dữ liệu
                context.SaveChanges();
            }
        }

        private int? GetSelectedCustomerId()
        {
            return selectedCustomerId;
        }

        private int? GetProductIdByName(string productName)
        {
            using (var context = new FunnyCafeContext())
            {
                var product = context.Products.FirstOrDefault(p => p.ProductName == productName);
                return product?.ProductId;
            }
        }

        private void FilterTables(string status)
        {
            using (var context = new FunnyCafeContext())
            {
                var tablesQuery = context.Tables.AsQueryable();

                if (status != "Tất cả")
                {
                    tablesQuery = tablesQuery.Where(table => table.Status == status);
                }

                var tables = tablesQuery
                    .Select(table => new TableDisplayInfo
                    {
                        TableId = table.TableId,
                        TableName = table.TableName,
                        Status = table.Status,
                        StatusColor = table.Status == "Còn trống" ? "#3CB043" : "#FF0000",
                        TableImage = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/dining-table.png"), UriKind.Absolute))
                    })
                    .ToList();

                BanRowItemsControl.ItemsSource = tables;
            }
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            // Đặt lại tất cả các nút về trạng thái không chọn
            ButtonAllMenu.Style = (Style)FindResource("FilterButtonStyle");
            ButtonCoffee.Style = (Style)FindResource("FilterButtonStyle");
            ButtonFreezee.Style = (Style)FindResource("FilterButtonStyle");
            ButtonFood.Style = (Style)FindResource("FilterButtonStyle");
            ButtonTea.Style = (Style)FindResource("FilterButtonStyle");
            ButtonOther.Style = (Style)FindResource("FilterButtonStyle");

            // Chuyển đổi nút được nhấn thành trạng thái chọn
            Button clickedButton = sender as Button;
            clickedButton.Style = (Style)FindResource("SelectedFilterButtonStyle");

            // Lọc sản phẩm theo danh mục
            string category = clickedButton.Content.ToString();
            FilterProductsByCategory(category);
        }

        private void FilterProductsByCategory(string categoryName)
        {
            using (var context = new FunnyCafeContext())
            {
                var productsQuery = context.Products.Include(p => p.Category).AsQueryable();

                if (categoryName != "Tất cả")
                {
                    productsQuery = productsQuery.Where(p => p.Category.CategoryName == categoryName);
                }

                var products = productsQuery
                    .Select(product => new
                    {
                        product.ProductId,
                        ProductName = product.ProductName,
                        Price = product.Price ?? 0,
                        ProductImage = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, product.ProductImage.TrimStart('/')), UriKind.Absolute))
                    })
                    .ToList();

                ThucDonRow.DataContext = products;
            }
        }

        private void ResetWindow()
        {
            // Xóa danh sách hóa đơn
            invoiceItems.Clear();

            // Đặt lại tổng tiền
            UpdateTotalAmount();

            // Đặt lại lựa chọn khách hàng
            CustomerNameTextBlock.Text = "Khách vãng lai";
            selectedCustomerId = null;

            // Đặt lại các nút lọc về trạng thái ban đầu
            BanButton_Click(null, null); // Hiển thị bàn
            ButtonAll.Style = (Style)FindResource("SelectedFilterButtonStyle");
            ButtonBooked.Style = (Style)FindResource("FilterButtonStyle");
            ButtonAvailable.Style = (Style)FindResource("FilterButtonStyle");
            ButtonRepairing.Style = (Style)FindResource("FilterButtonStyle");

            ButtonAllMenu.Style = (Style)FindResource("SelectedFilterButtonStyle");
            ButtonCoffee.Style = (Style)FindResource("FilterButtonStyle");
            ButtonFreezee.Style = (Style)FindResource("FilterButtonStyle");
            ButtonFood.Style = (Style)FindResource("FilterButtonStyle");
            ButtonTea.Style = (Style)FindResource("FilterButtonStyle");
            ButtonOther.Style = (Style)FindResource("FilterButtonStyle");

            // Tải lại dữ liệu bàn và sản phẩm
            LoadTableData();
            LoadProductData();
        }

        private void EndButton_Click(object sender, RoutedEventArgs e)
        {
            ResetWindow();
        }
    }
}
