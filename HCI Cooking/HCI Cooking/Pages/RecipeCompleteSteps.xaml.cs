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
using System.Threading;

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
        Database userDb;
        User mainUser;

        public RecipeCompleteSteps(RecipeOverview parentPage, RecipeIndividualSteps indivPage, Recipe rec)
        {
            InitializeComponent();
            canvAchievement.Opacity = 0;

            overview = parentPage;
            indivStep = indivPage;
            aRecipe = rec;
            userDb = Database.getInstance();
            mainUser = userDb.userList[0];
            lblTitle.Content = aRecipe.Title;

            //load the only achievment on this page
            imgAchievement.Source = ImageLoader.ToWPFImage(new Bitmap(HCI_Cooking.Properties.Resources.mango_cake));
            lblAchievementContent.Content = "First Mango Pudding!";

            ShowAllSteps();
        }

        // show all the steps for the recipes from the list
        private void ShowAllSteps()
        {
            Paragraph paraRichtxt = new Paragraph();
            paraRichtxt.Inlines.Add("Instructions:\n");

            foreach (string step in aRecipe.Steps)
            {
                paraRichtxt.Inlines.Add(step + "\n"); //add steps in to the paragraph
            }

            rTxtBlkSteps.Document.Blocks.Add(paraRichtxt); //attach the paragraph to the rich textbox


            // check for acheivements

            bool hasAchievement = false;

            foreach (string badge in mainUser.Accomplishments)
            {
                if (badge == "First Mango Pudding!")
                {
                    hasAchievement = true;
                }
            }

            if (hasAchievement == false && aRecipe.Title.Equals("Mango Pudding Cake"))
            {
                mainUser.Accomplishments.Add("First Mango Pudding!");
                mainUser.BadgeImages.Add(new Bitmap(HCI_Cooking.Properties.Resources.mango_cake));
                mainUser.BadgesEarned += 1;

                //show achivement once.
                Thread achieveShow = new Thread(new ThreadStart(achievmentShow));
                achieveShow.Start();
            }
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
            mainUser.MealsCooked += 1;
            Switcher.Switch(overview);
        }


        private void achievmentShow()
        {
            int[] delays = { 30, 30, 30, 20, 10, 10, 10, 30, 30, 30, 30 };

            double opacity_step = (double)1 / (double)delays.Length;
            double opacity = 0;
            for (int i = 0; i < delays.Length; i++)
            {

                Thread.Sleep(delays[i]);
                opacity += opacity_step;
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    canvAchievement.Opacity = opacity;
                }));

            }

            Thread.Sleep(3000);

            for (int i = 0; i < delays.Length; i++)
            {

                Thread.Sleep(delays[i]);
                opacity -= opacity_step;
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    canvAchievement.Opacity = opacity;
                }));

            }
        }
    }
}
