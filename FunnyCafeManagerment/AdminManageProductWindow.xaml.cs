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
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.IO;
using FunnyCafeManagerment_DataAccess.Models;

namespace FunnyCafeManagerment
{
    /// <summary>
    /// Interaction logic for AdminManageProductWindow.xaml
    /// </summary>
    public partial class AdminManageProductWindow : Window
    {
        private string productImage;
        private Product selectedProduct;
        private ProductViewModel productToDelete;
        private string currentCategory = "Tất cả";

        public AdminManageProductWindow()
        {
            InitializeComponent();
            LoadProductData();
        }

        public class ProductViewModel
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string CategoryName { get; set; }
            public decimal Price { get; set; }
            public BitmapImage ProductImage { get; set; }
            public Product Product { get; set; } // Tham chiếu đến đối tượng Product gốc
        }

        private void LoadProductData()
        {
            try
            {
                using (var context = new FunnyCafeContext())
                {
                    var productItems = context.Products
                        .Include(p => p.Category)
                        .Select(p => new ProductViewModel
                        {
                            ProductId = p.ProductId,
                            ProductName = p.ProductName,
                            CategoryName = p.Category != null ? p.Category.CategoryName : "Unknown",
                            Price = p.Price ?? 0,
                            ProductImage = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, p.ProductImage.TrimStart('/')), UriKind.Absolute)),
                            Product = p
                        })
                        .ToList();

                    ProductItemsControl.ItemsSource = productItems;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi tải dữ liệu sản phẩm: " + ex.Message);
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

                // Lọc sản phẩm theo danh mục
                currentCategory = clickedButton.Content.ToString(); // Cập nhật danh mục hiện tại
                FilterProductsByCategory(currentCategory);
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
            if (sender is Button button && button.DataContext is ProductViewModel productViewModel)
            {
                productToDelete = productViewModel;
                DeleteForm.Visibility = Visibility.Visible;
            }
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
            if (sender is Button button && button.DataContext is ProductViewModel productViewModel)
            {
                selectedProduct = productViewModel.Product;

                // Tải dữ liệu sản phẩm lên form chỉnh sửa
                EditTenSanPhamTextBox.Text = productViewModel.ProductName;
                EditGiaBanTextBox.Text = productViewModel.Price.ToString();

                // Kiểm tra và chọn đúng danh mục trong ComboBox
                string categoryId = productViewModel.Product.CategoryId?.Trim();

                EditDanhMucComboBox.SelectedValue = categoryId;

                // Cập nhật hình ảnh hiển thị
                EditProductImagePreview.Source = productViewModel.ProductImage;

                // Hiển thị form chỉnh sửa
                EditForm.Visibility = Visibility.Visible;
            }
        }

        private void HideEditForm_Click(object sender, RoutedEventArgs e)
        {
            // Ẩn form
            EditForm.Visibility = Visibility.Collapsed;
        }
        // Hàm xử lý sự kiện cho nút "Thêm"
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new FunnyCafeContext())
                {
                    // Lấy thông tin từ form
                    string productName = TenSanPhamTextBox.Text;
                    string categoryId = (DanhMucComboBox.SelectedItem as ComboBoxItem)?.Tag.ToString();
                    decimal price = decimal.Parse(GiaBanTextBox.Text);
                    string productImage = this.productImage ?? "/images/default.jpg"; // Đường dẫn hình ảnh mặc định

                    // Kiểm tra nếu CategoryId không hợp lệ
                    if (string.IsNullOrEmpty(categoryId))
                    {
                        MessageBox.Show("Danh mục không hợp lệ.");
                        return;
                    }

                    // Tạo đối tượng sản phẩm mới
                    var newProduct = new Product
                    {
                        ProductName = productName,
                        CategoryId = categoryId,
                        Price = price,
                        ProductImage = productImage
                    };

                    // Thêm sản phẩm vào cơ sở dữ liệu
                    context.Products.Add(newProduct);
                    context.SaveChanges();

                    MessageBox.Show("Sản phẩm đã được thêm thành công!");

                    // Tải lại dữ liệu sản phẩm
                    LoadProductData();

                    // Ẩn form thêm sản phẩm
                    HideAddForm_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm sản phẩm: " + ex.Message);
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

        private void FilterProductsByCategory(string categoryName)
        {
            using (var context = new FunnyCafeContext())
            {
                var productItems = context.Products
                    .Include(p => p.Category)
                    .Where(p => categoryName == "Tất cả" || p.Category.CategoryName == categoryName)
                    .Select(p => new ProductViewModel
                    {
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                        CategoryName = p.Category != null ? p.Category.CategoryName : "Unknown",
                        Price = p.Price ?? 0,
                        ProductImage = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, p.ProductImage.TrimStart('/')), UriKind.Absolute)),
                        Product = p
                    })
                    .ToList();

                ProductItemsControl.ItemsSource = productItems;
            }
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFileName = openFileDialog.FileName;
                string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string imagesDirectory = System.IO.Path.Combine(projectDirectory, "Images");

                // Kiểm tra và tạo thư mục Images nếu chưa tồn tại
                if (!Directory.Exists(imagesDirectory))
                {
                    Directory.CreateDirectory(imagesDirectory);
                }

                string destinationPath = System.IO.Path.Combine(imagesDirectory, System.IO.Path.GetFileName(selectedFileName));

                // Sao chép file vào thư mục Images
                File.Copy(selectedFileName, destinationPath, true);

                // Cập nhật đường dẫn ảnh sản phẩm
                productImage = destinationPath;

                // Cập nhật hình ảnh hiển thị
                ProductImagePreview.Source = new BitmapImage(new Uri(destinationPath, UriKind.Absolute));
            }
        }

        private void SaveEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedProduct != null)
            {
                try
                {
                    using (var context = new FunnyCafeContext())
                    {
                        // Tìm sản phẩm trong cơ sở dữ liệu
                        var productToUpdate = context.Products.FirstOrDefault(p => p.ProductId == selectedProduct.ProductId);
                        if (productToUpdate != null)
                        {
                            // Cập nhật thông tin sản phẩm
                            productToUpdate.ProductName = EditTenSanPhamTextBox.Text;
                            productToUpdate.Price = decimal.Parse(EditGiaBanTextBox.Text);
                            productToUpdate.CategoryId = (EditDanhMucComboBox.SelectedItem as ComboBoxItem)?.Tag.ToString();
                            productToUpdate.ProductImage = selectedProduct.ProductImage; // Giữ nguyên đường dẫn ảnh

                            // Lưu thay đổi vào cơ sở dữ liệu
                            context.SaveChanges();

                            MessageBox.Show("Sản phẩm đã được cập nhật thành công!");

                            FilterProductsByCategory(currentCategory); // Tải lại dữ liệu sản phẩm theo danh mục hiện tại

                            // Ẩn form chỉnh sửa
                            HideEditForm_Click(sender, e);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi cập nhật sản phẩm: " + ex.Message);
                }
            }
        }

        private void EditUploadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFileName = openFileDialog.FileName;
                string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string imagesDirectory = System.IO.Path.Combine(projectDirectory, "Images");

                // Kiểm tra và tạo thư mục Images nếu chưa tồn tại
                if (!Directory.Exists(imagesDirectory))
                {
                    Directory.CreateDirectory(imagesDirectory);
                }

                string destinationPath = System.IO.Path.Combine(imagesDirectory, System.IO.Path.GetFileName(selectedFileName));

                // Sao chép file vào thư mục Images
                File.Copy(selectedFileName, destinationPath, true);

                // Cập nhật đường dẫn ảnh sản phẩm
                selectedProduct.ProductImage = destinationPath;

                // Cập nhật hình ảnh hiển thị
                EditProductImagePreview.Source = new BitmapImage(new Uri(destinationPath, UriKind.Absolute));
            }
        }

        private void ConfirmDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (productToDelete != null)
            {
                try
                {
                    using (var context = new FunnyCafeContext())
                    {
                        // Tìm sản phẩm trong cơ sở dữ liệu
                        var product = context.Products.FirstOrDefault(p => p.ProductId == productToDelete.ProductId);
                        if (product != null)
                        {
                            context.Products.Remove(product); // Xóa sản phẩm
                            context.SaveChanges(); // Lưu thay đổi

                            MessageBox.Show("Sản phẩm đã được xóa thành công!");

                            FilterProductsByCategory(currentCategory); // Tải lại dữ liệu sản phẩm theo danh mục hiện tại
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi xóa sản phẩm: " + ex.Message);
                }
                finally
                {
                    HideDeleteForm_Click(sender, e); // Ẩn form xóa
                }
            }
        }
    }
}
