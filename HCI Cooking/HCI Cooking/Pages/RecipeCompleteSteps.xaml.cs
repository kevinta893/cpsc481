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
        Recipe aRecipe;
        RecipeOverview overview;
        RecipeIndividualSteps indivStep;          // used to go back to the previous indiv step if toggled again

        public RecipeCompleteSteps(RecipeOverview parentPage, RecipeIndividualSteps indivPage, Recipe rec)
        {
            InitializeComponent();

            overview = parentPage;
            indivStep = indivPage;
            aRecipe = rec;

            ShowAllSteps();
        }

        // show all the steps for the recipes from the list
        private void ShowAllSteps()
        {
            Paragraph paraRichtxt = new Paragraph();
            paraRichtxt.Inlines.Add("Instructions:\n\n");

            foreach (string step in aRecipe.Steps)
            {
                paraRichtxt.Inlines.Add(step + "\n"); //add steps in to the paragraph
            }

            rTxtBlkSteps.Document.Blocks.Add(paraRichtxt); //attach the paragraph to the rich textbox
        }


        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
        #endregion

        // go back to individual steps; same step as before
        private void btnCompToogleView_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(indivStep);
        }

        // go back to recipe overview page
        private void btnRecipeCompBack_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(overview);
        }
    }
}
