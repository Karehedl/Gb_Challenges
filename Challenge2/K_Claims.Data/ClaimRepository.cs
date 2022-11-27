using System.Data;

public class ClaimRepository
{

//Fake database 
//C.R.U.D -> Create, Read , Update , and Delete  (methods)

    private readonly List<Claim> _claimDb = new List<Claim>();
    private int _count;

    List<string> ClaimDates = new List<string>();

    //Crud operations 

    //Create -> add to the database 
        public ClaimRepository()
                {
                      SeedData();
                }

                public bool AddClaimToDb(Claim claim)
                {
                    return (claim is null) ? false : AddToDatabase(claim);
                }

            //helper method -> Create
                private bool AddToDatabase(Claim claim)
                {
                    AssignId(claim);
                    _claimDb.Add(claim);
                    return true;
                }

            //helper method -> Create
                private void AssignId(Claim claim)
                {
                    _count++;
                    claim.Id = _count;
                }
    // Reads - reads list 
        public List<Claim> GetClaims()
                {
                    return _claimDb;
                }

                public Claim GetClaim(int id)
                {
                    //LINQ
                    return _claimDb.SingleOrDefault(claim => claim.Id == id);
                }

       

    // Update 
         public bool UpdateClaimData(int claimId, Claim updatedData)
        {
            Claim claimInDb = GetClaim(claimId);

            if (claimInDb != null)
            {
                claimInDb.ClaimType = updatedData.ClaimType;
                claimInDb.Description = updatedData.Description;
                claimInDb.ClaimAmount = updatedData.ClaimAmount;
                claimInDb.DateOfIncident = updatedData.DateOfIncident;
                claimInDb.DateOfClaim = updatedData.DateOfClaim;

                return true;
            }
            return false;
        }

    //Delete 
          public bool DeleteClaimData(int claimId)
        {
            Claim claimInDb = GetClaim(claimId);
            return _claimDb.Remove(claimInDb);
        }

//Data
     private void SeedData()
        {
            var claimA = new Claim("Car", "Car accident on 465.",  "400.00", "4/25/18", "4/27/18", true, true, false, false );
            var claimB = new Claim("House", "Fire",  "8000.00", "4/7/18", "4/20/18", true, false, true, false );
            var claimC = new Claim("Theft", "Laptop stolen.",  "600.00", "7/21/19", "7/23/19", true, true, false, false );
            // var menuD = new Claim("Car", "Car accident on 465.",  "400.00", "4/25/18", "4/27/18", true, true, false, false );
            // var menuE = new Claim("Car", "Car accident on 465.",  "400.00", "4/25/18", "4/27/18", true, true, false, false );
            // var menuF = new Claim("Car", "Car accident on 465.",  "400.00", "4/25/18", "4/27/18", true, true, false, false );
            // var menuG = new Claim("Car", "Car accident on 465.",  "400.00", "4/25/18", "4/27/18", true, true, false, false );
            // var menuH = new Claim("Car", "Car accident on 465.",  "400.00", "4/25/18", "4/27/18", true, true, false, false );
            // var menuI = new Claim("Car", "Car accident on 465.",  "400.00", "4/25/18", "4/27/18", true, true, false, false );


            //add to db
            AddClaimToDb(claimA);
            AddClaimToDb(claimB);
            AddClaimToDb(claimC);
            // AddClaimToDb(claimD);
            // AddClaimToDb(claimE);
            // AddClaimToDb(claimF);
            // AddClaimToDb(claimG);
            // AddClaimToDb(claimH);
            // AddClaimToDb(claimI);
        }




}



