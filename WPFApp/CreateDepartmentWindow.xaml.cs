﻿using System;
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

namespace WPFApp {
    /// <summary>
    /// Interaction logic for CreateDepartmentWindow.xaml
    /// </summary>
    public partial class CreateDepartmentWindow : Window {
        public CreateDepartmentWindow() {
            InitializeComponent();
        }

        private void CreateDepBTT_Click(object sender, RoutedEventArgs e) {
            string name = DepartNameTXT.Text;
            if (!string.IsNullOrWhiteSpace(name)) {
                BLL.BLL.DepartmentBLL.CreateDepartment(name);
                MainWindow.UpdateLists();
                this.Close();
            }
        }
    }
}
