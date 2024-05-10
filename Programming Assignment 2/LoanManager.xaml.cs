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
        public LoanManager()
        {
            InitializeComponent();
            // Assuming you want to access 'tools' list from AddNewTool
            AddNewTool addNewToolWindow = new AddNewTool();

            // Access the 'tools' list using the public property 'ToolsList'
            List<Tools> toolsList = addNewToolWindow.ToolsList;

            //Assigns Tools from the list to comboBox
            comboBoxTools.Items.Clear();
            comboBoxTools.ItemsSource = toolsList;


        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }

        private void btnAddTool_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnDeleteRow_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
