/**
 * Code taken from the following website. With slight modifications
 * 
 * http://azerdark.wordpress.com/2010/04/23/multi-page-application-in-wpf/
 */



using System.Windows.Controls;
using System.Windows;
using HCI_Cooking;

namespace HCI_Cooking
{
    public static class Switcher
    {
        public static MainWindow pageSwitcher;

        public static void Switch(UserControl newPage)
        {
            pageSwitcher.Navigate(newPage);
        }

        public static void Switch(UserControl newPage, object state)
        {
            pageSwitcher.Navigate(newPage, state);
        }
    }
}