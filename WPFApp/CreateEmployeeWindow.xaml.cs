using DTO.Model;
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

namespace WPFApp {
    /// <summary>
    /// Interaction logic for CreateEmployeeWindow.xaml
    /// </summary>
    public partial class CreateEmployeeWindow : Window {
        public List<DTO.Model.Department> deps = new List<DTO.Model.Department>();
        public CreateEmployeeWindow() {
            InitializeComponent();
            deps = BLL.BLL.DepartmentBLL.GetDepartments();
            DepartmentCB.ItemsSource = deps;
            DepartmentCB.SelectedItem = deps.FirstOrDefault();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            if (NameTXT.Text != null || NameTXT.Text != "") {
                int depID = (DepartmentCB.SelectedItem as Department).ID;
                BLL.BLL.EmployeeBLL.CreateEmployee(NameTXT.Text, depID);
                MainWindow.UpdateLists();
                this.Close();
            }
        }
    }
}
