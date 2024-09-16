﻿using System;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FunnyCafeManagerment
{
    /// <summary>
    /// Interaction logic for ForgetWindow.xaml
    /// </summary>
    public partial class ForgetWindow : Window
    {
        public ForgetWindow()
        {
            InitializeComponent();
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
