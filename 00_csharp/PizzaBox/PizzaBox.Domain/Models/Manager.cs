using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Manager : AUser
    {
      public Store CurrentStore { get; set; }
      public Manager()
      {
        CurrentStore = new Store();
      }

      public override string ToString()
      {
        return $"{this.FirstName}";
      }
    }
}