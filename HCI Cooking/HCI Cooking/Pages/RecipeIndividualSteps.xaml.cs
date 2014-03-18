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
    /// Interaction logic for RecipeIndividualSteps.xaml
    /// </summary>
    public partial class RecipeIndividualSteps : ISwitchable
    {
        public RecipeIndividualSteps()
        {
            InitializeComponent();
        }


        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
        #endregion

        private void btnIndiToogleView_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipeCompleteSteps());
        }

        //FIX THIS TO BE GREYED OUT ON STEP 1
        private void btnIndivRecipeBack_Click(object sender, RoutedEventArgs e)
        {
            Switcher.GoBack();
        }

        private void btnIndivRecipeNext_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipeIndividualSteps());
        }

        private void btnRecipeIndivBack_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipeOverview());
        }
    }
}
