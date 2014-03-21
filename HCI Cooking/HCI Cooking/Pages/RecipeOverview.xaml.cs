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

            // display ingredients list
            for (int i = 0; i < currentRecipe.Ingredients.Count(); i++)
            {
                paraIngred.Inlines.Add(currentRecipe.Ingredients[i]);
               
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
                paraTools.Inlines.Add(currentRecipe.Tools[i]);
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
            txtBlkDescr.Text = "Difficulty: " + diffLevel + "\n";

            // display description
            txtBlkDescr.Text += currentRecipe.Description;
            txtBlkDescr.Text += "\nCooking Time: "+currentRecipe.CookTime;
            
            // display main picture
            imgRecOverview.Source = ImageLoader.ToWPFImage(currentRecipe.MainPicture);
        }

        // load the required skills needed for this recipe
        // TO DO (maybe): -currently this can load 0-4 skills. anymore will cause an issue.
        //                to fix, will have to create the container in code rather than XAML so it can be generated on the fly.
        //                - also, the folding and whisking pages are explictly set. anything else shows not implemented skills popup.
        private void LoadRecipeSkills()
        {
            Grid grdSkill;
            Image imgSkill = null;
            Label lblSkill = null;
            Button btnSkill = null;

            // show skill containers
            for (int i = 0; i < currentRecipe.Skills.Count(); i++)
            {
                grdSkill = (Grid) grdSkillsNeeded.Children[i];

                // get pointers for each skill item
                for (int item = 0; item < grdSkill.Children.Count; item++)
                {
                    if (grdSkill.Children[item] is Image)
                        imgSkill = (Image)grdSkill.Children[item];
                    else if (grdSkill.Children[item] is Label)
                        lblSkill = (Label)grdSkill.Children[item];
                    else if (grdSkill.Children[item] is Button)
                        btnSkill = (Button)grdSkill.Children[item];
                }
                grdSkillsNeeded.Children[i].Visibility = Visibility.Visible;

                // load skill items
          // ****TODO: check if skill is done and load checkmark here
                //imgSkill = ImageLoader.ToWPFImage(something here);
                lblSkill.Content = currentRecipe.Skills[i];

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
            Switcher.Switch(new CookingLessonFolding(currentRecipe));
        }

        // show whisking tutorial
        private void btnWhiskPlay_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new CookingLessonWhisking(currentRecipe));
        }

        // this skill has not been implemented yet!
        void btnSkill_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sorry, this skill tutorial has not been implemented yet!");
        }

        // go back to recipe selection screen
        private void btnRecipeOverviewBack_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipeSelectionMenu());
        }

    }
}
