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
        private static Database globalInstance;     // singleton Database object

        public List<Recipe> recipeList;
        public List<User> userList;

        private Recipe mangoCake;
        private Recipe powChicken;
        private Recipe springRolls;
        private Recipe ribs;

        private User mainUser;

        // private constructor so only the singleton instance exists
        private Database()
        {
            recipeList = new List<Recipe>();
            userList = new List<User>();

            mangoCake = new Recipe();
            powChicken = new Recipe();
            springRolls = new Recipe();
            ribs = new Recipe();

            mainUser = new User();


            InitializeRecipes();

            recipeList.Add(mangoCake);
            recipeList.Add(powChicken);
            recipeList.Add(springRolls);
            recipeList.Add(ribs);

            InitializeUser();
            userList.Add(mainUser);
        }

        // creates the single instance of Database on first call, then returns that one later
        public static Database getInstance()
        {
            if (globalInstance == null)
            {
               globalInstance = new Database();
            }

            return globalInstance;
        }

        // fill in sample recipe info
        private void InitializeRecipes()
        {
            /*
             * Mango Pudding Cake Recipe information
             */
            mangoCake.ID = 1; //Mango Cake id
            mangoCake.Title = "Mango Pudding Cake";
            mangoCake.Description = "Vanilla pudding gives the cake a nice moist taste.\n";
            mangoCake.CookTime = "1 hour";
            mangoCake.Difficulty = 2;
            
            //list of mango pudding cake
            mangoCake.Tools.Add("Mixer\n");
            mangoCake.Tools.Add("Oven\n");
            mangoCake.Tools.Add("Mixing bowl\n");
            mangoCake.Tools.Add("2 1 1/2 inch Cake Pans\n");
            mangoCake.Tools.Add("Measuring Cups\n");
            mangoCake.Tools.Add("Blender\n");
            
            //list of mango pudding cake ingredients
            mangoCake.Ingredients.Add("2 1/2 cup Sugar\n");
            mangoCake.Ingredients.Add("2 1/2 cup Flour\n");
            mangoCake.Ingredients.Add("1/2 Baking Powder\n");
            mangoCake.Ingredients.Add("3 cups Mango\n");
            mangoCake.Ingredients.Add("1/2 cup Butter\n");
            mangoCake.Ingredients.Add("3 cups Milk\n");
            mangoCake.Ingredients.Add("6 Eggs\n");

            mangoCake.Skills.Add("Mixing");
            mangoCake.Skills.Add("Decorating");
            mangoCake.Skills.Add("Folding");
            mangoCake.Skills.Add("Whisking");

            //list of mango pudding cake steps

            //pudding base instructions
            mangoCake.Steps.Add("Pudding base. \n\n1. Blend mango in a blender until smooth.");
            mangoCake.Steps.Add("2. Add 2 cups of sugar, 2 cups of milk, and the blended mango together in the mixing bowl. Mix well.");
            mangoCake.Steps.Add("3. Chill the pudding in the fridge for 30 minutes. Start on the cake base. \n");

            //cake base instructions
            mangoCake.Steps.Add("Cake base \n\n1. Add sugar, flour and baking powder in the mixing bowl. Mix well.");
            mangoCake.Steps.Add("2. Melt the butter and add it in the mixing bowl.");
            mangoCake.Steps.Add("3. Crack the eggs carefully, making sure you don't get any eggshells in the bowl.");
            mangoCake.Steps.Add("4. Mix the ingredients together.");
            mangoCake.Steps.Add("5. Pour mixture in to cake pans. Bake cakes at 450F for 20 minutes.");
            mangoCake.Steps.Add("6. Once the cakes are baked. Take them out of the pan and spread a layer of the mango pudding on top of one cake. Place other cake on top. The cake is now ready to serve.");
            mangoCake.Steps.Add("Recipe Complete!\r\n\r\nYou've earned 2500xp!");
            //mango pudding photos
            mangoCake.MainPicture = HCI_Cooking.Properties.Resources.mango_cake;
            mangoCake.StepPictures.Add(new Bitmap (HCI_Cooking.Properties.Resources.a1_blend));
            mangoCake.StepPictures.Add(new Bitmap (HCI_Cooking.Properties.Resources.a2_mix));
            mangoCake.StepPictures.Add(new Bitmap (HCI_Cooking.Properties.Resources.a3_chill));
            mangoCake.StepPictures.Add(new Bitmap (HCI_Cooking.Properties.Resources.b1_mix));
            mangoCake.StepPictures.Add(new Bitmap (HCI_Cooking.Properties.Resources.b2_butter));
            mangoCake.StepPictures.Add(new Bitmap (HCI_Cooking.Properties.Resources.b3_eggs));
            mangoCake.StepPictures.Add(new Bitmap (HCI_Cooking.Properties.Resources.b4_mix));
            mangoCake.StepPictures.Add(new Bitmap (HCI_Cooking.Properties.Resources.b5_bake));
            mangoCake.StepPictures.Add(new Bitmap (HCI_Cooking.Properties.Resources.b6_cakedone));
            mangoCake.StepPictures.Add(new Bitmap(HCI_Cooking.Properties.Resources.b6_cakedone)); 


            /*
             *  Pow Chicken Recipe Information 
             */
            powChicken.Title = "POW Chicken";
            powChicken.CookTime = "30 minutes";
            powChicken.Description = "Nice chispy chicken rubbed in delicious spices.\n";
            powChicken.Difficulty = 1;

            //Pow Chicken's required tools
            powChicken.Tools.Add("Stove\n");
            powChicken.Tools.Add("Frying Pan\n");
            powChicken.Tools.Add("Knife\n");
            powChicken.Tools.Add("Mixing Bowl\n");

            powChicken.Skills.Add("Marinating");
            powChicken.Skills.Add("Frying");
            powChicken.Skills.Add("Mixing");
            powChicken.Skills.Add("Cleaning");

            //Pow Chicken's ingredients 
            powChicken.Ingredients.Add("Olive Oil\n");
            powChicken.Ingredients.Add("4 Basil Leaves\n");
            powChicken.Ingredients.Add("Pinch of Salt\n");
            powChicken.Ingredients.Add("Cumin\n");
            powChicken.Ingredients.Add("Chicken Breast\n");
            powChicken.Ingredients.Add("1/2 cup Bread Crumbs\n");

            //Pow Chicken Recipe Steps
            powChicken.Steps.Add("1. Combine basil, salt, bread crumbs, and cumin in a small bowl. Mix together.");
            powChicken.Steps.Add("2. Rub the spice mix on the chicken breast");
            powChicken.Steps.Add("3. Drizzle olive oil in to frying pan");
            powChicken.Steps.Add("4. Fry chicken breast until the outside is white. The chicken is ready.");
            powChicken.Steps.Add("5. Let cool for 2 minutes and serve.");
            powChicken.Steps.Add("Recipe Complete!\r\n\r\nYou've earned 1500xp!");

            //Pow Chicken Photo
            powChicken.MainPicture = HCI_Cooking.Properties.Resources.pow_chicken;


            /*
             *  Spring Rolls Recipe Information 
             */
            springRolls.Title = "Spring Rolls";
            springRolls.Description = "Crispy fried rolls filled with meats and veggies. A delicious asian\r\ndish perfect for any event.";
            springRolls.CookTime = "45 minutes";
            springRolls.Difficulty = 2;
            springRolls.MainPicture = HCI_Cooking.Properties.Resources.spring_rolls;

            springRolls.Tools.Add("filler");
            springRolls.Skills.Add("Breading");
            springRolls.Skills.Add("Degreasing");
            springRolls.Skills.Add("Whisking");
            springRolls.Ingredients.Add("None");

            springRolls.Steps.Add("1. Go buy some spring rolls from your favourite supermarket");
            springRolls.Steps.Add("2. Enjoy... (Actual recipe coming soon!)");


            /*
             *  Ribs Recipe Information 
             */
            ribs.Title = "Lamb Ribs";
            ribs.Description = "Juicy and delicious rack of lambs ribs, rubbed with amazing\nspices. Great for parties!";
            ribs.CookTime = " 55 minutes";
            ribs.Difficulty = 3;
            ribs.MainPicture = HCI_Cooking.Properties.Resources.ribs;

            ribs.Tools.Add("filler");
            ribs.Skills.Add("Marinating");
            ribs.Skills.Add("Glazing");
            ribs.Ingredients.Add("Ribs");

            ribs.Steps.Add("1. Ribs are delicious.");
            
        }

        // sample user info
        private void InitializeUser()
        {
            mainUser.Accomplishments.Add("I can make waffles!");
            mainUser.BadgeImages.Add(new Bitmap(HCI_Cooking.Properties.Resources.waffle_badge_wbg));

            mainUser.Accomplishments.Add("Made my very first recipe");
            mainUser.BadgeImages.Add(new Bitmap(HCI_Cooking.Properties.Resources.first_recipe));


            mainUser.BadgesEarned = mainUser.Accomplishments.Count();

            mainUser.LessonsLearnt = 3;

            mainUser.MealsCooked = 1; 

            mainUser.KnownSkills.Add("Mixing");
            mainUser.KnownSkills.Add("Decorating");
            mainUser.KnownSkills.Add("Breading");


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
