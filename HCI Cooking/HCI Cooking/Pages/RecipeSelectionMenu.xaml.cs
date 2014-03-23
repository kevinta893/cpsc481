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
using HCI_Cooking;


/*
 * This is the page where users can choose a recipe.
 * The sidebar has checkboxs to filter the recipes based on skills.
 */

namespace HCI_Cooking.Pages
{

    public partial class RecipeSelectionMenu : ISwitchable
    {
        Database recipeDB;
        int numRecipes;
        List<Canvas> recipeBlocks;      // a list of the GUI recipe containers
        List<String> activeFilters;
        List<CheckBox> checkList;

        // constructor
        public RecipeSelectionMenu()
        {
            InitializeComponent();

            recipeDB = Database.getInstance();
            numRecipes = recipeDB.recipeList.Count();
            recipeBlocks = new List<Canvas>();
            activeFilters = new List<String>();
            checkList = new List<CheckBox>();

            // add recipe containers to a list
            recipeBlocks.Add(canvRecipe1);
            recipeBlocks.Add(canvRecipe2);
            recipeBlocks.Add(canvRecipe3);
            recipeBlocks.Add(canvRecipe4);

            // add all skill checkboxes to a list
            checkList.Add(chkbxBread);
            checkList.Add(chkbxDeco);
            checkList.Add(chkBxDeglaze);
            checkList.Add(chkBxDegrease);
            checkList.Add(chkbxFolding);
            checkList.Add(chkbxGlaze);
            checkList.Add(chkBxKneeding);
            checkList.Add(chkbxMarinate);
            checkList.Add(chkbxMixing);
            checkList.Add(chkBxWhisking);

            // assign and load all recipes
            for (int i = 0; i < numRecipes; i++)
                recipeDB.recipeList[i].ID = i;
            LoadRecipes(numRecipes);

            LoadHandlers();
            
        }


        // load recipes into the recipe containers
        // the number loaded depends on the filters
        // this function assumes that the proper IDs are set in the database already
        private void LoadRecipes(int numToLoad)
        {
            Recipe rec;
            Label lbl;
            TextBlock txtBlk;
            Border brdr;
            Image img;
            String difficulty = "";

            // clear all containers to begin with
            foreach (Canvas block in recipeBlocks)
            {
                block.Visibility = Visibility.Hidden;
            }

            // load the given number of recipes accord to their id;
            for (int i = 0; i < numToLoad; i++)
            {
                rec = recipeDB.GetRecipe(i);        // get recipe by ID
                brdr = (Border)recipeBlocks[i].Children[0];
                lbl = (Label)recipeBlocks[i].Children[1];
                txtBlk = (TextBlock)recipeBlocks[i].Children[2];
                img = (Image)recipeBlocks[i].Children[3];

                // set border colour depending on difficulty
                switch (rec.Difficulty)
                {
                    case 1:
                        brdr.BorderBrush = Brushes.LightGreen;
                        difficulty = "Easy";
                        break;
                    case 2:
                        brdr.BorderBrush = Brushes.Yellow;
                        difficulty = "Medium";
                        break;
                    case 3:
                        brdr.BorderBrush = Brushes.Red;
                        difficulty = "Hard";
                        break;
                    default:
                        brdr.BorderBrush = Brushes.SlateGray;
                        difficulty = "";
                        break;
                }

                lbl.Content = rec.Title; //gets and displays title of the recipe
                txtBlk.Text = rec.Description;
                txtBlk.Text += "\n\t\t\t\tCooking Time: " + rec.CookTime;
                txtBlk.Text += "\n\t\t\t\tDifficulty Level: " + difficulty;

                

                // load main picture for recipe
                img.Source = ImageLoader.ToWPFImage(rec.MainPicture);

                // show recipe block
                recipeBlocks[i].Visibility = Visibility.Visible;
            }
        }


        // load event handlers
        private void LoadHandlers()
        {
            Image clickableArea;

            // click events for recipe containers
            foreach (Canvas block in recipeBlocks)
            {
                clickableArea = (Image)block.Children[3];
                clickableArea.MouseDown += new MouseButtonEventHandler(recipeClick_MouseLeftButtonDown);
            }

            // click events for skill checkboxes
            foreach (CheckBox box in checkList)
            {
                box.Click += new RoutedEventHandler(filterSkill_Click);
            }

            // check event for show-all box
            chkBxAll.Checked += new RoutedEventHandler(chkBxAll_Updated);
            chkBxAll.Unchecked += new RoutedEventHandler(chkBxAll_Updated);
        }


        // update the recipes shown to only include those in filter
        private void UpdateFiltering()
        {
            int id = 0;
            bool include;

            // check which recipes belong with current filters
            foreach (Recipe rec in recipeDB.recipeList)
            {
                include = true;
                // test all skills against the recipe
                foreach (String skill in activeFilters)
                {
                    if (!rec.Skills.Contains(skill))
                    {   // recipe does not contain this skill
                        include = false;
                        break;
                    }
                }
                // assign ID if recipe passes filter tesst
                if (include == true)
                {
                    rec.ID = id;
                    id++;
                }
                else
                    rec.ID = -1;
            }

            // load id # of recipes
            LoadRecipes(id);
        }

        // update the Show all checkbox depending on the current filters
        private void UpdateAllBox(string status)
        {
            // a skill filter is checked, so uncheck all box
            if (status.Equals("check"))
                chkBxAll.IsChecked = false;
            else
            {   // a skill filter unchecked, if it was last filter, recheck all box
                if (activeFilters.Count == 0)
                    chkBxAll.IsChecked = true;
            }


        }


// ***********Event controllers******
        /*
         * Event handler for the show-all checkbox
         * If the All checkbox is checked then all recipes will be visible,
         * if it's not checked then no recipes will be shown
         */ 
        void chkBxAll_Updated(object sender, RoutedEventArgs e)
        {
            // show-all got unchecked
            if (chkBxAll.IsChecked == false)
            {
                // get rid of all recipes by changing id to -1 
                foreach (Recipe rec in recipeDB.recipeList)
                {
                    rec.ID = -1;
                }

                // load 0 recipes (this gets rid of existing ones only)
                LoadRecipes(0);
            }
            else // show-all got checked
            {
                int index = 0;
                // set an ID value for all recipes
                foreach (Recipe rec in recipeDB.recipeList)
                {
                    rec.ID = index;
                    index++;
                }

                // load all recipes
                LoadRecipes(recipeDB.recipeList.Count());

                // uncheck all checkboxes
                foreach (CheckBox box in checkList)
                {
                    box.IsChecked = false;
                }
                activeFilters.Clear();
            }
        }


        // event handler when a user clicks on a skill checkbox
        // show recipes that only match ALL the filters applied
        void filterSkill_Click(object sender, RoutedEventArgs e)
        {
            CheckBox box = (CheckBox)sender;

            // box got checked
            if (box.IsChecked == true)
            {
                activeFilters.Add((String)box.Content);
                UpdateAllBox("check");
                UpdateFiltering();
            }
            else // box got unchecked
            {
                activeFilters.Remove((String)box.Content);
                UpdateAllBox("uncheck");
                UpdateFiltering();
            }

        }



        //Event handler for recipe click
        // Open new recipe overview page for that recipe
        void recipeClick_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image clickedRecipe = (Image)sender;

            if (clickedRecipe == img1)
                Switcher.Switch(new RecipeOverview(recipeDB.GetRecipe(0), this));
            else if (clickedRecipe == img2)
                Switcher.Switch(new RecipeOverview(recipeDB.GetRecipe(1), this));
            else if (clickedRecipe == img3)
                Switcher.Switch(new RecipeOverview(recipeDB.GetRecipe(2), this));
            else if (clickedRecipe == img4)
                Switcher.Switch(new RecipeOverview(recipeDB.GetRecipe(3), this));
        }


        private void btnRSMBack_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainMenu());
        }

        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
