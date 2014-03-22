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
using System.Drawing;

namespace HCI_Cooking.Pages
{
    /// <summary>
    /// Interaction logic for CookingLessonWhisking.xaml
    /// </summary>
    public partial class CookingLessonWhisking : UserControl
    {
        Recipe currentRecipe;
        Database userDb;
        User mainUser; 

        public CookingLessonWhisking(Recipe rec)
        {
            currentRecipe = rec;
            userDb = Database.getInstance();
            mainUser = userDb.userList[0];

            InitializeComponent();
            lblMPCRecipeTitle.Content = rec.Title;

            txtBlkChapOverview.Text = "Here you will be learning about whisking!\r\n" +
                "Whisking is an essential skill that makes you a great baker\r\nand also determines the texture of final baked product.\r\n\r\n" +
                "In this tutorial, you will be learning how to:\r\n" +
                    "- Beat eggs\r\n" +
                    "- Mix flours\r\n" +
                    "- Not spill your ingredients\r\n"+
                    "- Use other kitchen tools to whisk\r\n" +
                    "- Determine dough consistancy";
            loadLessonTable();
        }

        private void loadLessonTable()
        {
            Grid lessonGrid;
            System.Windows.Controls.Image lessonImg = null;
            Label lessonLabel = null;
            Button lessonButton = null;

            for (int i = 0; i < currentRecipe.Skills.Count(); i++)
            {
                lessonGrid = (Grid)grdLessonsTable.Children[i];

                for (int item = 0; item < lessonGrid.Children.Count; item++)
                {
                    if (lessonGrid.Children[item] is System.Windows.Controls.Image)
                    {
                        lessonImg = (System.Windows.Controls.Image)lessonGrid.Children[item];
                    }
                    else if (lessonGrid.Children[item] is Label)
                    {
                        lessonLabel = (Label)lessonGrid.Children[item];
                    }
                    else if (lessonGrid.Children[item] is Button)
                    {
                        lessonButton = (Button)lessonGrid.Children[item];
                        if (currentRecipe.Skills[i] == "Whisking")
                        {
                            lessonButton.Visibility = Visibility.Hidden;
                        }
                    }

                }
                grdLessonsTable.Children[i].Visibility = Visibility.Visible;

                lessonImg.Source = ImageLoader.ToWPFImage(new Bitmap(HCI_Cooking.Properties.Resources.red_cross));
                lessonLabel.Content = currentRecipe.Skills[i];

                for (int k = 0; k < mainUser.KnownSkills.Count; k++)
                {
                    if (currentRecipe.Skills[i] == mainUser.KnownSkills[k])
                    {
                        lessonImg.Source = ImageLoader.ToWPFImage(new Bitmap(HCI_Cooking.Properties.Resources.green_check));
                    }
                }

                //if the current skill is equal to folding, show an arrow pointing to it.
                if (currentRecipe.Skills[i] == "Whisking")
                {
                    lessonImg.Source = ImageLoader.ToWPFImage(new Bitmap(HCI_Cooking.Properties.Resources.arrow_right));
                }

                if (currentRecipe.Skills[i].Equals("Folding"))
                {
                    lessonButton.Click += new RoutedEventHandler(lessonButtonFold_Click);
                }
                else
                {
                    lessonButton.Click += new RoutedEventHandler(lessonButtonNI_Click);
                }
            }
        }

        private void  lessonButtonNI_Click(object sender, RoutedEventArgs e)
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

            Switcher.Switch(new CookingLessonTemplate(currentRecipe));
        } 

        private void  lessonButtonFold_Click(object sender, RoutedEventArgs e)
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

            Switcher.Switch(new CookingLessonFolding(currentRecipe));
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

            Switcher.Switch(new RecipeOverview(currentRecipe));
        }

    }
}
