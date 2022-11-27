using static System.Console;

public class  DrinkUI
{
    private MenuItemRepository _menuRepo;
    private bool isRunningDrinkUI;

    public DrinkUI()
    {
         _menuRepo = new MenuItemRepository();
    }

    public void Run()
    {
        RunApplication();
    }

    private void RunApplication()
    {
        isRunningDrinkUI = true;
        while (isRunningDrinkUI)
        {
            Clear();
            WriteLine("== Drinks ==\n" +
                  "Please Make a Selection:\n" +
                  "1. Add A Drink\n" +
                  "2. Delete a Drink\n" +
                  "3. View a Drink by ID\n" +
                  "4. Update a Drink \n" +
                  "5. Veiw all Drinks\n" +
                  "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                  "6. Back To Home Page \n" +
                  "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                  "0. Close Application\n");

            string? userInputMenuSelection = ReadLine();
            switch (userInputMenuSelection)
            {
                case "1":
                    AddaDrink();
                    break;
                case "2":
                    DeleteADrink();
                    break;
                case "3":
                    ViewaDrinkByID();
                    break;
                case "4":
                    UpdateaDrink();
                    break;
                case "5":
                    ViewAllDrinks(); 
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

    private void AddaDrink() // Switch 1
    {
         {
            Clear();
            try
            {
                MenuItem menuItem = InitialMenuCreationSetup();
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

    private void DeleteADrink() // Switch 2 
    {
            Clear();
            AllDrinks();
            WriteLine("----------\n");
            try
            {
                WriteLine("Select drink by Id.");
                int userInputMenuItemId = int.Parse(ReadLine());
                ValidateDrinkInDatabase(userInputMenuItemId);
                WriteLine("Do you want to Delete this Drink? y/n?");
                string userInputDeleteDrink = ReadLine();
                if (userInputDeleteDrink == "Y".ToLower())
                {
                    if (_menuRepo.DeleteMenuItemData(userInputMenuItemId))
                    {
                        WriteLine($" The Drink with the Id: {userInputMenuItemId}, was Successfully Deleted.");
                    }
                    else
                    {
                        WriteLine($"The Drink with the Id: {userInputMenuItemId}, was NOT Deleted.");
                    }
                }
            }
            catch
            {
                SomethingWentWrong();
            }

            ReadKey();
        }

    private void ViewaDrinkByID() // Switch 3  
    {
         Clear();
         AllDrinks();
        WriteLine("----------\n");
        try
        {
            WriteLine("Select Drink by Id.");
            int userInputMenuItemId = int.Parse(ReadLine());
            ValidateDrinkInDatabase(userInputMenuItemId);
        }
        catch
        {
            SomethingWentWrong();
        }
        ReadKey();
    }

    private void UpdateaDrink() // Switch 4 
    {
            Clear();
            AllDrinks();
            WriteLine("----------\n");
            try
            {
                WriteLine("Select Drink by Id.");
                int userInputMenuItemId = int.Parse(ReadLine());
                MenuItem menuItemInDb = GetDrinkDataFromDb(userInputMenuItemId);
                bool isValidated = ValidateDrinkInDatabase(menuItemInDb.Id);

                if (isValidated)
                {
                    WriteLine("Do you want to Update this Drink? y/n?");
                    string userInputDeleteDrink = ReadLine();
                    if (userInputDeleteDrink == "Y".ToLower())
                    {
                        MenuItem updatedMenuItemData = InitialMenuCreationSetup();

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
                        WriteLine("Returning to Drink Menu.");
                    }
                }
            }
            catch
            {
                SomethingWentWrong();
            }
            ReadKey();
    }

    private void ViewAllDrinks() // Switch 5
    {
        Clear();
        AllDrinks();
        ReadKey();
    }

    private void BackToMainMenu() // Switch 6
        {
            Clear();
            isRunningDrinkUI = false;
        }

    private void CloseApplication() // Switch 0
        {
            isRunningDrinkUI = false;
            WriteLine("Closing Application");
            PressAnyKey();
        }

    private void PressAnyKey() // default - other
            {
                WriteLine("Press Any Key To Continue.");
                ReadKey();
            }  


//Side branch 

    private MenuItem InitialMenuCreationSetup() //Called in Switch 1
    {
        MenuItem menuItem = new MenuItem();

            // menuInDb.MealName = updatedData.MealName;
            // menuInDb.Ingredients = updatedData.Ingredients;
            // menuInDb.Price = updatedData.Price;

        WriteLine("== Add Drink ==");

        WriteLine("What is the Drink's name?");
        menuItem.MealName = ReadLine();

        WriteLine("What's the Ingredients?");
        menuItem.Ingredients = ReadLine();

        WriteLine("What's the Price?");
        menuItem.Price = ReadLine();

        menuItem.IsDrink = true;
        menuItem.IsMeal= false;  
        menuItem.IsDessert = false;  

        return menuItem;
    }

    private void SomethingWentWrong() //Called in Switch 1,2,3,4 
        {
            WriteLine("Something went wrong.\n" +
                        "Please try again\n" +
                        "Returning to Drink Menu.");
        }

     private void AllDrinks() //Called in Switch 2,3,4,5 
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

    private bool ValidateDrinkInDatabase(int userInputMenuItemId) //Called in Switch 2,3,4 
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


}
