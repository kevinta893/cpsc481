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
    /// Interaction logic for RecipeOverview.xaml
    /// </summary>
    public partial class RecipeOverview : ISwitchable
    {
        public RecipeOverview()
        {
            InitializeComponent();
        }


        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
        #endregion
        private void btnStartCooking_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipeIndividualSteps());
        }

        private void btnMixPlay_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new CookingTechniqueLessons()); //we can change the page navigation to Mix Lesson later
        }

        private void btnDecoPlay_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new CookingTechniqueLessons());
        }

        private void btnFoldPlay_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new CookingTechniqueLessons());
        }

        private void btnWhiskPlay_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new CookingLessonWhisking());
        }

        private void btnRecipeOverviewBack_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipeSelectionMenu());
        }

    }
}
