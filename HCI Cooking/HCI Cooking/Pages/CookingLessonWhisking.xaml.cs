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
        public CookingLessonWhisking()
        {
            InitializeComponent();
        }

        private void btnLesBack_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            Switcher.Switch(new RecipeOverview());
=======
            //Switcher.Switch(new RecipeOverview());
>>>>>>> origin/recipe-loading-logic
        }

        private void imgLessonIII_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Switcher.Switch(new CookingTechniqueLessons());
        }
    }
}
