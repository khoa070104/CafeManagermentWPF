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
    /// Interaction logic for AdminManageProblemWindow.xaml
    /// </summary>
    public partial class AdminManageProblemWindow : Window
    {
        public AdminManageProblemWindow()
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
            if (ProblemDataGrid.SelectedItem is ProblemItem selectedProblem)
            {
                DeleteForm.Visibility = Visibility.Visible;
            }
        }

        private void HideDeleteForm_Click(object sender, RoutedEventArgs e)
        {
            // Ẩn form
            DeleteForm.Visibility = Visibility.Collapsed;
        }
        private void ShowAddProblemForm_Click(object sender, RoutedEventArgs e)
        {
            // Đặt giá trị mặc định cho ComboBox
            ProblemStatusComboBox.SelectedIndex = 0;

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
            if (ProblemDataGrid.SelectedItem is ProblemItem selectedProblem)
            {
                EditTrangThaiComboBox.SelectedItem = selectedProblem.Status;
                EditGhiChuTextBox.Text = selectedProblem.Note;
                EditProblemForm.Visibility = Visibility.Visible;
            }
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
            if (ProblemDataGrid.SelectedItem is ProblemItem selectedProblem)
            {
                try
                {
                    using (var context = new FunnyCafeContext())
                    {
                        var problem = context.Problems.Find(selectedProblem.ProblemId);
                        if (problem != null)
                        {
                            problem.Status = (EditTrangThaiComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
                            problem.Note = EditGhiChuTextBox.Text;
                            context.SaveChanges();
                            LoadProblemItemData(); // Refresh data grid
                            HideEditProblemForm_Click(sender, e); // Close the form
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi cập nhật sự cố: " + ex.Message);
                }
            }
        }
        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProblemDataGrid.SelectedItem is ProblemItem selectedProblem)
            {
                try
                {
                    using (var context = new FunnyCafeContext())
                    {
                        var problem = context.Problems.Find(selectedProblem.ProblemId);
                        if (problem != null)
                        {
                            context.Problems.Remove(problem);
                            context.SaveChanges();
                            LoadProblemItemData(); // Refresh data grid
                            HideDeleteForm_Click(sender, e); // Close the form
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi xóa sự cố: " + ex.Message);
                }
            }
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

        private void AddProblemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new FunnyCafeContext())
                {
                    var newProblem = new Problem
                    {
                        ProblemName = ProblemNameTextBox.Text,
                        Status = (ProblemStatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
                        Note = ProblemNoteTextBox.Text
                    };

                    context.Problems.Add(newProblem);
                    context.SaveChanges();
                    LoadProblemItemData(); // Refresh data grid
                    HideAddProblemForm_Click(sender, e); // Close the form
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm sự cố: " + ex.Message);
            }
        }

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
