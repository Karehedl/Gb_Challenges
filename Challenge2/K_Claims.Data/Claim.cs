   public class Claim
    {
        //POCO -> Plain Old C# Object
        public Claim()
        {

        }

        public Claim (string claimType,string description, string claimAmount, string dataofIncident, string dataofClaim, 
        bool isVaild, bool isCar, bool isHome, bool isTheft)
        {
            
            ClaimType = claimType; 
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dataofIncident;
            DateOfClaim = dataofClaim;
            IsValid = isVaild;
            IsCar = isCar;
            IsHome = isHome;
            IsTheft = IsTheft;
        }
 
        public int Id {get; set; }
        public string ClaimType { get; set; }
        public string Description { get; set; }
        public string ClaimAmount { get; set; }
        public string DateOfIncident { get; set; }
        public string DateOfClaim { get; set; }
        public bool IsValid { get; set; }
        public bool IsCar { get; set; }
        public bool IsHome { get; set; }
        public bool IsTheft { get; set; }

        public override string ToString()
        {
            //C# stringbuilder....
            string str = $"{Id.ToString()}    {ClaimType}    {Description}    {ClaimAmount}    {DateOfIncident}    {DateOfClaim}    {IsValid}";
            return str;
        }

        
    }
