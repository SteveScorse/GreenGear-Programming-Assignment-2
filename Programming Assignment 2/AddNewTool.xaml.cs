using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AddNewTool.xaml
    /// </summary>
    /// 

    //checkbox fuckery



    public partial class AddNewTool : Window


    {
        //create list to store objects
        private List<Tools> tools = new List<Tools>();
        //used for object ID
        private int nextID = 0;

        public List<Tools> ToolsList
        {
            get { return tools; }
        }

        //Trust the process
        public event EventHandler ToolAdded;

        private void OnToolAdded()
        {
            ToolAdded?.Invoke(this, EventArgs.Empty);
        }

        private void btnAddTool_Click(object sender, RoutedEventArgs e)
        {
            // Your existing code to add a new tool...

            // Raise the ToolAdded event to notify subscribers (e.g., LoanManager)
            OnToolAdded();
        }
    }

    private void RefreshTools()
        {
            //Remove Data
            listTools.ItemsSource = null;
            //Add all data to list (listTools)
            listTools.ItemsSource = tools;
        }

        public AddNewTool()
        {
            InitializeComponent();
            RefreshTools();
            tools.Add(new Tools(0, "Hammer", 15.99f, true));
            tools.Add(new Tools(1, "Hedge Trimmer", 39.99f, true));
            tools.Add(new Tools(2, "Trowel", 6.99f, true));
            tools.Add(new Tools(3, "Wheel Barrow", 32.89f, true));

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void lstProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAddTool_Click(object sender, RoutedEventArgs e)
        {
            //Variable to store inputs from the textboxes
            string newToolName = txtToolName.Text;
            //Validation loop - checks if empty o r
            if (string.IsNullOrWhiteSpace(newToolName))
            {
                MessageBox.Show("Please enter a tool name.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            float newToolPrice;
            if (!float.TryParse(txtToolPrice.Text, out newToolPrice) || newToolPrice <= 0)
            {
                MessageBox.Show("Please enter a valid tool price (> 0).", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //Get boolean value from checkbox
            bool newIsAvailable = txtIsAvailable.IsChecked ?? false;

            //Create a new Tools object and add it to the list
            var tool = new Tools(nextID++, newToolName, newToolPrice, newIsAvailable);
            tools.Add(tool);

            ComboBoxItem newItem = new ComboBoxItem();
            newItem.Content = tool; // Set the content of the ComboBoxItem to the tool object
            comboBoxTools.Items.Add(newItem); // Add ComboBoxItem to the ComboBox

            //Refresh the list to update the UI
            RefreshTools();

            //Clear input fields after adding the tool
            txtToolName.Clear();
            txtToolPrice.Clear();
            txtIsAvailable.IsChecked = false;


            //Success message
            MessageBox.Show("Tool added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnDeleteRow_Click(object sender, RoutedEventArgs e)
        {
            //Remove selected entry
            if (listTools.SelectedIndex != -1)
            {
                tools.RemoveAt(listTools.SelectedIndex);
                RefreshTools();
                //Success message
                MessageBox.Show("Tool removed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
