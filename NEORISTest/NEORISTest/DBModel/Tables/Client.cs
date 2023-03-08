namespace Neoris.User.DBModel.Tables
{
    public class Client
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public bool State { get; set; }
        public int PersonID { get; set; }


        public virtual Person Person { get; set; }

    }
}
