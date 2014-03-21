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
    /// Interaction logic for CookingLessonWhisking.xaml
    /// </summary>
    public partial class CookingLessonWhisking : UserControl
    {
        Recipe aRecipe;

        public CookingLessonWhisking(Recipe rec)
        {
            aRecipe = rec;
            InitializeComponent();

            txtBlkChapOverview.Text = "Here you will be learning about whisking!\r\n" +
                "Whisking is an essential skill that makes you a great baker\r\nand also determines the texture of final baked product.\r\n\r\n" +
                "In this tutorial, you will be learning how to:\r\n" +
                    "- Beat eggs\r\n" +
                    "- Mix flours\r\n" +
                    "- Not spill your ingredients\r\n"+
                    "- Use other kitchen tools to whisk\r\n" +
                    "- Determine dough consistancy";
        }

        private void btnLesBack_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipeOverview(aRecipe));
        }

        private void imgLessonIII_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Switcher.Switch(new CookingLessonFolding(aRecipe));
        }
    }
}
