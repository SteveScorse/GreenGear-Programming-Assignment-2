using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for ManageCustomers.xaml
    /// </summary>
    public partial class ManageCustomers : Window
    {

        private List<Customer> customers = new List<Customer>();
        private int nextID = 4;

        //Public List
        public List<Customer> CustomerList
        {
            get { return customers; }
        }


        public ManageCustomers()
        {
            InitializeComponent();

            //Add initial customers
            customers.Add(new Customer(0, "John", "Smith", "07237645823", "Debit Card"));
            customers.Add(new Customer(1, "Bart", "Jacksonickle", "07234009823", "Credit Card"));
            customers.Add(new Customer(2, "Angel", "Pudding", "07042645822", "Cash"));
            customers.Add(new Customer(3, "John", "Smith", "07298345821", "Crypto"));

            RefreshCustomers();

        }

        private void RefreshCustomers()
        {
            listCustomers.ItemsSource = null; // Clear the existing items
            listCustomers.ItemsSource = customers; // Set the items source to the list of customers
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            string newFirstName = txtFirstName.Text;
            if (string.IsNullOrWhiteSpace(newFirstName))
            {
                MessageBox.Show("Please enter customer's first name.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string newLastName = txtLastName.Text;
            if (string.IsNullOrWhiteSpace(newLastName))
            {
                MessageBox.Show("Please enter customer's last name.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string newPhoneNo = txtPhoneNo.Text;
            if (string.IsNullOrWhiteSpace(newPhoneNo) || !IsValidPhoneNumber(newPhoneNo))
            {
                MessageBox.Show("Please enter a valid phone number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string newPaymentType = comboBoxPayment.Text;
            if (string.IsNullOrWhiteSpace(newLastName))
            {
                MessageBox.Show("Please select a payment type.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var customer = new Customer(nextID++, newFirstName, newLastName, newPhoneNo, newPaymentType);
            customers.Add(customer);

            RefreshCustomers(); // Update the UI

            // Clear input fields
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPhoneNo.Clear();
            comboBoxPayment.SelectedIndex = -1;

            MessageBox.Show("Customer added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        //Phone no input RegEx validation
        static bool IsValidPhoneNumber(string newPhoneNo)
        {
            // Define a regular expression pattern for a valid phone number
            string pattern = @"^07\d{9}$";

            // Use Regex.IsMatch to check if the phone number matches the pattern
            return Regex.IsMatch(newPhoneNo, pattern);
        }

        private void btnDeleteRow_Click(object sender, RoutedEventArgs e)
        {
            if (listCustomers.SelectedIndex != -1)
            {
                customers.RemoveAt(listCustomers.SelectedIndex);
                RefreshCustomers(); // Update the UI after removing the tool
                MessageBox.Show("Tool removed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnUpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            if(listCustomers.SelectedItem is Customer selectedCustomer)
            {
                // Additional fields from other files
                string updatedFirstName = txtFirstName.Text;
                string updatedLastName = txtLastName.Text;
                string updatedPhoneNo = txtPhoneNo.Text;
                string updatedPaymentType = comboBoxPayment.Text;

                // Validation and update loan object based on input fields
                if (!string.IsNullOrWhiteSpace(updatedFirstName))
                {
                    selectedCustomer.FirstName = updatedFirstName;
                }

                if (!string.IsNullOrWhiteSpace(updatedLastName))
                {
                    selectedCustomer.LastName = updatedLastName;
                }

                if (!string.IsNullOrWhiteSpace(updatedPhoneNo) && IsValidPhoneNumber(updatedPhoneNo))
                {
                    selectedCustomer.PhoneNo = updatedPhoneNo;
                }
                else
                {
                    MessageBox.Show("Please enter a valid phone number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(updatedPaymentType))
                {
                    selectedCustomer.PaymentType = updatedPaymentType;
                }

                // Refresh the ListBox to reflect the updated loan details
                RefreshCustomers();

                MessageBox.Show("Loan updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select a loan to update.", "Update Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
