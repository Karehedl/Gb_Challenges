using static System.Console;

public class  Program_UI
{
    private MealUI _mealUI;
    private DrinkUI _drinkUI;
    private DessertUI _dessertUI;
    private ShowAllUI _showAllUI;

    private MenuItemRepository _menuRepo;
    private bool isRunning;

    public Program_UI()
    {
         _menuRepo = new MenuItemRepository();
         _drinkUI = new DrinkUI();
         _mealUI = new MealUI();
         _dessertUI = new DessertUI();
         _showAllUI = new ShowAllUI();
    }

    public void Run()
    {
        RunApplication();
    }

    private void RunApplication()
    {
        isRunning = true;
        while (isRunning)
        {
            Clear();
            WriteLine("== Welcome to Komodo Cafe == \n" +
                  "Please Make a Selection:\n" +
                  "1. Drinks\n" +
                  "2. Food\n" +
                  "3. Desserts\n" +
                  "4. View Whole Menu\n" +
                  "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                  "0. Close Application\n");

            string userInputMenuSelection = ReadLine();
            switch (userInputMenuSelection)
            {
                case "1":
                    Drinks(); 
                    break;
                case "2":
                    Meals();
                    break;
                case "3":
                    Desserts();
                    break;
                 case "4":
                    ShowAll();
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

    private void Drinks() // Switch 1 
    {
            Clear();
            _drinkUI.Run();
    }

     private void Meals() // Switch 2 
        {
             Clear();
            _mealUI.Run();
        }

    private void Desserts() // Switch 3
    {
         Clear();
         _dessertUI.Run();
    }

    private void ShowAll() // Switch 4
    {
         Clear();
         _showAllUI.Run();
    }
    
    private void BackToMainMenu() // Switch 5
        {
            Clear();
        }

    private void CloseApplication() // Switch 0
        {
            WriteLine("Closing Application");
            PressAnyKey();
        }

    private void PressAnyKey() //default - other
            {
                WriteLine("Press Any Key To Continue.");
                ReadKey();
            }  

//Side branch 

    //Drinks        
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



    