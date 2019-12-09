namespace PizzaBox.Domain.Abstracts
{
    public abstract class AUser : AModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        // public string UserType { get; set; }
        // public string Address { get; set; }
        // public string Street { get; set; }
        // public string City { get; set; }
        // public string AddressState { get; set; }
        // public int ZipCode { get; set; }
    }
}