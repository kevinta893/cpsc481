/*
 *  User class
 *  Stores information about the user. 
 *  Anything about the user is stored in this class.
 *  
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace HCI_Cooking
{
    public class User
    {
        private int userId;
        private int mealsCooked;
        private int lessonsLearnt;
        private int badgesEarned;

        private List<string> knownSkills;
        private List<string> accomplishments;
        private List<Image> badgeImages;

        public User()
        {
            userId = 007;
            mealsCooked = -1;
            lessonsLearnt = -1;
            badgesEarned = -1;

            knownSkills = new List<string>();
            accomplishments = new List<string>();
            badgeImages = new List<Image>();

        }

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public int MealsCooked
        {
            get { return mealsCooked; }
            set { mealsCooked = value; }
        }


        public int LessonsLearnt
        {
            get { return lessonsLearnt; }
            set { lessonsLearnt = value; }
        }

        public int BadgesEarned
        {
            get { return badgesEarned; }
            set { badgesEarned = value; }
        }

        public List<string> KnownSkills
        {
            get { return knownSkills; }
            set { knownSkills = value; }
        }

        public List<string> Accomplishments
        {
            get { return accomplishments; }
            set { accomplishments = value; }
        }

        public List<Image> BadgeImages
        {
            get { return badgeImages; }
            set { badgeImages = value; }
        }
    }
}
