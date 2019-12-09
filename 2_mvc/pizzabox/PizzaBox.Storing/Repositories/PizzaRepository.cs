using System.Collections.Generic;
using PizzaBox.Storing.Adapters;
using PizzaBox.Storing.Entities;

namespace PizzaBox.Storing.Repositories
{
  public class PizzaRepository
  {
    private static readonly SqlAdapter _sa = new SqlAdapter();
    

    public PizzaRepository()
    {

    }
    public Size ReadSize(string s)
    {
      return _sa.GetSize(s);
    }
    public List<Size> ReadSizes()
    {
      return _sa.GetAllSizes();
    }
    public Crust ReadCrust(string c)
    {
      return _sa.GetCrust(c);
    }
    public List<Crust> ReadCrusts()
    {
      return _sa.GetAllCrusts();
    }
    public Topping ReadTopping(string t)
    {
      return _sa.GetTopping(t);
    }
    public List<Topping> ReadToppings()
    {
      return _sa.GetAllToppings();
    }
    public void Create(Pizza p)
    {
    }

    public void Read()
    {
    }

    public void Update(Pizza u)
    {
    }

    public void Delete(Pizza u)
    {
    }

    private void Save()
    {
    }
  }
}