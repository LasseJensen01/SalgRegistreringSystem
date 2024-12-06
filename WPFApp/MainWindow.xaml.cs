using DTO.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFApp {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public static ObservableCollection<DTO.Model.Department> deps = new ObservableCollection<DTO.Model.Department>();
        public static ObservableCollection<DTO.Model.Case> cs = new ObservableCollection<DTO.Model.Case>();
        public static ObservableCollection<DTO.Model.TimeRegistration> tRegs = new ObservableCollection<TimeRegistration>();
        public static ObservableCollection<DTO.Model.Employee> employees = new ObservableCollection<Employee>();
        public static DTO.Model.Department CurrentDep = deps.FirstOrDefault();
        public static DTO.Model.Case CurrentCase = cs.FirstOrDefault();

        public MainWindow() {
            InitializeComponent();
            UpdateLists();
            Console.WriteLine(deps);
            // Binding for Deparment -> Listbox
            DepartmentsLB.DataContext = this;
            DepartmentsLB.ItemsSource = deps;
            // Binding for Case -> Listbox
            DepatmentCasesLB.DataContext = this;
            DepatmentCasesLB.ItemsSource = cs;
            //Binding for TimeRegistration -> Listbox
            TimeRegistrationLB.DataContext = this;
            TimeRegistrationLB.ItemsSource = tRegs;
            //Binding for Employees -> Listbox
            EmployeesLB.DataContext = this;
            EmployeesLB.ItemsSource = employees;

            TotalRB.IsChecked = true;
            
        }
        public static void UpdateLists() {
            var tempDep = BLL.BLL.DepartmentBLL.GetDepartments();
            deps.Clear();
            foreach (var dep in tempDep) {
                deps.Add(dep);
            }

            if(CurrentDep != null) {
                var tempCs = BLL.BLL.CaseBLL.GetCasesByDepID((CurrentDep as Department).ID);
                cs.Clear();
                foreach (var c in tempCs) {
                    cs.Add(c);
                }
            }

            if (CurrentCase != null) {
                var tempTrgs = BLL.BLL.TimeRegistrationBLL.GetByCaseID((CurrentCase as Case).ID);
                tRegs.Clear();
                foreach (var c in tempTrgs) {
                    tRegs.Add(c);
                }
            }

            var tempEmployees = BLL.BLL.EmployeeBLL.GetAllEmployees();
            employees.Clear();
            foreach(var em in tempEmployees) {
                employees.Add(em);
            }
            
        }

        private void AddNewDepBTT_Click(object sender, RoutedEventArgs e) {
            CreateDepartmentWindow cdw = new CreateDepartmentWindow();
            cdw.Show();
        }

        private void DepartmentsLB_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            DTO.Model.Department dep = ((sender as ListBox).SelectedItem as DTO.Model.Department);
            if (dep != null) {
                CurrentDep = dep;
                CaseNameTXT.Text = "";
                DepartmentNameTXTB.Text = dep.Name;
                var tempCs = BLL.BLL.CaseBLL.GetCasesByDepID(dep.ID);
                cs.Clear();
                foreach (var c in tempCs) {
                    cs.Add(c);
                }
                foreach (var c in cs) {
                    Console.WriteLine(c);
                }
            }
            
            
        }

        private void DepatmentCasesLB_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var c = ((sender as ListBox).SelectedItem as DTO.Model.Case);
            if (c != null) {
                CurrentCase = c;
                var tempTRegs = BLL.BLL.TimeRegistrationBLL.GetByCaseID(c.ID);
                CaseNameTXT.Text = c.Name;
                tRegs.Clear();
                foreach (var t in tempTRegs) {
                    tRegs.Add(t);
                }
            }
            else {
                tRegs.Clear();
            }
            
        }

        private void TimeRegistrationLB_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var tr = ((sender as ListBox).SelectedItem as TimeRegistration);
            if (tr != null) {
                EmployeeCB.ItemsSource = CurrentDep.Employees;
                Employee index = new Employee();
                foreach (var em in CurrentDep.Employees) {
                    if (em.ID == tr.Employee.ID) {
                        index = em;
                    }
                }
                EmployeeCB.SelectedItem = index;
                if (tr != null) {

                    StartTimeTXT.Text = tr.Start.ToString();
                    EndTimeTXT.Text = tr.End.ToString();
                }
            } else {
                EmployeeCB.ItemsSource = null;
                StartTimeTXT.Text = "";
                EndTimeTXT.Text = "";
            }
            
        }

        private void EmployeesLB_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var em = ((sender as ListBox).SelectedItem as Employee);
            if (em != null) {
                TotalRB.IsChecked = false; // Retriggers TotalRB_Checked
                TotalRB.IsChecked = true;
                EmployeeNameTXT.Text = em.Name;
                DepartmentCB.ItemsSource = deps;
                Department dep = new Department();
                foreach (var de in deps) {
                    if (em.DepartmentID == de.ID) {
                        dep = de;
                    }
                }
                DepartmentCB.SelectedItem = dep;

                var trRegs = BLL.BLL.TimeRegistrationBLL.GetByEmployeeID(em.ID);
                TimeRegistrationLB2.ItemsSource = trRegs;
            }
        }

        private void TimeRegistrationLB2_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var tr = ((sender as ListBox).SelectedItem as TimeRegistration);
            if (tr != null) {
                StartTimeTXT2.Text = tr.Start.ToString();
                EndTimeTXT2.Text = tr.End.ToString();
            } else {
                StartTimeTXT2.Text = "";
                EndTimeTXT2.Text = "";
            }
        }

        private void TotalRB_Checked(object sender, RoutedEventArgs e) {
            
                var em = EmployeesLB.SelectedItem as Employee;
                if (em != null) {
                    EmployeeNameTXT.Text = em.Name;
                    DepartmentCB.ItemsSource = deps;
                    Department dep = new Department();
                    foreach (var de in deps) {
                        if (em.DepartmentID == de.ID) {
                            dep = de;
                        }
                    }
                    DepartmentCB.SelectedItem = dep;

                    var trRegs = BLL.BLL.TimeRegistrationBLL.GetByEmployeeID(em.ID);
                    TimeSpan summedTime = TimeSpan.Zero;
                    foreach(var tr in trRegs) {
                    summedTime += tr.End - tr.Start;
                    }
                    TotalWorkTimeLBL.Content = summedTime.Hours + " Hr " + summedTime.Minutes + " Min";
                    TimeRegistrationLB2.ItemsSource = trRegs;
            }
            
        }

        private void WeekRB_Checked(object sender, RoutedEventArgs e) {
            var em = EmployeesLB.SelectedItem as Employee;
            if (em != null) {
                EmployeeNameTXT.Text = em.Name;
                DepartmentCB.ItemsSource = deps;
                Department dep = new Department();
                foreach (var de in deps) {
                    if (em.DepartmentID == de.ID) {
                        dep = de;
                    }
                }
                DepartmentCB.SelectedItem = dep;

                DateTime filterItem = DateTime.Now.AddDays(-7);
                var trRegs = BLL.BLL.TimeRegistrationBLL.GetByEmployeeID(em.ID).Where(tr => tr.Start > filterItem);
                TimeSpan summedTime = TimeSpan.Zero;
                foreach (var tr in trRegs) {
                    summedTime += tr.End - tr.Start;
                }
                TotalWorkTimeLBL.Content = summedTime.Hours + " Hr " + summedTime.Minutes + " Min";
                TimeRegistrationLB2.ItemsSource = trRegs;
            }
        }

        private void MonthRB_Checked(object sender, RoutedEventArgs e) {
            var em = EmployeesLB.SelectedItem as Employee;
            if (em != null) {
                EmployeeNameTXT.Text = em.Name;
                DepartmentCB.ItemsSource = deps;
                Department dep = new Department();
                foreach (var de in deps) {
                    if (em.DepartmentID == de.ID) {
                        dep = de;
                    }
                }
                DepartmentCB.SelectedItem = dep;
                DateTime filterItem = DateTime.Now.AddDays(-30);
                var trRegs = BLL.BLL.TimeRegistrationBLL.GetByEmployeeID(em.ID).Where(tr => tr.Start > filterItem);
                TimeSpan summedTime = TimeSpan.Zero;
                foreach (var tr in trRegs) {
                    summedTime += tr.End - tr.Start;
                }
                TotalWorkTimeLBL.Content = summedTime.Hours + " Hr " + summedTime.Minutes + " Min";
                TimeRegistrationLB2.ItemsSource = trRegs;
            }
        }

        private void AddNewCaseBTT_Click(object sender, RoutedEventArgs e) {
            CreateCaseWindow ccw = new CreateCaseWindow();
            ccw.Show();
        }

        private void AddEmployeeBTT_Click(object sender, RoutedEventArgs e) {
            CreateEmployeeWindow cew = new CreateEmployeeWindow();
            cew.Show();
        }
    }
}
