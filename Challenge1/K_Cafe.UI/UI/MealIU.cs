using static System.Console;

public class MealUI
{
    private MenuItemRepository _menuRepo;
    private bool isRunningMealUI;

    public MealUI()
    {
         _menuRepo = new MenuItemRepository();
    }

    public void Run()
    {
        RunApplication();
    }

    private void RunApplication()
    {
        isRunningMealUI = true;
        while (isRunningMealUI)
        {
            Clear();
            WriteLine("== Meals ==\n" +
                  "Please Make a Selection:\n" +
                  "1. Add A Meal\n" +
                  "2. Delete a Meal\n" +
                  "3. View a Meal by ID\n" +
                  "4. Update a Meal \n" +
                  "5. Veiw all Meals \n" +
                  "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                  "6. Back To Home Page \n" +
                  "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                  "0. Close Application\n");

            string? userInputMenuSelection = ReadLine();
            switch (userInputMenuSelection)
            {
                case "1":
                    AddaMeal();
                    break;
                case "2":
                    DeleteAMeal();
                    break;
                case "3":
                    ViewaMealByID();
                    break;
                case "4":
                    UpdateaMeal();
                    break;
                case "5":
                    ViewAllMeals(); 
                break;
                case "6":
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
        }
    }
    
//Main Branch

    private void AddaMeal() // Switch 1
    {
         {
            Clear();
            try
            {
                MenuItem menuItem = InitialMealCreationSetup();
                if (_menuRepo.AddMenuToDb(menuItem))
                {
                    WriteLine($"Successfully Added {menuItem.MealName} to the Database!");
                }
                else
                {
                    SomethingWentWrong();
                }
            }
            catch
            {

                SomethingWentWrong();
            }
            ReadKey();
        }

    }

    private void DeleteAMeal() // Switch 2 
    {
            Clear();
            AllMeals();
            WriteLine("----------\n");
            try
            {
                WriteLine("Select   Meal by Id.");
                int userInputMealId = int.Parse(ReadLine());
                ValidateMealInDatabase(userInputMealId);
                WriteLine("Do you want to Delete this Meal? y/n?");
                string userInputDeleteMeal = ReadLine();
                if (userInputDeleteMeal == "Y".ToLower())
                {
                    if (_menuRepo.DeleteMenuItemData(userInputMealId))
                    {
                        WriteLine($" The Meal with the Id: {userInputMealId}, was Successfully Deleted.");
                    }
                    else
                    {
                        WriteLine($"The Meal with the Id: {userInputMealId}, was NOT Deleted.");
                    }
                }
            }
            catch
            {
                SomethingWentWrong();
            }

            ReadKey();
        }

    private void ViewaMealByID() // Switch 3  
    {
        Clear();
        AllMeals();
        WriteLine("----------\n");
        try
        {
            WriteLine("Select Meal by Id.");
            int userInputMealId = int.Parse(ReadLine());
            ValidateMealInDatabase(userInputMealId);
        }
        catch
        {
            SomethingWentWrong();
        }
        ReadKey();
    }

    private void UpdateaMeal() // Switch 4 
    {
            Clear();
            AllMeals();
            WriteLine("----------\n");
            try
            {
                WriteLine("Select Drink by Id.");
                int userInputMealId = int.Parse(ReadLine());
                MenuItem menuItemInDb = GetMealDataFromDb(userInputMealId);
                bool isValidated = ValidateMealInDatabase(menuItemInDb.Id);

                if (isValidated)
                {
                    WriteLine("Do you want to Update this Developer? y/n?");
                    string userInputDeleteMeal = ReadLine();
                    if (userInputDeleteMeal == "Y".ToLower())
                    {
                        MenuItem updatedMenuItemData = InitialMealCreationSetup();

                        if (_menuRepo.UpdateMenuItemData(menuItemInDb.Id, updatedMenuItemData))
                        {
                            WriteLine($" The Drink {updatedMenuItemData.MealName}, was Successfully Updated.");
                        }
                        else
                        {
                            WriteLine($"The Drink {updatedMenuItemData.MealName}, was NOT Updated.");
                        }
                    }
                    else
                    {
                        WriteLine("Returning to Developer Menu.");
                    }
                }
            }
            catch
            {
                SomethingWentWrong();
            }
            ReadKey();
    }

    private void ViewAllMeals() // Switch 5
    {
        Clear();
        AllMeals();
        ReadKey();
    }

    private void BackToMainMenu() // Switch 6
        {
            Clear();
            isRunningMealUI = false;
        }

    private void CloseApplication() // Switch 0
        {
            isRunningMealUI = false;
            WriteLine("Closing Application");
            PressAnyKey();
        }

    private void PressAnyKey() // default - other
            {
                WriteLine("Press Any Key To Continue.");
                ReadKey();
            }  


//Side branch 

    private MenuItem InitialMealCreationSetup() //Called in Switch 1
    {
        MenuItem menuItem = new MenuItem();

            // menuInDb.MealName = updatedData.MealName;
            // menuInDb.Ingredients = updatedData.Ingredients;
            // menuInDb.Price = updatedData.Price;

        WriteLine("== Add Meal ==");

        WriteLine("What is the Meal's name?");
        menuItem.MealName = ReadLine();

        WriteLine("What's the Ingredients?");
        menuItem.Ingredients = ReadLine();

        WriteLine("What's the Price?");
        menuItem.Price = ReadLine();

        menuItem.IsDrink = false; 
        menuItem.IsMeal = true; 
        menuItem.IsDessert = false; 

        return menuItem;
    }

    private void SomethingWentWrong() //Called in Switch 1,2,3,4 
        {
            WriteLine("Something went wrong.\n" +
                        "Please try again\n" +
                        "Returning to Meal Menu.");
        }

     private void AllMeals() //Called in Switch 2,3,4,5 
    {
        List<MenuItem> true_Meals = _menuRepo.trueMeals();
        if (true_Meals.Count > 0)
        {
            foreach (var MenuItem in true_Meals)
            {
                DisplayMenuData(MenuItem);
            }
        }
        else
        {
            WriteLine("This Item is not a Meal.");
        }
    }

         private void DisplayMenuData(MenuItem menuItem) //Called in All Meals^  
        {
            WriteLine(menuItem);
        }

    private bool ValidateMealInDatabase(int userInputMealId) //Called in Switch 2,3,4 
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

        private MenuItem GetMealDataFromDb(int userInputMealId) //Called in ValidateMealsInDatabase^
        {
            return _menuRepo.GetMenuItem(userInputMealId);
        }

}
