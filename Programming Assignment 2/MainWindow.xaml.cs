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

namespace Programming_Assignment_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnManageLoans_Click(object sender, RoutedEventArgs e)
        {
            LoanManager LoanManagerWindow = new LoanManager();
            //Hides Current Form (register)
            this.Hide();
            //open login form
            LoanManagerWindow.ShowDialog();
            this.Show();

        }

        private void btnOverdueTools_Click(object sender, RoutedEventArgs e)
        {
            OverdueLoans OverdueLoansWindow = new OverdueLoans();
            //Hides Current Form (register)
            this.Hide();
            //open login form
            OverdueLoansWindow.ShowDialog();
            this.Show();

        }

        private void btnAddTools_Click(object sender, RoutedEventArgs e)
        {
            AddNewTool AddNewToolWindow = new AddNewTool();
            //Hides Current Form (register)
            this.Hide();
            //open login form
            AddNewToolWindow.ShowDialog();
            this.Show();

        }

        private void btnManageCustomers_Click(object sender, RoutedEventArgs e)
        {
            ManageCustomers ManageCustomersWindow = new ManageCustomers();
            //Hides Current Form (register)
            this.Hide();
            //open login form
            ManageCustomersWindow.ShowDialog();
            this.Show();

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
