namespace PizzaBox.Domain.Abstracts
{
    public abstract class AUser 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}