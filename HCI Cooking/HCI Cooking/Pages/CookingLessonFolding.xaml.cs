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
    /// Interaction logic for CookingTechniqueLessons.xaml
    /// </summary>
    public partial class CookingLessonFolding : ISwitchable
    {
        Recipe currentRecipe;

        public CookingLessonFolding(Recipe rec)
        {
            currentRecipe = rec;
            InitializeComponent();

            txtBlkChapOverview.Text = "Folding is the process of both removing air bubbles from\r\n your dough and mixing ingredients together. " +
                "This is a \r\ndifferent process from mixing because removing air bubbles\r\nrequires a different mixing technique for ingredients that\r\ntend to froth more if mixed intensely.\r\n\r\n" + 
                "In this tutorial, you will learn how to: \r\n" +
                "- Why we remove bubbles from your baking mixture\r\n" +
                "- The technique of removing air bubbles from your mixture\r\n" +
                "- Advanced tips\r\n";
        }


        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
        #endregion

        private void btnLesBack_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipeOverview(currentRecipe)); //by default I have set this to recipe overview. 
                                                 
        }

        private void imgLessonIV_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Switcher.Switch(new CookingLessonWhisking(currentRecipe));
        }

    }
}
