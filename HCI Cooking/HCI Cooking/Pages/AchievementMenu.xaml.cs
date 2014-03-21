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

        }

        private void btnAchievementBack_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainMenu());
        }
    }
}
