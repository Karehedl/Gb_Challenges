    public class MenuItem
    {
        //POCO -> Plain Old C# Object
        public MenuItem()
        {

        }

        public MenuItem(string mealName,string ingredients, string price, bool isDrink, bool isMeal, bool isDessert)
        {
            MealName = mealName;
            Ingredients = ingredients;
            Price = price; 
            IsDrink = isDrink;
            IsMeal = isMeal;
            IsDessert = isDessert;
        }

        public int Id {get; set; }
        public string MealName { get; set; }
        public string Ingredients { get; set; }
        public string Price { get; set; }
        public bool IsDrink { get; set; }
        public bool IsMeal { get; set; }
        public bool IsDessert { get; set; }

        public override string ToString()
        {
            //Google:  C# stringbuilder....
            string str = $"<{Id.ToString()}> {MealName}\n" 
                       + $"{Ingredients}\n" 
                       + $"{Price} \n" 
                       + "====================================\n";
            return str;
        }

    }
