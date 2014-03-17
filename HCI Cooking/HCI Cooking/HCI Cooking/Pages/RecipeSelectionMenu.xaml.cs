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
using HCI_Cooking;

namespace HCI_Cooking.Pages
{
    /// <summary>
    /// Interaction logic for RecipeSelectionMenu.xaml
    /// </summary>
    public partial class RecipeSelectionMenu : ISwitchable
    {
        public RecipeSelectionMenu()
        {
            InitializeComponent();
            txtBlkMPCDesc.Text = "Recipe Information"; //replace string with data from the recipe data class

        }
        
        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
        #endregion

        private void brdrMPCimgPH_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipeOverview());
        }

        private void btnRSMBack_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainMenu());
        }

    }
}
