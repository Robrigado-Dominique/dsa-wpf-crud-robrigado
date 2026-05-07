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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static crud_robrigado.MainWindow;

namespace crud_robrigado
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Employees> Employee {  get; }
        public class Employees
        { 
            public int Id {  get; set; }
            public string Name {  get; set; }
            public string Title {  get; set; }
            public string Department {  get; set; }
            public decimal Salary {  get; set; }
    }
        public MainWindow()
        {
            InitializeComponent();

            Employee = new List<Employees>
{
        new Employees { Id = 1, Name = "John Doe", Title = "Software Engineer", Department = "IT", Salary = 60000 },
        new Employees { Id = 2, Name = "Jane Smith", Title = "Project Manager", Department = "IT", Salary = 75000 },
        new Employees { Id = 3, Name = "Emily Davis", Title = "HR Specialist", Department = "HR", Salary = 50000 }
};
            this.DataContext = this;

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NameUser.Text != " " && TitleUser.Text != " " && DeptUser.Text != " " && SalaryUser.Text != " ")
                {
                    Employee.Add(new Employees
                    {
                        Id = int.Parse(IdUser.Text),
                        Name = NameUser.Text,
                        Title = TitleUser.Text,
                        Department = DeptUser.Text,
                        Salary = decimal.Parse(SalaryUser.Text)
                    });
                    employeez.Items.Refresh();

                    IdUser.Text = " ";
                    NameUser.Text = " ";
                    TitleUser.Text = " ";
                    DeptUser.Text = " ";
                    SalaryUser.Text = " ";
                }
            }

            catch
            {
                MessageBox.Show("Fill all the necessary fields correctly!");
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            Employees selectedEmployee = employeez.SelectedItem as Employees;
            if (selectedEmployee != null)
            {
                Employee.Remove(selectedEmployee);
                employeez.Items.Refresh();
                MessageBox.Show("Employee removed successfully.");
            }
            else
            {
                MessageBox.Show("Please select an employee to remove.");
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            IdUser.Text = " ";
            NameUser.Text = " ";
            TitleUser.Text = " ";
            DeptUser.Text = " ";
            SalaryUser.Text = " ";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
 
           
        }

        
    }
}
