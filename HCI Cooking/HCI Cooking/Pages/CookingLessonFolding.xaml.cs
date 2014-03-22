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
    /// Interaction logic for CookingTechniqueLessons.xaml
    /// </summary>
    public partial class CookingLessonFolding : ISwitchable
    {
        Recipe currentRecipe;
        Database userDb;
        User mainUser;
        RecipeSelectionMenu selectMenu;

        public CookingLessonFolding(RecipeSelectionMenu page, Recipe rec)
        {
            selectMenu = page;
            currentRecipe = rec;
            userDb = Database.getInstance();
            mainUser = userDb.userList[0];

            InitializeComponent();

            lblMPCRecipeTitle.Content = rec.Title;

            txtBlkChapOverview.Text = "Folding is the process of both removing air bubbles from\r\n your dough and mixing ingredients together. " +
                "This is a \r\ndifferent process from mixing because removing air bubbles\r\nrequires a different mixing technique for ingredients that\r\ntend to froth more if mixed intensely.\r\n\r\n" + 
                "In this tutorial, you will learn how to: \r\n" +
                "- Why we remove bubbles from your baking mixture\r\n" +
                "- The technique of removing air bubbles from your mixture\r\n" +
                "- Advanced tips\r\n";
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
                        if (currentRecipe.Skills[i] == "Folding")
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
                if (currentRecipe.Skills[i].Equals("Folding"))
                {
                    lessonImg.Source = ImageLoader.ToWPFImage(new Bitmap(HCI_Cooking.Properties.Resources.arrow_right));
                }

                if (currentRecipe.Skills[i].Equals("Whisking"))
                {
                    lessonButton.Click += new RoutedEventHandler(lessonButtonWhisk_Click);
                }
                else
                {
                    lessonButton.Click += new RoutedEventHandler(lessonButtonNI_Click);
                }
            }
        }

        void lessonButtonNI_Click(object sender, RoutedEventArgs e)
        {
            bool hasLearntLesson = false;

            //check to see if the user has learnt the skill yet
            foreach (string skill in mainUser.KnownSkills)
            {
                if (skill.Equals("Folding"))
                {
                    hasLearntLesson = true;
                }
            }

            //record the fact the user has learnt the new skill
            //increment their lessons learnt statistic
            if (hasLearntLesson == false)
            {
                mainUser.KnownSkills.Add("Folding");
                mainUser.LessonsLearnt += 1;
            }

            Switcher.Switch(new CookingLessonTemplate(selectMenu, currentRecipe));
        }

        void lessonButtonWhisk_Click(object sender, RoutedEventArgs e)
        {
            bool hasLearntLesson = false;

            foreach (string skill in mainUser.KnownSkills)
            {
                if (skill.Equals("Folding"))
                {
                    hasLearntLesson = true;
                }
            }

            if (hasLearntLesson == false)
            {
                mainUser.KnownSkills.Add("Folding");
                mainUser.LessonsLearnt += 1;
            }

            Switcher.Switch(new CookingLessonWhisking(selectMenu, currentRecipe));
        }

        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
        #endregion

        private void btnLesBack_Click(object sender, RoutedEventArgs e)
        {
            bool hasLearntLesson = false;

            foreach (string skill in mainUser.KnownSkills)
            {
                if (skill.Equals("Folding"))
                {
                    hasLearntLesson = true;
                }
            }

            if (hasLearntLesson == false)
            {
                mainUser.KnownSkills.Add("Folding");
                mainUser.LessonsLearnt += 1;
            }

            Switcher.Switch(new RecipeOverview(currentRecipe, selectMenu)); //by default I have set this to recipe overview. 
                                                 
        }

    }
}
