using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Client.Validations;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Models
{
  public class OrderViewModel
  {
    private static StoreRepository _sr = new StoreRepository();
    private static PizzaRepository _pr = new PizzaRepository();

    public OrderViewModel()
    {
      Stores = _sr.Read();
      Toppings = _pr.ReadToppings();
      Sizes = _pr.ReadSizes();
      Crusts = _pr.ReadCrusts();
      Cost = 0;
    }
    [Required]
    [TimeAttribute(ErrorMessage = "Error. Can only order once within a 1-hour period. Try again later.")]
    [SameStoreAttribute(ErrorMessage = "Error. Cannot order more than once from the same store within a 24 hour period. Choose a different Store.")]
    public string Store { get; set; }
    [Required]
    public string Crust { get; set; }
    [Required]
    public string Size { get; set; }
    public string Topping { get; set; }
    [CostAttribute(ErrorMessage = "Error. Order total cannot exceed $250.")]
    public decimal Cost { get; set; }
    [Range(1,10)]
    public int Quantity { get; set; }
    public List<Store> Stores;
    public List<Topping> Toppings;
    public List<Crust> Crusts;
    public List<Size> Sizes;


  }
}