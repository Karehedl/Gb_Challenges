using static System.Console;

public class DessertUI
{
    private MenuItemRepository _menuRepo;
    private bool isRunningDessertUI;

    public DessertUI()
    {
         _menuRepo = new MenuItemRepository();
    }

    public void Run()
    {
        RunApplication();
    }

    private void RunApplication()
    {
        isRunningDessertUI = true;
        while (isRunningDessertUI)
        {
            Clear();
            WriteLine("== Desserts ==\n" +
                  "Please Make a Selection:\n" +
                  "1. Add A Dessert\n" +
                  "2. Delete a Desserts\n" +
                  "3. View a Dessert by ID\n" +
                  "4. Update a Dessert \n" +
                  "5. Veiw all Desserts \n" +
                  "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                  "6. Back To Home Page \n" +
                  "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                  "0. Close Application\n");

            string? userInputMenuSelection = ReadLine();
            switch (userInputMenuSelection)
            {
                case "1":
                    AddaDessert();
                    break;
                case "2":
                    DeleteADessert();
                    break;
                case "3":
                    ViewaDessertByID();
                    break;
                case "4":
                    UpdateaDessert();
                    break;
                case "5":
                    ViewAllDesserts(); 
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

    private void AddaDessert() // Switch 1
    {
         {
            Clear();
            try
            {
                MenuItem menuItem = InitialDessertCreationSetup();
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

    private void DeleteADessert() // Switch 2 
    {
            Clear();
            AllDesserts();
            WriteLine("----------\n");
            try
            {
                WriteLine("Select drink by Id.");
                int userInputDessertId = int.Parse(ReadLine());
                ValidateDessertInDatabase(userInputDessertId);
                WriteLine("Do you want to Delete this Dessert? y/n?");
                string userInputDeleteDessert = ReadLine();
                if (userInputDeleteDessert == "Y".ToLower())
                {
                    if (_menuRepo.DeleteMenuItemData(userInputDessertId))
                    {
                        WriteLine($" The Dessert with the Id: {userInputDessertId}, was Successfully Deleted.");
                    }
                    else
                    {
                        WriteLine($"The Dessert with the Id: {userInputDessertId}, was NOT Deleted.");
                    }
                }
            }
            catch
            {
                SomethingWentWrong();
            }

            ReadKey();
        }

    private void ViewaDessertByID() // Switch 3  
    {
        Clear();
        AllDesserts();
        WriteLine("----------\n");
        try
        {
            WriteLine("Select Dessert by Id.");
            int userInputDessertId = int.Parse(ReadLine());
            ValidateDessertInDatabase(userInputDessertId);
        }
        catch
        {
            SomethingWentWrong();
        }
        ReadKey();
    }

    private void UpdateaDessert() // Switch 4 
    {
            Clear();
            AllDesserts();
            WriteLine("----------\n");
            try
            {
                WriteLine("Select Dessert by Id.");
                int userInputDessertId = int.Parse(ReadLine());
                MenuItem menuItemInDb = GetDessertDataFromDb(userInputDessertId);
                bool isValidated = ValidateDessertInDatabase(menuItemInDb.Id);

                if (isValidated)
                {
                    WriteLine("Do you want to Update this Dessert? y/n?");
                    string userInputDeleteDessert = ReadLine();
                    if (userInputDeleteDessert == "Y".ToLower())
                    {
                        MenuItem updatedMenuItemData = InitialDessertCreationSetup();

                        if (_menuRepo.UpdateMenuItemData(menuItemInDb.Id, updatedMenuItemData))
                        {
                            WriteLine($" The Dessert {updatedMenuItemData.MealName}, was Successfully Updated.");
                        }
                        else
                        {
                            WriteLine($"The Dessert {updatedMenuItemData.MealName}, was NOT Updated.");
                        }
                    }
                    else
                    {
                        WriteLine("Returning to Dessert Menu.");
                    }
                }
            }
            catch
            {
                SomethingWentWrong();
            }
            ReadKey();
    }

    private void ViewAllDesserts() // Switch 5
    {
        Clear();
        AllDesserts();
        ReadKey();
    }

    private void BackToMainMenu() // Switch 6
        {
            Clear();
            isRunningDessertUI = false;
        }

    private void CloseApplication() // Switch 0
        {
            isRunningDessertUI = false;
            WriteLine("Closing Application");
            PressAnyKey();
        }

    private void PressAnyKey() // default - other
            {
                WriteLine("Press Any Key To Continue.");
                ReadKey();
            }  


//Side branch 

    private MenuItem InitialDessertCreationSetup() //Called in Switch 1
    {
        MenuItem menuItem = new MenuItem();

            // menuInDb.MealName = updatedData.MealName;
            // menuInDb.Ingredients = updatedData.Ingredients;
            // menuInDb.Price = updatedData.Price;

        WriteLine("== Add Dessert ==");

        WriteLine("What is the Dessert's name?");
        menuItem.MealName = ReadLine();

        WriteLine("What's the Ingredients?");
        menuItem.Ingredients = ReadLine();

        WriteLine("What's the Price?");
        menuItem.Price = ReadLine();

        menuItem.IsDrink = false; 
        menuItem.IsMeal = false; 
        menuItem.IsDessert = true; 

        return menuItem;
    }

    private void SomethingWentWrong() //Called in Switch 1,2,3,4 
        {
            WriteLine("Something went wrong.\n" +
                        "Please try again\n" +
                        "Returning to Dessert Menu.");
        }

     private void AllDesserts() //Called in Switch 2,3,4,5 
    {
        List<MenuItem> true_Desserts = _menuRepo.trueDesserts();
        if (true_Desserts.Count > 0)
        {
            foreach (var MenuItem in true_Desserts)
            {
                DisplayMenuData(MenuItem);
            }
        }
        else
        {
            WriteLine("This Item is not a Dessert.");
        }
    }

         private void DisplayMenuData(MenuItem menuItem) //Called in All Desserts^  
        {
            WriteLine(menuItem);
        }

    private bool ValidateDessertInDatabase(int userInputDessertId) //Called in Switch 2,3,4 
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
