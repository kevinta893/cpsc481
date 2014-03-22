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
    /// Interaction logic for CookingLessonTemplate.xaml
    /// </summary>
    public partial class CookingLessonTemplate : UserControl
    {
        Recipe aRecipe;
        RecipeSelectionMenu selectMenu;

        public CookingLessonTemplate(RecipeSelectionMenu page, Recipe rec)
        {
            selectMenu = page;
            aRecipe = rec;
            InitializeComponent();
            lblRecipeTitle.Content = rec.Title;
        }

        private void btnLesBack_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipeOverview(aRecipe, selectMenu));
        }
    }
}
