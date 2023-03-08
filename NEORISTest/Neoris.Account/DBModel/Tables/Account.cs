namespace Neoris.Accounts.DBModel.Tables
{
    public class Account
    {
        public int Id { get; set; }
        public string Account_Number { get; set; }
        public string Account_Type { get; set; }
        public string Initial_Amount { get; set; }
        public bool State { get; set; }
        public int ClientId { get; set;}
    }
}
