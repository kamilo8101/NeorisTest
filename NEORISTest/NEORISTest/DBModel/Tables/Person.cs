namespace Neoris.User.DBModel.Tables
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Genre { get; set; }
        public int Age { get; set; }
        public string Document { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public virtual Client Client { get; set; }
    }
}
