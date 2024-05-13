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
        private int nextID = 0;

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
            RefreshLoan();

        }

        


        private void RefreshLoan()
        {
            listLoans.ItemsSource = null; // Clear the existing items
            listLoans.ItemsSource = loans; // Set the items source to the list of customers
        }

        private void btnAddLoan_Click(object sender, RoutedEventArgs e)
        {
            //Validation and Variable initialisation
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

            // loan date and due date validation
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

            string newIsReturned = comboBoxReturned.Text;
            if (string.IsNullOrWhiteSpace(newIsReturned))
            {
                MessageBox.Show("Please select if the Tool has been returned", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            var loan = new Loan(nextID++, newCustomers, newTools, newLoanDateStr, newDueDateStr, newIsReturned);
            loans.Add(loan);

            RefreshLoan(); // Update the ListBox

           
            comboBoxCustomers.SelectedIndex = -1;
            comboBoxTools.SelectedIndex = -1;
            dateLoanDate.SelectedDate = null;
            dateDueDate.SelectedDate = null;
            comboBoxReturned.SelectedIndex = -1;

            MessageBox.Show("Loan added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
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
            if (listLoans.SelectedItem is Loan selectedProduct)
            {
                //selectedProduct.Name = txtProductName.Text;
               // selectedProduct.Price = decimal.Parse(txtProductPrice.Text);
               // selectedProduct.Stock = int.Parse(txtProductStock.Text);

            }
        }
    }
}