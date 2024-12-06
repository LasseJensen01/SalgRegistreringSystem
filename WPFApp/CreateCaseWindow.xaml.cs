using DTO.Model;
using System;
using System.Collections;
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
    /// Interaction logic for CreateCaseWindow.xaml
    /// </summary>
    public partial class CreateCaseWindow : Window {
        List<DTO.Model.Department> deps = new List<DTO.Model.Department>();
        public CreateCaseWindow() {
            InitializeComponent();
            deps = BLL.BLL.DepartmentBLL.GetDepartments();
            DepartmentCB.ItemsSource = deps;
            DepartmentCB.SelectedItem = deps.FirstOrDefault();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            if (!string.IsNullOrWhiteSpace(NameTXT.Text)) {
                if (DescriptionTXT.Text != null) {
                    int depId = (DepartmentCB.SelectedItem as Department).ID;
                    BLL.BLL.CaseBLL.CreateCase(NameTXT.Text, DescriptionTXT.Text, depId);
                    MainWindow.UpdateLists();
                    this.Close();
                }
            }
        }
    }
}
