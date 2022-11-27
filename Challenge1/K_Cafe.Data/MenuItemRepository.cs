public class MenuItemRepository
{
//Fake database 
//C.R.U.D -> Create, Read , Update , and Delete  (methods)

    private readonly List<MenuItem> _menuDb = new List<MenuItem>();
    private int _count;

    //Crud operations 

    //Create -> add to the database 
        public MenuItemRepository()
                {
                      SeedData();
                }

                public bool AddMenuToDb(MenuItem menuItem)
                {
                    return (menuItem is null) ? false : AddToDatabase(menuItem);
                }

            //helper method -> Create
                private bool AddToDatabase(MenuItem menuItem)
                {
                    AssignId(menuItem);
                    _menuDb.Add(menuItem);
                    return true;
                }

            //helper method -> Create
                private void AssignId(MenuItem menuItem)
                {
                    _count++;
                    menuItem.Id = _count;
                }
    // Reads - reads list 
        public List<MenuItem> GetMenuItems()
                {
                    return _menuDb;
                }

                public MenuItem GetMenuItem(int id)
                {
                    //LINQ
                    return _menuDb.SingleOrDefault(menuItem => menuItem.Id == id);
                }
        // Drinks
            public List<MenuItem> trueDrinksLINQ()
                {
                    //LINQ
                    return _menuDb.Where(menuItem => menuItem.IsDrink == true).ToList();
                }

                public List<MenuItem> trueDrinks()
                {
                    List<MenuItem> trueDrinks = new List<MenuItem>();
                    foreach (MenuItem menuItem in _menuDb)
                    {
                        if (menuItem.IsDrink == true)
                        {
                            trueDrinks.Add(menuItem);
                        }
                    }
                    return trueDrinks;
                }
         // Meals
            public List<MenuItem> trueMealsLINQ()
                {
                    //LINQ
                    return _menuDb.Where(menuItem => menuItem.IsMeal == true).ToList();
                }

                public List<MenuItem> trueMeals()
                {
                    List<MenuItem> trueMeals = new List<MenuItem>();
                    foreach (MenuItem menuItem in _menuDb)
                    {
                        if (menuItem.IsMeal == true)
                        {
                            trueMeals.Add(menuItem);
                        }
                    }
                    return trueMeals;
                }
          // Desserts
            public List<MenuItem> trueDessertsLINQ()
                {
                    //LINQ
                    return _menuDb.Where(menuItem => menuItem.IsDessert == true).ToList();
                }

                public List<MenuItem> trueDesserts()
                {
                    List<MenuItem> trueDesserts = new List<MenuItem>();
                    foreach (MenuItem menuItem in _menuDb)
                    {
                        if (menuItem.IsDessert == true)
                        {
                            trueDesserts.Add(menuItem);
                        }
                    }
                    return trueDesserts;
                }

    // Update 
         public bool UpdateMenuItemData(int menuItemId, MenuItem updatedData)
        {
            MenuItem menuInDb = GetMenuItem(menuItemId);

            if (menuInDb != null)
            {
                menuInDb.MealName = updatedData.MealName;
                menuInDb.Ingredients = updatedData.Ingredients;
                menuInDb.Price = updatedData.Price;
                return true;
            }
            return false;
        }

    //Delete 
          public bool DeleteMenuItemData(int menuId)
        {
            MenuItem menuInDb = GetMenuItem(menuId);
            return _menuDb.Remove(menuInDb);
        }

//Data
     private void SeedData()
        {
            var menuA = new MenuItem("Iced Mocha", "espresso, whole or nonfat milk and chocolate syrup, topped with whipped cream and a chocolate drizzle.",  "4.45", true, false, false );
            var menuB = new MenuItem("Strawberry latte", "strawberry sauce, milk of choice, strong espresso coffee, layed with whipped cream, and ice cubes.", "4.19", true, false, false );
            var menuC = new MenuItem("Jollypong latte", "Whole or nonfat milk, espresso, fresh ice, and whole wheat Jollypong cereal."," 3.85 ", true, false, false);
            var menuD = new MenuItem("Banana cafe latte", "smooth banana milk, espresso, banana, sugar, ice, and topped with whipped cream.", "4.79", true, false, false);
            var menuE = new MenuItem("Kimchi", "fresh ginger, cabbage, fermented radish, cloves garlic, chopped white onion, rice vinegar, cucumber, persimmon, minced  green onions, and red pepper flakes.", "8.57", false, true, false);
            var menuF = new MenuItem("Bibimbap", "fresh mixed vegetables, rice, beef, and egg, with sesame oil and a dollop of chili paste for seasoning.", "9.45", false, true, false);
            var menuG = new MenuItem("Crab Salad Sandwich", "Sandwich Bread, Mustard Mayo, Sliced American Cheese, Crab Salad, Sweet Onion Rings, Pickled Red Cabbage, and Iceberg Lettuce", "8.45", false, true, false);
            var menuH = new MenuItem("Sweet Pancakes", "yeast, sugar, sweet rice flour, cinnamon, and roasted seeds and nuts.", "5.75", false, false, true );
            var menuI = new MenuItem("Dalgona", "sugar, baking soda, and frying oil.", "1.45", false, false, true);

                



            //add to db
            AddMenuToDb(menuA);
            AddMenuToDb(menuB);
            AddMenuToDb(menuC);
            AddMenuToDb(menuD);
            AddMenuToDb(menuE);
            AddMenuToDb(menuF);
            AddMenuToDb(menuG);
            AddMenuToDb(menuH);
            AddMenuToDb(menuI);
        }


}

                    // drinks = https://thesmartlocal.kr/korean-home-cafe/
                    // soups = https://www.cnn.com/travel/article/best-korean-dishes/index.html
                    // sandwiches = http://www.aeriskitchen.com/2020/11/4-korean-cafe-sandwiches/
                    // desserts = https://thekitchencommunity.org/korean-desserts/
