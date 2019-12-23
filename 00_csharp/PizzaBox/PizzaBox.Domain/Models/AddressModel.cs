namespace PizzaBox.Domain.Models
{
  public class AddressModel
  {
      public string Street { get; set; }
      public string City { get; set; }
      public string AddressState { get; set; }
      public int ZipCode { get; set; }

      public override string ToString()
      {
        return $"{this.Street}, {this.City}, {this.AddressState} {this.ZipCode}";
      }
  }
}