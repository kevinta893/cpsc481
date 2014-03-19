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

namespace HCI_Cooking.Pages
{
    /// <summary>
    /// Interaction logic for RecipeSelectionMenu.xaml
    /// </summary>
    public partial class RecipeSelectionMenu : ISwitchable
    {

        Database recipeDB;
        int numRecipes;
        List<Canvas> recipeBlocks;      // a list of the GUI recipe containers


        public RecipeSelectionMenu()
        {
            InitializeComponent();
<<<<<<< HEAD
            txtBlkMPCDesc.Text = "Recipe Information"; //replace string with data from the recipe data class
            chkBxAll.Click += new RoutedEventHandler(chkBxAll_Click);
        }

=======

            recipeDB = new Database();
            numRecipes = recipeDB.recipeList.Count();
            recipeBlocks = new List<Canvas>();

            // add recipe containers to a list
            recipeBlocks.Add(canvRecipe1);
            recipeBlocks.Add(canvRecipe2);
            recipeBlocks.Add(canvRecipe3);
            recipeBlocks.Add(canvRecipe4);

            LoadRecipes();

            canvRecipe1.MouseLeftButtonDown += new MouseButtonEventHandler(recipeClick_MouseLeftButtonDown);
            canvRecipe2.MouseLeftButtonDown += new MouseButtonEventHandler(recipeClick_MouseLeftButtonDown);
            canvRecipe3.MouseLeftButtonDown += new MouseButtonEventHandler(recipeClick_MouseLeftButtonDown);
            canvRecipe4.MouseLeftButtonDown += new MouseButtonEventHandler(recipeClick_MouseLeftButtonDown);


            chkBxAll.Click += new RoutedEventHandler(chkBxAll_Click);
        }


        private void LoadRecipes()
        {
            Recipe rec;
            TextBlock txtBlk;

            for (int i = 0; i < numRecipes; i++)
            {
                rec = recipeDB.recipeList[i];
                txtBlk = (TextBlock)recipeBlocks[i].Children[0];

                txtBlk.Text = rec.Title; //gets and displays title of the recipe
                txtBlk.Text += rec.Description;
                txtBlk.Text += "\nCooking Time: " + rec.CookTime;

            }
        }


        // Event controllers

        /*
         * Event handler for the check all checkbox
         * If the All checkbox is checked then all recipes will be visible,
         * if it's not checked then no recipes will be shown
         * 
         */ 
>>>>>>> origin/recipe-loading-logic
        void chkBxAll_Click(object sender, RoutedEventArgs e)
        {
            CheckBox thisChbx = (CheckBox)sender;
            if (thisChbx.IsChecked == false)
            {
<<<<<<< HEAD
                canvRibs.Visibility = Visibility.Hidden;
                canvMangoPuddingCake.Visibility = Visibility.Hidden;
                canvPowChicken.Visibility = Visibility.Hidden;
                canvSpringRolls.Visibility = Visibility.Hidden;
            }
            else
            {
                canvRibs.Visibility = Visibility.Visible;
                canvMangoPuddingCake.Visibility = Visibility.Visible;
                canvPowChicken.Visibility = Visibility.Visible;
                canvSpringRolls.Visibility = Visibility.Visible;
=======
                canvRecipe1.Visibility = Visibility.Hidden; //hides first recipe box
                canvRecipe2.Visibility = Visibility.Hidden; //hides second recipe box
                canvRecipe3.Visibility = Visibility.Hidden; //...
                canvRecipe4.Visibility = Visibility.Hidden;
            }
            else
            {
                canvRecipe1.Visibility = Visibility.Visible;
                canvRecipe2.Visibility = Visibility.Visible;
                canvRecipe3.Visibility = Visibility.Visible;
                canvRecipe4.Visibility = Visibility.Visible;
>>>>>>> origin/recipe-loading-logic
            }
        }
        
        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
        #endregion

<<<<<<< HEAD
        private void brdrMPCimgPH_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipeOverview());
        }

=======
        //Event handler for recipe click
        // Open new recipe overview page for that recipe
        void recipeClick_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Canvas clickedRecipe = (Canvas)sender;

            if (clickedRecipe == canvRecipe1)
                Switcher.Switch(new RecipeOverview(recipeDB.recipeList[0]));
            else if (clickedRecipe == canvRecipe2)
                Switcher.Switch(new RecipeOverview(recipeDB.recipeList[1]));
            else if (clickedRecipe == canvRecipe3)
                Switcher.Switch(new RecipeOverview(recipeDB.recipeList[2]));
            else if (clickedRecipe == canvRecipe4)
                Switcher.Switch(new RecipeOverview(recipeDB.recipeList[3]));

        }


>>>>>>> origin/recipe-loading-logic
        private void btnRSMBack_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainMenu());
        }

        private void chkbxMixing_Checked(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            canvRibs.Visibility = Visibility.Hidden;
=======
            canvRecipe1.Visibility = Visibility.Hidden;
>>>>>>> origin/recipe-loading-logic
            chkBxAll.IsChecked = false;
        }

        private void chkbxMixing_Unchecked(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            canvRibs.Visibility = Visibility.Visible;
=======
            canvRecipe1.Visibility = Visibility.Visible;
>>>>>>> origin/recipe-loading-logic
        }

    }
}
