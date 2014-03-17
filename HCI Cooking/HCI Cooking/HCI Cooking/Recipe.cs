﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


/**
 *  Data Class that contains information for a specific recipe. 
 */

namespace HCI_Cooking
{
    class Recipe
    {
        private int id;                // internal code used to identify recipe? not sure if needed
        private string title;
        private string description;
        private List<string> tools;    // list of tools
        private List<string> steps;    // list of steps
        private Image mainPicture;     // main picture for a recipe
        private List<Image> stepPictures; // list of step-by-step pictures

        public Recipe()
        {
            id = -1;
            title = null;
            description = null;
            tools = new List<string>();
            steps = new List<string>();
            mainPicture = null;
            stepPictures = null;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public List<string> Tools
        {
            get { return tools; }
            set { tools = value; }
        }

        public List<string> Steps
        {
            get { return steps; }
            set { steps = value; }
        }

        public Image MainPicture
        {
            get { return mainPicture; }
            set { mainPicture = value; }
        }

        public List<Image> StepPictures
        {
            get { return stepPictures; }
            set { stepPictures = value; }
        }

        /* this is how you load the image.
         * do it wherever needed when initializing a specific recipe, just not here.
        public void LoadImage(string filename) 
        {
            mainPicture = Image.FromFile(filename);
        }*/
        
    }
}
