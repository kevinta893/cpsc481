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

        // constructor
        public RecipeSelectionMenu()
        {
            InitializeComponent();

            recipeDB = new Database();
            numRecipes = recipeDB.recipeList.Count();
            recipeBlocks = new List<Canvas>();

            // add recipe containers to a list
            recipeBlocks.Add(canvRecipe1);
            recipeBlocks.Add(canvRecipe2);
            recipeBlocks.Add(canvRecipe3);
            recipeBlocks.Add(canvRecipe4);

            LoadRecipes();

            // set click event for the recipe containers
            canvRecipe1.MouseLeftButtonDown += new MouseButtonEventHandler(recipeClick_MouseLeftButtonDown);
            canvRecipe2.MouseLeftButtonDown += new MouseButtonEventHandler(recipeClick_MouseLeftButtonDown);
            canvRecipe3.MouseLeftButtonDown += new MouseButtonEventHandler(recipeClick_MouseLeftButtonDown);
            canvRecipe4.MouseLeftButtonDown += new MouseButtonEventHandler(recipeClick_MouseLeftButtonDown);

            //CheckBoxLogic();
            chkBxAll.Click += new RoutedEventHandler(chkBxAll_Click);
        }


        // load the 4 recipes into the recipe containers
        private void LoadRecipes()
        {
            Recipe rec;
            TextBlock txtBlk;
            Border brdr;
            Image img;

            for (int i = 0; i < numRecipes; i++)
            {
                rec = recipeDB.recipeList[i];
                txtBlk = (TextBlock)recipeBlocks[i].Children[0];
                brdr = (Border)recipeBlocks[i].Children[1];
                img = (Image)recipeBlocks[i].Children[2];

                txtBlk.Text = rec.Title; //gets and displays title of the recipe
                txtBlk.Text += rec.Description;
                txtBlk.Text += "\nCooking Time: " + rec.CookTime;

                // set border colour depending on difficulty
                switch (rec.Difficulty)
                {
                    case 1:
                        brdr.BorderBrush = Brushes.Green;
                        break;
                    case 2:
                        brdr.BorderBrush = Brushes.Yellow;
                        break;
                    case 3:
                        brdr.BorderBrush = Brushes.Red;
                        break;
                    default:
                        brdr.BorderBrush = Brushes.SlateGray;
                        break;
                }

                // load main picture for recipe
                img.Source = ImageLoader.ToWPFImage(rec.MainPicture);
            }
        }


        // the logic for the checkbox filtering
        private void CheckBoxLogic()
        {
            throw new NotImplementedException();
        }


// ***********Event controllers******
        /*
         * Event handler for the check all checkbox
         * If the All checkbox is checked then all recipes will be visible,
         * if it's not checked then no recipes will be shown
         */ 
        void chkBxAll_Click(object sender, RoutedEventArgs e)
        {
            CheckBox thisChbx = (CheckBox)sender;
            if (thisChbx.IsChecked == false)
            {
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
            }
        }


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


        private void btnRSMBack_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainMenu());
        }

        private void chkbxMixing_Checked(object sender, RoutedEventArgs e)
        {
            canvRecipe1.Visibility = Visibility.Hidden;
            chkBxAll.IsChecked = false;
        }

        private void chkbxMixing_Unchecked(object sender, RoutedEventArgs e)
        {
            canvRecipe1.Visibility = Visibility.Visible;
        }


        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
