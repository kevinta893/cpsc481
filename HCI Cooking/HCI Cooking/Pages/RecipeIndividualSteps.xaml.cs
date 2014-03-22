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
using System.Drawing;


namespace HCI_Cooking.Pages
{
    /// <summary>
    /// Interaction logic for RecipeIndividualSteps.xaml
    /// </summary>
    public partial class RecipeIndividualSteps : ISwitchable
    {
        RecipeOverview overview;
        Recipe aRecipe;
        Database userDb;
        User mainUser;
        int stepIndex;
        int lastStep;

        public RecipeIndividualSteps(RecipeOverview parentPage, Recipe rec)
        {
            InitializeComponent();

            overview = parentPage;
            aRecipe = rec;

            userDb = Database.getInstance();
            mainUser = userDb.userList[0];

            // load first step
            stepIndex = 0;
            lastStep = aRecipe.Steps.Count() - 1;
            txtBlkStep.Text = aRecipe.Steps[stepIndex];

            // load picture if exists
            if (aRecipe.StepPictures.Count == lastStep + 1)
                imgStep.Source = ImageLoader.ToWPFImage(aRecipe.StepPictures[stepIndex]);
            else
                imgStep.Source = ImageLoader.ToWPFImage(HCI_Cooking.Properties.Resources.placeholder);
        }



        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
        #endregion

        // switch to view complete instructions view; pass in current view and previous view to go back
        private void btnIndiToogleView_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipeCompleteSteps(overview, this, aRecipe));
        }

        // go back one step
        private void btnIndivRecipeBack_Click(object sender, RoutedEventArgs e)
        {
            // only go back step if not currently on first step
            if (stepIndex != 0)
            {
                // change next button to "active" if it was on last step
                if (stepIndex == lastStep)
                {
                    btnIndivRecipeNext.IsEnabled = true;

                }

                stepIndex--;
                txtBlkStep.Text = aRecipe.Steps[stepIndex];
                // load picture if exists
                if (aRecipe.StepPictures.Count == lastStep + 1)
                    imgStep.Source = ImageLoader.ToWPFImage(aRecipe.StepPictures[stepIndex]);
            
                // change previous button colour to "inactive" if now on first step
                if (stepIndex == 0)
                {
                    btnIndivRecipePrev.IsEnabled = false;
                }
            }
        }

        // go forward one step
        private void btnIndivRecipeNext_Click(object sender, RoutedEventArgs e)
        {
            bool hasAchievement = false;

            // only go forward step if not currently on last step
            if (stepIndex != lastStep)
            {
                // change previous button to "active" if it was on first step
                if (stepIndex == 0)
                {
                    btnIndivRecipePrev.IsEnabled = true;
                }

                stepIndex++;
                txtBlkStep.Text = aRecipe.Steps[stepIndex];
                // load picture if exists
                if (aRecipe.StepPictures.Count == lastStep + 1)
                    imgStep.Source = ImageLoader.ToWPFImage(aRecipe.StepPictures[stepIndex]);
                else
                    imgStep.Source = ImageLoader.ToWPFImage(HCI_Cooking.Properties.Resources.placeholder);

                // change next button colour to "inactive" if now on last step
                if (stepIndex == lastStep)
                {
                    btnIndivRecipeNext.IsEnabled = false;
                    
                    //checks to see if the user has gain this achievement yet
                    foreach (string badge in mainUser.Accomplishments)
                    {
                        if (badge == "First Mango Pudding!")
                        {
                            hasAchievement = true;
                        }
                    }

                    if (hasAchievement == false)
                    {
                        mainUser.Accomplishments.Add("First Mango Pudding!");
                        mainUser.BadgeImages.Add(new Bitmap(HCI_Cooking.Properties.Resources.mango_cake));
                        mainUser.BadgesEarned += 1;
                        MessageBox.Show("New achievement!");
                    }

                    mainUser.MealsCooked += 1;

                }
            }

        }

        // go back to previous recipe overview
        private void btnRecipeIndivBack_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(overview);
        }
    }
}
