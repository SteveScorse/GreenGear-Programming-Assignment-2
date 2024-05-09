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
    /// Interaction logic for AddNewTool.xaml
    /// </summary>
    public partial class AddNewTool : Window
    {
        //create list to store objects
        private List<Tools> tools = new List<Tools>();
        //used for object ID
        private int nextID = 0;
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
            string newToolName = txtToolName.Text;
            float newToolPrice = float.Parse(txtToolPrice.Text);
            bool newIsAvailable = bool.Parse(txtIsAvailable.Name);

            if ((newToolName) == null && newToolPrice < 0)
            {
                var tool = new Tools(nextID++, newToolName, newToolPrice, newIsAvailable);
                tools.Add(tool);
                RefreshTools();

                txtToolName.Clear();
                txtToolPrice.Clear();
                
            }
        }

        private void btnDeleteRow_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
