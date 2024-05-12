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

namespace Programming_Assignment_2
{
    /// <summary>
    /// Interaction logic for LoanManager.xaml
    /// </summary>
    public partial class LoanManager : Window
    {

        private List<Loan> loans = new List<Loan>();
        private int nextID = 4;

        //Public List
        public List<Loan> LoanList
        {
            get { return loans; }
        }

        public LoanManager()
        {
            InitializeComponent();

            // access 'tools' list from AddNewTool
            AddNewTool addNewToolWindow = new AddNewTool();

            // Access the 'tools' list using the public property 'ToolsList'
            List<Tools> toolsList = addNewToolWindow.ToolsList;

            //Assigns Tools from the list to comboBox
            comboBoxTools.Items.Clear();
            comboBoxTools.ItemsSource = toolsList;


            //access 'customers' from ManageCustomers
            ManageCustomers manageCustomersWindow = new ManageCustomers();

            // Access the 'customers' list using the public property 'CustomersList'
            List<Customer> customerList = manageCustomersWindow.CustomerList;

            comboBoxCustomers.Items.Clear();
            comboBoxCustomers.ItemsSource = customerList;



            //loans.Add(new Loan(0, "John", "Smith", "12/12/24", "24/12/24", False));
            RefreshCustomers();

        }

        


        private void RefreshCustomers()
        {
            listLoans.ItemsSource = null; // Clear the existing items
            listLoans.ItemsSource = loans; // Set the items source to the list of customers
        }

        private void btnAddLoan_Click(object sender, RoutedEventArgs e)
        {
            string newCustomers = comboBoxCustomers.Text;
            if (string.IsNullOrWhiteSpace(newCustomers))
            {
                MessageBox.Show("Please select the name of the customer.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string newTools = comboBoxTools.Text;
            if (string.IsNullOrWhiteSpace(newTools))
            {
                MessageBox.Show("Please select the required tool.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string newLoanDateStr = dateLoanDate.Text;
            if (string.IsNullOrWhiteSpace(newLoanDateStr))
            {
                MessageBox.Show("Please enter a loan date.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string newDueDateStr = dateDueDate.Text;
            if (string.IsNullOrWhiteSpace(newDueDateStr))
            {
                MessageBox.Show("Please enter a due date.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Parse the loan date and due date strings into DateTime objects
            if (!DateTime.TryParse(newLoanDateStr, out DateTime newLoanDate))
            {
                MessageBox.Show("Invalid loan date format. Please enter a valid date.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!DateTime.TryParse(newDueDateStr, out DateTime newDueDate))
            {
                MessageBox.Show("Invalid due date format. Please enter a valid date.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validate the loan date and due date
            if (newDueDate <= newLoanDate || newDueDate > newLoanDate.AddMonths(1))
            {
                MessageBox.Show("Due date must be after the loan date and no more than one month later.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //var customer = new Customer(nextID++, newFirstName, newLastName, newPhoneNo, newPaymentType);
            //customers.Add(customer);

           // RefreshCustomers(); // Update the UI

            // Clear input fields
          //  txtFirstName.Clear();
          //  txtLastName.Clear();
           // txtPhoneNo.Clear();
          //  comboBoxPayment.SelectedIndex = -1;

            MessageBox.Show("Customer added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnDeleteRow_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }

        private void btnUpdateLoan_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}