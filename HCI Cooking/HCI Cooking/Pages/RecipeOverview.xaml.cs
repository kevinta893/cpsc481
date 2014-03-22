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

/*
 * This is a page that displays detailed information about a recipe
 * Users can click the skill tutorials or start the recipe.
 */ 

namespace HCI_Cooking.Pages
{
    public partial class RecipeOverview : ISwitchable
    {
        Recipe currentRecipe;
        Database userDb;
        User mainUser;
        RecipeSelectionMenu selectionMenu;

        public RecipeOverview(Recipe rec, RecipeSelectionMenu previousMenu)
        {
            userDb = Database.getInstance();
            mainUser = userDb.userList[0];
         
            InitializeComponent();

            currentRecipe = rec;
            selectionMenu = previousMenu;

            LoadRecipeValues();
            LoadRecipeSkills();
        }

        // load in the values from the recipe
        private void LoadRecipeValues()
        {
            Paragraph paraIngred = new Paragraph();
            Paragraph paraTools = new Paragraph();

            lblTitle.Content = currentRecipe.Title;

            /*
             * Gathering and displaying Ingredients 
             * in the rich text box.
             */
            rtxtbxIngred.AppendText("Ingredients:");
            //paraIngred.Inlines.Add("Ingredients:\n");     // cannot get rid of newline between ingredients and list :(


            // display ingredients list
            for (int i = 0; i < currentRecipe.Ingredients.Count(); i++)
            {
                paraIngred.Inlines.Add("   " + currentRecipe.Ingredients[i]);
                //rtxtbxIngred.AppendText("   " + currentRecipe.Ingredients[i]);
               
            }
            rtxtbxIngred.Document.Blocks.Add(paraIngred);


            /*
             * Gathering and displaying the list 
             * of tools for that specific recipe.
             */
            rtxtBlkTools.AppendText("Tools:");

            // disaply tools list
            for (int i = 0; i < currentRecipe.Tools.Count(); i++)
            {
                paraTools.Inlines.Add("   " + currentRecipe.Tools[i]);
            }

            rtxtBlkTools.Document.Blocks.Add(paraTools);

            // calculate and display difficulty level
            String diffLevel;
            switch (currentRecipe.Difficulty)
            {
                case 1:
                    diffLevel = "Easy";
                    break;
                case 2:
                    diffLevel = "Medium";
                    break;
                default:
                    diffLevel = "Hard";
                    break;
            }


            // display description
            txtBlkDescr.Text = currentRecipe.Description;

            txtBlkDescr.Text += "\nCooking Time: "+currentRecipe.CookTime;
            txtBlkDescr.Text += "\nDifficulty: " + diffLevel;
            
            // display main picture
            imgRecOverview.Source = ImageLoader.ToWPFImage(currentRecipe.MainPicture);
        }

        // load the required skills needed for this recipe
        // TO DO (future): -currently this can load 0-4 skills. anymore will cause an issue.
        //                to fix, will have to create the container in code rather than XAML so it can be generated on the fly.
        private void LoadRecipeSkills()
        {
            Grid grdSkill;
            System.Windows.Controls.Image imgSkill = null;
            Label lblSkill = null;
            Button btnSkill = null;

            // show skill containers
            for (int i = 0; i < currentRecipe.Skills.Count(); i++)
            {
                grdSkill = (Grid) grdSkillsNeeded.Children[i];

                // get pointers for each skill item
                for (int item = 0; item < grdSkill.Children.Count; item++)
                {
                    if (grdSkill.Children[item] is System.Windows.Controls.Image)
                        imgSkill = (System.Windows.Controls.Image)grdSkill.Children[item];
                    else if (grdSkill.Children[item] is Label)
                        lblSkill = (Label)grdSkill.Children[item];
                    else if (grdSkill.Children[item] is Button)
                        btnSkill = (Button)grdSkill.Children[item];
                }
                grdSkillsNeeded.Children[i].Visibility = Visibility.Visible;

                // load skill items
                //skill image is default to cross
                imgSkill.Source = ImageLoader.ToWPFImage(new Bitmap(HCI_Cooking.Properties.Resources.red_cross));
                lblSkill.Content = currentRecipe.Skills[i];
                for(int j = 0; j < mainUser.KnownSkills.Count(); j++)
                {
                    // change to check if user knows skill
                    if (currentRecipe.Skills[i] == mainUser.KnownSkills[j])
                    {
                        imgSkill.Source = ImageLoader.ToWPFImage(new Bitmap(HCI_Cooking.Properties.Resources.green_check));
                    }
                }

                // go to correct skill page, only folding and whisking implemented atm
                if (currentRecipe.Skills[i].Equals("Folding"))
                    btnSkill.Click += new RoutedEventHandler(btnFoldPlay_Click);
                else if (currentRecipe.Skills[i].Equals("Whisking"))
                    btnSkill.Click += new RoutedEventHandler(btnWhiskPlay_Click);
                else
                    btnSkill.Click += new RoutedEventHandler(btnSkill_Click);
            }

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

        // show folding tutorial
        private void btnFoldPlay_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new CookingLessonFolding(selectionMenu, currentRecipe));
        }

        // show whisking tutorial
        private void btnWhiskPlay_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new CookingLessonWhisking(selectionMenu, currentRecipe));
        }

        // this skill has not been implemented yet!
        // send the user to a lesson template that states its not implemented yet
        void btnSkill_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new CookingLessonTemplate(selectionMenu, currentRecipe));
        }

        // go back to recipe selection screen
        private void btnRecipeOverviewBack_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(selectionMenu);
        }

    }
}
