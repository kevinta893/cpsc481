using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

/**
 *  Simulation of a recipe database.
 *  For the purposes of this prototype, we hardcoded some
 *  sample recipes.
 **/

namespace HCI_Cooking
{
    class Database
    {
        public List<Recipe> recipeList;
        
        private Recipe mangoCake;
        private Recipe powChicken;
        private Recipe springRolls;
        private Recipe ribs;

        //private Image mangoPic;

        public Database()
        {

            recipeList = new List<Recipe>();

            mangoCake = new Recipe();
            powChicken = new Recipe();
            springRolls = new Recipe();
            ribs = new Recipe();

            InitializeRecipes();

            //mangoCake.ID = 1;

            recipeList.Add(mangoCake);
            recipeList.Add(powChicken);
            recipeList.Add(springRolls);
            recipeList.Add(ribs);

            // this line might cause a lot of issues
            // not sure how to load from relative path
            //mangoPic = Image.FromFile("\\Images\\pudding_cake.jpg");
        }

        // fill in sample recipe info
        private void InitializeRecipes()
        {
            mangoCake.ID = 1;
            mangoCake.Title = "Mango Pudding Cake";
            mangoCake.Description = "A delicious mango pudding cake. Easy to make and great for kids!";
            mangoCake.Tools.Add("Mixer");
            mangoCake.Tools.Add("Oven");
            mangoCake.Ingredients.Add("Sugar");
            mangoCake.Ingredients.Add("Mango");
            mangoCake.Ingredients.Add("Butter");
            mangoCake.Ingredients.Add("Milk");
            mangoCake.Steps.Add("1. Add ingredients together");
            mangoCake.Steps.Add("2. Do some magic");
            mangoCake.Steps.Add("3. ???");
            mangoCake.Steps.Add("4. PROFIT!");

            powChicken.Title = "POW Chicken";
            springRolls.Title = "SPRING CHICKEN TENTATIVE";
            ribs.Title = "RIBS TENTATIVE";

            //mangoCake.MainPicture = mangoPic;
        }

        // return the recipe with id
        public Recipe GetRecipe(int id) 
        {
            // find the recipe with a lambda expression
            Recipe target = recipeList.Find(x => x.ID == id);

            if (target == null)
            {
                System.Console.Out.WriteLine("cannot find recipe");
                return null;
            }
            else
                return target;
        }
    }
}
