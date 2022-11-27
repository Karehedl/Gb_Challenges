using static System.Console;

public class ShowAllUI
{
    private MenuItemRepository _menuRepo;
    private bool isRunningAllUI;

    public ShowAllUI()
    {
         _menuRepo = new MenuItemRepository();
    }

    public void Run()
    {
        RunApplication();
    }

    private void RunApplication()
    {
        isRunningAllUI = true;
        while (isRunningAllUI)
        {
            Clear();
            WriteLine("== Komodo Cafe == \n" +
                      "                  \n" +
                      "~ Drinks ~ \n" +
                      "                  ");
                      AllDrinks();
            WriteLine("                  \n" +
                      "~ Meals ~ \n" +
                      "                  ");
                      AllMeals();
            WriteLine("                  \n" +
                      "~ Desserts ~ \n" +
                      "                  ");
                      AllDesserts();
              WriteLine("                  \n" +
                        "                  \n" +
                        "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                        "1. Back To Home Page \n" +
                        "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                        "0. Close Application\n");


            string userInputMenuSelection = ReadLine();
            switch (userInputMenuSelection)
            {
                case "1":
                    BackToMainMenu();
                    break;
                case "0":
                    CloseApplication();
                    break;
                default:
                    WriteLine("Invalid Selection");
                    PressAnyKey();
                    break;
            }
                      
                    ReadKey();
        }
    }
    
//Main Branch

    private void BackToMainMenu() // Switch 6
        {
            Clear();
            isRunningAllUI = false;
        }

    private void CloseApplication() // Switch 0
        {
            isRunningAllUI = false;
            WriteLine("Closing Application");
            PressAnyKey();
        }

    private void PressAnyKey() // default - other
            {
                WriteLine("Press Any Key To Continue.");
                ReadKey();
            }  


    // Drinks 
        private void AllDrinks()  
        {
            List<MenuItem> true_Drinks = _menuRepo.trueDrinks();
            if (true_Drinks.Count > 0)
            {
                foreach (var MenuItem in true_Drinks)
                {
                    DisplayMenuData(MenuItem);
                }
            }
            else
            {
                WriteLine("This Item is not a drink.");
            }
        }

        private void DisplayMenuData(MenuItem menuItem) //Called in All Drinks^  
        {
            WriteLine(menuItem);
        }

        private bool ValidateDrinkInDatabase(int userInputMenuItemId)  
        {
            MenuItem menuItem = GetDrinkDataFromDb(userInputMenuItemId);
            if (menuItem!= null)
            {
                Clear();
                DisplayMenuData(menuItem);
                return true;
            }
            else
            {
                WriteLine($"The Drink with the Id: {userInputMenuItemId} doesn't Exist!");
                return false;
            }
        }

        private MenuItem GetDrinkDataFromDb(int userInputMenuItemId) //Called in ValidateDrinkInDatabase^
        {
            return _menuRepo.GetMenuItem(userInputMenuItemId);
        }



    // Meals 
        private void AllMeals()  
        {
            List<MenuItem> true_Meals = _menuRepo.trueMeals();
            if (true_Meals.Count > 0)
            {
                foreach (var MenuItem in true_Meals)
                {
                    DisplayMealData(MenuItem);
                }
            }
            else
            {
                WriteLine("This Item is not a Meal.");
            }
        }

         private void DisplayMealData(MenuItem menuItem) //Called in All Meals^  
        {
            WriteLine(menuItem);
        }

        private bool ValidateMealInDatabase(int userInputMealId)  
        {
            MenuItem menuItem = GetMealDataFromDb(userInputMealId);
            if (menuItem!= null)
            {
                Clear();
                DisplayMenuData(menuItem);
                return true;
            }
            else
            {
                WriteLine($"The Meal with the Id: {userInputMealId} doesn't Exist!");
                return false;
            }
        }

        private MenuItem GetMealDataFromDb(int userInputMealId) //Called in ValidateDrinkInDatabase^
        {
            return _menuRepo.GetMenuItem(userInputMealId);
        }



    // Desserts
        private void AllDesserts()  
        {
            List<MenuItem> true_Desserts = _menuRepo.trueDesserts();
            if (true_Desserts.Count > 0)
            {
                foreach (var MenuItem in true_Desserts)
                {
                    DisplayDessertData(MenuItem);
                }
            }
            else
            {
                WriteLine("This Item is not a Dessert.");
            }
        }

        private void DisplayDessertData(MenuItem menuItem) //Called in All Desserts^  
        {
            WriteLine(menuItem);
        }

        private bool ValidateDessertInDatabase(int userInputDessertId)  
        {
            MenuItem menuItem = GetDessertDataFromDb(userInputDessertId);
            if (menuItem!= null)
            {
                Clear();
                DisplayMenuData(menuItem);
                return true;
            }
            else
            {
                WriteLine($"The Dessert with the Id: {userInputDessertId} doesn't Exist!");
                return false;
            }
        }

        private MenuItem GetDessertDataFromDb(int userInputDessertId) //Called in ValidateDessertInDatabase^
        {
            return _menuRepo.GetMenuItem(userInputDessertId);
        }

}
