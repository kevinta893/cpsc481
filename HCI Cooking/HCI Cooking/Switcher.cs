/**
 * Code taken from the following website. With slight modifications
 * 
 * http://azerdark.wordpress.com/2010/04/23/multi-page-application-in-wpf/
 */


using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using HCI_Cooking;

namespace HCI_Cooking
{
    public static class Switcher
    {
        private static Stack<UserControl> backStack = new Stack<UserControl>();
        public static MainWindow pageSwitcher;

        public static void Switch(UserControl newPage)
        {
            backStack.Push(newPage);
            pageSwitcher.Navigate(newPage);
        }

        public static void Switch(UserControl newPage, object state)
        {
            backStack.Push(newPage);
            pageSwitcher.Navigate(newPage, state);
        }


        /**
         * Goes back to the previous page that was swapped recently
         * Returns the page that was swapped out
         */
        public static UserControl GoBack()
        {
            UserControl back = backStack.Pop();
            pageSwitcher.Navigate(backStack.Peek());
            return back;
        }
    }
}
