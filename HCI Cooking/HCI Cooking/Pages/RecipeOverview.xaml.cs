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
        Recipe currentRecipe;

        public RecipeOverview(Recipe rec)
        {
            InitializeComponent();

            currentRecipe = rec;

            LoadRecipeValues();
        }

        // load in the values from the recipe
        private void LoadRecipeValues()
        {
            lblTitle.Content = currentRecipe.Title;

            // display ingredients list
            for (int i = 0; i < currentRecipe.Ingredients.Count(); i++)
            {
                txtBlkIngred.Text += "\n" + currentRecipe.Ingredients[i];
            }

            // disaply tools list
            for (int i = 0; i < currentRecipe.Tools.Count(); i++)
            {
                txtBlkTools.Text += "\n" + currentRecipe.Tools[i];
            }

            // display description
            txtBlkDescr.Text = currentRecipe.Description;
           

        }


        //********************** Event handlers below *******


        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
        #endregion

        // go to the individual steps
        private void btnStartCooking_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipeIndividualSteps(this, currentRecipe));
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
