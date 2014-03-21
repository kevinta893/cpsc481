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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : ISwitchable
    {
        public MainMenu()
        {
            InitializeComponent();
            imgTitleScreen.Source = ImageLoader.ToWPFImage(HCI_Cooking.Properties.Resources.ace_cooking_title);
        }


        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
        #endregion

        private void btnCookingTech_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipeSelectionMenu());
        }

        private void btnAchievements_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new AchievementMenu());
        }
    }
}