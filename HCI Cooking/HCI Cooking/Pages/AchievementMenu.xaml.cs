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
    /// Interaction logic for AchievementMenu.xaml
    /// </summary>
    public partial class AchievementMenu : UserControl
    {
        Database userDB;
        User mainUser; 

        public AchievementMenu()
        {
            userDB = new Database();
            mainUser = userDB.userList[0];

            InitializeComponent();
            LoadStats();
            LoadAchievements();

        }

        /*
         * Initalizes User's stats throughout the User's experience
         * Gathers information from the User class and database
         * 
         */
        private void LoadStats()
        {
            lblBadgeStats.Content = mainUser.BadgesEarned;
            lblLessonStat.Content = mainUser.LessonsLearnt;
            lblMealStats.Content = mainUser.MealsCooked;
        }
        private void LoadAchievements()
        {
            Canvas achieveCanv;
            Image achieveImg = null;
            Label achieveLbl = null;

            for (int i = 0; i < mainUser.Accomplishments.Count(); i++)
            {
                achieveCanv = (Canvas)grdBadgeHolder.Children[i];

                //Create image and label placement in the 
                for (int item = 0; item < achieveCanv.Children.Count; item++)
                {
                    if (achieveCanv.Children[item] is Image)
                    {
                        achieveImg = (Image)achieveCanv.Children[item];
                    }
                    else if (achieveCanv.Children[item] is Label)
                    {
                        achieveLbl = (Label)achieveCanv.Children[item];
                    }
                }
                achieveCanv.Children[i].Visibility = Visibility.Visible;

                achieveImg.Source = ImageLoader.ToWPFImage(mainUser.BadgeImages[i]);
                achieveLbl.Content = mainUser.Accomplishments[i];
          
            }
        }

        private void btnAchievementBack_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainMenu());
        }
    }
}
