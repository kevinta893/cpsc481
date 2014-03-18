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

        Database db;
        int numRecipes;
        List<Canvas> recipeBlocks;


        public RecipeSelectionMenu()
        {
            InitializeComponent();

            db = new Database();
            numRecipes = db.recipeList.Count();
            recipeBlocks = new List<Canvas>();

            // add recipe containers to a list
            recipeBlocks.Add(canvRecipe1);
            recipeBlocks.Add(canvRecipe2);
            recipeBlocks.Add(canvRecipe3);
            recipeBlocks.Add(canvRecipe4);

            LoadRecipes();
            
            //txtBlkRecipe1.Text = "Recipe Information"; //replace string with data from the recipe data class
            chkBxAll.Click += new RoutedEventHandler(chkBxAll_Click);
        }

        private void LoadRecipes()
        {
            Recipe rec;
            TextBlock txtBlock;

            for (int i = 0; i < numRecipes; i++)
            {
                rec = db.recipeList[i];
                txtBlock = (TextBlock) recipeBlocks[i].Children[0];

                txtBlock.Text = rec.Title;

            }
        }



        // *************************** control events below

        void chkBxAll_Click(object sender, RoutedEventArgs e)
        {
            CheckBox thisChbx = (CheckBox)sender;
            if (thisChbx.IsChecked == false)
            {
                canvRecipe1.Visibility = Visibility.Hidden;
                canvRecipe2.Visibility = Visibility.Hidden;
                canvRecipe3.Visibility = Visibility.Hidden;
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
        
        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
        #endregion

        private void brdrMPCimgPH_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipeOverview());
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

    }
}
