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
    /// Interaction logic for StaffManageProblemWindow.xaml
    /// </summary>
    public partial class StaffManageProblemWindow : Window
    {
        public StaffManageProblemWindow()
        {
            InitializeComponent();
            LoadProblemItemData();  
        }
        private void LoadProblemItemData()
        {
            // Tạo dữ liệu mẫu
            List<ProblemItem> problemItems = new List<ProblemItem>
    {
        new ProblemItem { Id = 1, TenSuCo = "Gãy cây", TrangThai = "Chưa sửa", GhiChu = "Đang chờ xử lý" },
        new ProblemItem { Id = 2, TenSuCo = "Hỏng điện", TrangThai = "Đang sửa", GhiChu = "Có thợ đang sửa" },
        new ProblemItem { Id = 3, TenSuCo = "Rò rỉ nước", TrangThai = "Đã sửa", GhiChu = "Hoàn tất vào hôm qua" },
        new ProblemItem { Id = 4, TenSuCo = "Vỡ kính", TrangThai = "Chưa sửa", GhiChu = "Cần thay kính mới" }
    };

            // Gán danh sách vào DataGrid
            ProblemDataGrid.ItemsSource = problemItems;
        }

        public class ProblemItem
        {
            public int Id { get; set; }           // Viết hoa I trong Id
            public string TenSuCo { get; set; }   // Sử dụng PascalCase cho TenSuCo
            public string TrangThai { get; set; } // Viết hoa T trong TrangThai
            public string GhiChu { get; set; }    // Viết hoa G trong GhiChu
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

            if (textBox.Text == "Nhập tên sự cố" || textBox.Text == "Nhập ghi chú")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = new SolidColorBrush(Colors.Black); // Đổi màu văn bản thành đen khi nhập
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Foreground = new SolidColorBrush(Colors.Gray); // Đổi màu văn bản thành xám khi không có nội dung
                if (textBox.Name == "TenSuCoTextBox")
                {
                    textBox.Text = "Nhập tên sự cố";
                }
                else if (textBox.Name == "GhiChuTextBox")
                {
                    textBox.Text = "Nhập ghi chú";
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
        private void ShowAddProblemForm_Click(object sender, RoutedEventArgs e)
        {
            // Hiển thị form
            AddProblemForm.Visibility = Visibility.Visible;
        }

        private void HideAddProblemForm_Click(object sender, RoutedEventArgs e)
        {
            // Ẩn form
            AddProblemForm.Visibility = Visibility.Collapsed;
        }
        private void ShowEditProblemForm_Click(object sender, RoutedEventArgs e)
        {
            // Hiển thị form
            EditProblemForm.Visibility = Visibility.Visible;
        }

        private void HideEditProblemForm_Click(object sender, RoutedEventArgs e)
        {
            // Ẩn form
            EditProblemForm.Visibility = Visibility.Collapsed;
        }
        private void BaoCao_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Sua_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
