namespace Neoris.Transactions.DTO
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Transaction_Type { get; set; }
        public decimal Transaction_value { get; set; }
        public decimal Balance { get; set; }
        public int AccountId { get; set; }
    }
}
