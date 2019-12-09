using System.ComponentModel.DataAnnotations;
using PizzaBox.Client.Validations;

namespace PizzaBox.Client.Models
{
  public class RegisterViewModel
  {
    [Required]
    [NameAttribute(ErrorMessage = "Name can contain only letters")]
    public string FirstName { get; set; }

    [Required]
    [NameAttribute(ErrorMessage = "Name can contain only letters")]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    public string Street { get; set; }

    [Required]
    [NameAttribute(ErrorMessage = "Name can contain only letters")]
    public string City { get; set; }

    [Required]
    [NameAttribute]
    public string State { get; set; }

    [Required]
    [DataType(DataType.PostalCode)]
    public int ZipCode { get; set; }

    
  }
}