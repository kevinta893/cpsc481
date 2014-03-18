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

namespace HCI_Cooking.Pages
{
    /// <summary>
    /// Interaction logic for RecipeCompleteSteps.xaml
    /// </summary>
    public partial class RecipeCompleteSteps : ISwitchable
    {
        public RecipeCompleteSteps()
        {
            InitializeComponent();
        }


        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
        #endregion

        private void btnCompToogleView_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipeIndividualSteps());
        }

        private void btnRecipeCompBack_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipeOverview());
        }
    }
}
