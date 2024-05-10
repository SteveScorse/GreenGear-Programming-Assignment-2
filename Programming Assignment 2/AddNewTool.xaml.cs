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

    public class MyViewModel : INotifyPropertyChanged
    {
        private bool _isFeatureEnabled;

        public bool IsFeatureEnabled
        {
            get { return _isFeatureEnabled; }
            set
            {
                _isFeatureEnabled = value;
                OnPropertyChanged(nameof(IsFeatureEnabled));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


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
            DataContext = new MyViewModel();

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
            //Assigns data from window inputs, to variables
            string newToolName = txtToolName.Text;
            float newToolPrice = float.Parse(txtToolPrice.Text);
            bool newIsAvailable = txtIsAvailable.IsChecked ?? false;

                //Creates an Object, then add them to the list
                var tool = new Tools(nextID++, newToolName, newToolPrice, newIsAvailable);
                tools.Add(tool);
                
                //Refreshes the list to update
                RefreshTools();
                
                //QoL, clears text boxes
                txtToolName.Clear();
                txtToolPrice.Clear();
                txtIsAvailable.IsChecked = false;


        }

        private void btnDeleteRow_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
