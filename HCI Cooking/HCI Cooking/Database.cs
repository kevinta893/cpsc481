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
            /*
             * Mango Pudding Cake Recipe information
             * 
             */
            mangoCake.ID = 1; //Mango Cake id
            mangoCake.Title = "Mango Pudding Cake";
            mangoCake.Description = "Vanilla pudding gives the cake a nice moist taste.\n";
            mangoCake.CookTime = "1 hour";
            
            //list of mango pudding cake
            mangoCake.Tools.Add("Mixer");
            mangoCake.Tools.Add("Oven");
            mangoCake.Tools.Add("Mixing bowl");
            mangoCake.Tools.Add("2 1 1/2 inch Cake Pans");
            mangoCake.Tools.Add("Measuring Cups");
            mangoCake.Tools.Add("Blender");
            
            //list of mango pudding cake ingredients
            mangoCake.Ingredients.Add("2 1/2 cup Sugar");
            mangoCake.Ingredients.Add("2 1/2 cup Flour");
            mangoCake.Ingredients.Add("1/2 Baking Powder");
            mangoCake.Ingredients.Add("3 cups Mango");
            mangoCake.Ingredients.Add("1/2 cup Butter");
            mangoCake.Ingredients.Add("3 cups Milk");
            mangoCake.Ingredients.Add("6 Eggs");

            //list of mango pudding cake steps

            //pudding base instructions
            mangoCake.Steps.Add("Pudding base. \n 1. Blend mango in a blender until smooth.");
            mangoCake.Steps.Add("2. Add 2 cups of sugar and 2 cups of milk and in the mixing bowl. Mix well.");
            mangoCake.Steps.Add("3. Chill the pudding in the fridge for 30 minutes. Start on the cake base.");

            //cake base instructions
            mangoCake.Steps.Add("Cake base \n 1. Add sugar, flour and baking powder in the mixing bowl. Mix well.");
            mangoCake.Steps.Add("2. Melt the butter and add it in the mixing bowl.");
            mangoCake.Steps.Add("3. Crack the eggs carefully, making sure you don't get any eggshells in the bowl.");
            mangoCake.Steps.Add("4. Mix the ingredients together.");
            mangoCake.Steps.Add("5. Pour mixture in to cake pans. Bake cakes at 450F for 20 minutes.");

            mangoCake.Steps.Add("6.Once the cakes are baked. Take them out of the pan and spread a layer of the mango pudding \n on top of one cake. Place other cake on top. The cake is now ready to serve.");

            /*
             *  Pow Chicken Recipe Information 
             */
            powChicken.Title = "POW Chicken";
            powChicken.CookTime = "30 minutes";
            powChicken.Description = "Nice chispy chicken rubbed in delicious spices.\n";
            
            //Pow Chicken's required tools
            powChicken.Tools.Add("Stove");
            powChicken.Tools.Add("Frying Pan");
            powChicken.Tools.Add("Knife");
            powChicken.Tools.Add("Mixing Bowl");

            //Pow Chicken's ingredients 
            powChicken.Ingredients.Add("Olive Oil");
            powChicken.Ingredients.Add("4 Basil Leaves");
            powChicken.Ingredients.Add("Pinch of Salt");
            powChicken.Ingredients.Add("Cumin");
            powChicken.Ingredients.Add("Chicken Breast");
            powChicken.Ingredients.Add("1/2 cup Bread Crumbs");

            //Pow Chicken Recipe Steps
            powChicken.Steps.Add("1. Combine basil, salt, bread crumbs, and cumin in a small bowl. Mix together.");
            powChicken.Steps.Add("2. Rub the spice mix on the chicken breast");
            powChicken.Steps.Add("3. Drizzle olive oil in to frying pan");
            powChicken.Steps.Add("4. Fry chicken breast until the outside is white. The chicken is ready.");


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
