using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Client.Models
{
  public class LoginViewModel
  {
      [Required]
      [EmailAddress]
      public string Email { get; set; }

      [Required]
      [DataType(DataType.Password)]
      public string Password { get; set; }
    
  }
}