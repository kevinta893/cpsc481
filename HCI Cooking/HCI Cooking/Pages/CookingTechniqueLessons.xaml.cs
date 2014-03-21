﻿using System;
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
    public partial class CookingTechniqueLessons : ISwitchable
    {
        Recipe currentRecipe;

        public CookingTechniqueLessons(Recipe rec)
        {
            currentRecipe = rec;
            InitializeComponent();
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
