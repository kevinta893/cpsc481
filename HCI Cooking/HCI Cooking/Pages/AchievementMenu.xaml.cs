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
    /// Interaction logic for AchievementMenu.xaml
    /// </summary>
    public partial class AchievementMenu : UserControl
    {
        public AchievementMenu()
        {
            InitializeComponent();
        }

        private void btnAchievementBack_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainMenu());
        }
    }
}