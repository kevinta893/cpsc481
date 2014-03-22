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
        Database userDb;
        User mainUser; 

        public CookingLessonWhisking(Recipe rec)
        {
            aRecipe = rec;
            userDb = Database.getInstance();
            mainUser = userDb.userList[0];

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
            bool hasLearntLesson = false;

            foreach (string skill in mainUser.KnownSkills)
            {
                if (skill == "Whisking")
                {
                    hasLearntLesson = true;
                }
            }

            if (hasLearntLesson == false)
            {
                mainUser.KnownSkills.Add("Whisking");
                mainUser.LessonsLearnt += 1;
            }

            Switcher.Switch(new RecipeOverview(aRecipe));
        }

        private void imgLessonIII_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            bool hasLearntLesson = false;

            foreach (string skill in mainUser.KnownSkills)
            {
                if (skill == "Whisking")
                {
                    hasLearntLesson = true;
                }
            }

            if (hasLearntLesson == false)
            {
                mainUser.KnownSkills.Add("Whisking");
                mainUser.LessonsLearnt += 1;
            }

            Switcher.Switch(new CookingLessonFolding(aRecipe));
        }
    }
}
