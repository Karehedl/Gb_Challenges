using System;
using System.Security.Claims;
using static System.Console;

public class Program_UI
{
    private ClaimRepository _claimRepo;
    private bool isRunningUI;

    public Program_UI()
    {
         _claimRepo = new ClaimRepository();
    }

    public void Run()
    {
        RunApplication();
    }

    private void RunApplication()
    {
        isRunningUI = true;
        while (isRunningUI)
        {
            Clear();
            WriteLine("== KOMODO INSURANCE ==\n" +
                  "Please Make a Selection:\n" +
                  "1. View All Claims\n" +
                  "2. View Next Came \n" +
                  "3. Add a New Claim\n" +
                  "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                  "4. Back To Home Page \n" +
                  "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                  "0. Close Application\n");
            

            string? userInputMenuSelection = ReadLine();
            switch (userInputMenuSelection)
            {
                case "1":
                    ViewAllClaims();
                    break;
                case "2":
                   ViewNextCame();
                    break;
                case "3":
                   AddaNewClaim();
                    break;
                case "4":
               
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

    private void ViewAllClaims() // Switch 1
    {
        Clear();
        ShowAllClaims();
        ReadKey();
    }

    private void ViewNextCame() //Switch 2
    {
        Clear();
       
        ReadKey();
    }

    private void AddaNewClaim() // Switch 3
    {
         {
            Clear();
            try
            {
                Claim claim = InitialClaimCreationSetup();
                if (_claimRepo.AddClaimToDb(claim))
                {
                    WriteLine($"Successfully Added {claim.ClaimType} to the Database!");
                }
                else
                {
                    WriteLine("Invalid Selection");
                    PressAnyKey();
                }
            }
            catch
            {

                 WriteLine("Invalid Selection");
                    PressAnyKey();
            }
            ReadKey();
        }

    }

    private void BackToMainMenu() // Switch 4
        {
            Clear();
            isRunningUI = false;
        }

    private void CloseApplication() // Switch 0
        {
            isRunningUI = false;
            WriteLine("Closing Application");
            PressAnyKey();
        }

    private void PressAnyKey() // default - other
            {
                WriteLine("Press Any Key To Continue.");
                ReadKey();
            }  


//Side branch 

    private void ShowAllClaims() //Called in Switch 1, 
    {
        Clear();
        WriteLine("== Claims ==");
        List<Claim> claimInDb = _claimRepo.GetClaims();
        ValidateClaimDatabaseData(claimInDb);
    }

        private void ValidateClaimDatabaseData(List<Claim> claimInDb) //Called in ShowAllClaims
        {
            if (claimInDb.Count > 0)
            {
                Clear();
                foreach (var claim in claimInDb)
                {
                    DisplayClaimData(claim);
                }
            }
            else
            {
                WriteLine("There are no Developers in the Database.");
            }
        }

              private void DisplayClaimData(Claim claim) //Called in ShowAllClaims/ValidateClaimDatabaseData
                {
                    WriteLine(claim);
                }

  private Claim InitialClaimCreationSetup() //Called in Switch 3
    {
        Claim claim = new Claim();

            // ClaimType = claimType; 
            // Description = description;
            // ClaimAmount = claimAmount;
            // DateOfIncident = dataofIncident;
            // DateOfClaim = dataofClaim;
            // IsValid = isVaild;
            // IsCar = isCar;
            // IsHome = isHome;
            // IsTheft = IsTheft;

        WriteLine("== Add Claim ==");

        WriteLine("What is the Claim's name?");
        claim.ClaimType = ReadLine();

        WriteLine("What's the Description?");
        claim.Description = ReadLine();

        WriteLine("What's the Coverage needed?");
        claim.ClaimAmount = ReadLine();

        WriteLine("What's the Date Of Incident (MM/dd/yyyy) ?");
        claim.DateOfIncident = ReadLine();
        claim.DateOfClaim = DateTime.Now.ToString("MM'/'dd'/'yyyy");

        claim.IsValid = true;
        claim.IsCar = true;
        claim.IsHome= false;  
        claim.IsTheft = false;  

        return claim;
    }

}
