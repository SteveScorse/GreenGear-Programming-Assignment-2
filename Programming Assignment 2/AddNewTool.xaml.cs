using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Programming_Assignment_2
{
    public partial class AddNewTool : Window
    {


        // List to store tools
        private List<Tools> tools = new List<Tools>();
        private int nextID = 4;

        //Public List
        public List<Tools> ToolsList
        {
            get { return tools; }
        }

        public AddNewTool()
        {
            InitializeComponent();



            //Add initial tools (for demonstration purposes)
            tools.Add(new Tools(0, "Hammer", 15.99f, true));
            tools.Add(new Tools(1, "Hedge Trimmer", 39.99f, true));
            tools.Add(new Tools(2, "Trowel", 6.99f, true));
            tools.Add(new Tools(3, "Wheel Barrow", 32.89f, true));

            //Update the UI 
            RefreshTools(); 
        }

        private void RefreshTools()
        {
            //Clear the existing items
            listTools.ItemsSource = null;
            //Set the items source to the list of tools
            listTools.ItemsSource = tools;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAddTool_Click(object sender, RoutedEventArgs e)
        {
            string newToolName = txtToolName.Text;
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

            bool newIsAvailable = txtIsAvailable.IsChecked ?? false;

            var tool = new Tools(nextID++, newToolName, newToolPrice, newIsAvailable);
            tools.Add(tool);

            RefreshTools(); // Update the UI

            // Clear input fields
            txtToolName.Clear();
            txtToolPrice.Clear();
            txtIsAvailable.IsChecked = false;

            MessageBox.Show("Tool added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnDeleteRow_Click(object sender, RoutedEventArgs e)
        {
            if (listTools.SelectedIndex != -1)
            {
                tools.RemoveAt(listTools.SelectedIndex);
                RefreshTools(); // Update the UI after removing the tool
                MessageBox.Show("Tool removed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}