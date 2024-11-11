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
using FunnyCafeManagerment_DataAccess.Models;

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
            try
            {
                using (var context = new FunnyCafeContext())
                {
                    var problemItems = context.Problems
                        .Select(p => new ProblemItem
                        {
                            ProblemId = p.ProblemId,
                            ProblemName = p.ProblemName,
                            Status = p.Status,
                            Note = p.Note
                        })
                        .ToList();

                    ProblemDataGrid.ItemsSource = problemItems;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi tải dữ liệu: " + ex.Message);
            }
        }

        public class ProblemItem
        {
            public int ProblemId { get; set; }
            public string ProblemName { get; set; }
            public string Status { get; set; }
            public string Note { get; set; }
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
            if (string.IsNullOrWhiteSpace(textBox.Text) || textBox.Text == "Tìm kiếm")
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

            // Lưu trữ thông tin sự cố cần xóa
            var button = sender as Button;
            var problemItem = button?.DataContext as ProblemItem;
            if (problemItem != null)
            {
                // Lưu trữ ID của sự cố cần xóa
                DeleteProblemId = problemItem.ProblemId;
            }
        }

        private int DeleteProblemId { get; set; }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            // Xóa sự cố khi người dùng nhấn "Có"
            DeleteProblem(DeleteProblemId);
        }

        private void DeleteProblem(int problemId)
        {
            try
            {
                using (var context = new FunnyCafeContext())
                {
                    var problemToDelete = context.Problems.Find(problemId);
                    if (problemToDelete != null)
                    {
                        context.Problems.Remove(problemToDelete);
                        context.SaveChanges();

                        MessageBox.Show("Sự cố đã được xóa thành công.");
                        LoadProblemItemData(); // Tải lại dữ liệu để cập nhật danh sách
                        HideDeleteForm_Click(null, null); // Ẩn form sau khi xóa
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sự cố để xóa.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi xóa sự cố: " + ex.Message);
            }
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

            // Lưu trữ thông tin sự cố cần chỉnh sửa
            var button = sender as Button;
            var problemItem = button?.DataContext as ProblemItem;
            if (problemItem != null)
            {
                // Lưu trữ ID của sự cố cần chỉnh sửa
                EditProblemId = problemItem.ProblemId;

                // Điền thông tin vào form
                EditTrangThaiComboBox.SelectedItem = problemItem.Status;
                EditGhiChuTextBox.Text = problemItem.Note;
            }
        }

        private void HideEditProblemForm_Click(object sender, RoutedEventArgs e)
        {
            // Ẩn form
            EditProblemForm.Visibility = Visibility.Collapsed;
        }
        private void BaoCao_Click(object sender, RoutedEventArgs e)
        {
            // Lấy thông tin từ các TextBox và ComboBox
            string tenSuCo = TenSuCoTextBox.Text;
            string trangThai = (TrangThaiComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string ghiChu = GhiChuTextBox.Text;

            // Kiểm tra nếu các trường cần thiết không rỗng
            if (!string.IsNullOrWhiteSpace(tenSuCo) && !string.IsNullOrWhiteSpace(trangThai))
            {
                // Gọi phương thức để thêm sự cố mới
                AddNewProblem(tenSuCo, trangThai, ghiChu);
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
            }
        }

        private void AddNewProblem(string problemName, string status, string note)
        {
            try
            {
                using (var context = new FunnyCafeContext())
                {
                    var newProblem = new Problem
                    {
                        ProblemName = problemName,
                        Status = status,
                        Note = note
                    };

                    context.Problems.Add(newProblem);
                    context.SaveChanges();

                    MessageBox.Show("Sự cố đã được thêm thành công.");
                    LoadProblemItemData(); // Tải lại dữ liệu để hiển thị sự cố mới
                    HideAddProblemForm_Click(null, null); // Ẩn form sau khi thêm
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm sự cố: " + ex.Message);
            }
        }

        private void Sua_Click(object sender, RoutedEventArgs e)
        {
            // Lấy thông tin từ các TextBox và ComboBox
            string trangThai = (EditTrangThaiComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string ghiChu = EditGhiChuTextBox.Text;

            // Kiểm tra nếu các trường cần thiết không rỗng
            if (!string.IsNullOrWhiteSpace(trangThai))
            {
                // Gọi phương thức để cập nhật sự cố
                UpdateProblem(EditProblemId, trangThai, ghiChu);
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
            }
        }

        private void UpdateProblem(int problemId, string status, string note)
        {
            try
            {
                using (var context = new FunnyCafeContext())
                {
                    var problemToUpdate = context.Problems.Find(problemId);
                    if (problemToUpdate != null)
                    {
                        problemToUpdate.Status = status;
                        problemToUpdate.Note = note;

                        context.SaveChanges();

                        MessageBox.Show("Sự cố đã được cập nhật thành công.");
                        LoadProblemItemData(); // Tải lại dữ liệu để cập nhật danh sách
                        HideEditProblemForm_Click(null, null); // Ẩn form sau khi cập nhật
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sự cố để cập nhật.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi cập nhật sự cố: " + ex.Message);
            }
        }

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

        // Khai báo biến EditProblemId để lưu trữ ID của sự cố cần chỉnh sửa
        private int EditProblemId { get; set; }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string searchText = textBox.Text.ToLower();

            using (var context = new FunnyCafeContext())
            {
                var filteredProblems = context.Problems
                    .Where(p => p.ProblemName.ToLower().Contains(searchText) ||
                                p.Status.ToLower().Contains(searchText) ||
                                p.Note.ToLower().Contains(searchText))
                    .Select(p => new ProblemItem
                    {
                        ProblemId = p.ProblemId,
                        ProblemName = p.ProblemName,
                        Status = p.Status,
                        Note = p.Note
                    })
                    .ToList();

                if (ProblemDataGrid != null)
                {
                    if (string.IsNullOrWhiteSpace(searchText) || searchText == "tìm kiếm")
                    {
                        LoadProblemItemData();
                    }
                    else
                    {
                        ProblemDataGrid.ItemsSource = filteredProblems;
                    }
                }
            }
        }
    }
}
