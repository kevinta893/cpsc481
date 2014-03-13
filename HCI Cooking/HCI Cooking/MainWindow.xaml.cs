using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;


namespace HCI_Cooking
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

        private Random r = new Random();

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            label1.Margin = new Thickness(r.Next(400), r.Next(230), 0, 0);

        }

        // PB just testing a commit!
    }
    
    
}
