using PizzaBox.Storing.Adapters;
using PizzaBox.Storing.Entities;

namespace PizzaBox.Storing.Repositories
{
  public class PizzaRepository
  {
      // private static List<UserModel> _userList;
    // private const string _path = @"users.xml";
    private static readonly SqlAdapter _sa = new SqlAdapter();
    

    public PizzaRepository()
    {
      // Initialize();
      // if (_userList == null)
      // {
      //   try
      //   {
      //     _userList = FileAdapter.ReadFromXml<List<UserModel>>(_path);
      //   }
      //   catch
      //   {
      //     _userList = new List<UserModel>();
      //     Save();
      //   }
      // }

    }
    public Size ReadSize(string s)
    {
      return _sa.GetSize(s);
    }
    public Crust ReadCrust(string c)
    {
      return _sa.GetCrust(c);
    }
    public Topping ReadTopping(string t)
    {
      return _sa.GetTopping(t);
    }
    public void Create(Pizza p)
    {
      // _userList.Add(u);
      // Save();
      

      // _sa.CreatUser(newUser);
    }

    public void Read(string e, string p)
    {
      // if (u == null)
      // {
      //   return null;
      // }
      // return _userList.Find(x => x.Email==u.Email && x.Password==u.Password);
      // User u = _sa.GetUser(e, p);
      // if(u == null)
      //   return null;
      // UserModel tempU = new UserModel();
      // tempU.FirstName = u.FirstName;
      // tempU.LastName = u.LastName;
      // tempU.Street = u.Address.Street;
      // tempU.City = u.Address.City;
      // tempU.AddressState = u.Address.AddressState;
      // tempU.Email = u.UserAccount.Email;
      // tempU.Password = u.UserAccount.Password;
      // tempU.UserType = u.UserType.UserType1;
      // return tempU;
    }

    public void Update(Pizza u)
    {
      // var customerItem = _userList.FirstOrDefault(o => o.Id == u.Id);

      // customerItem = u;
      // Save();
    }

    public void Delete(Pizza u)
    {
      // var cItem = _userList.FirstOrDefault(o => o.Id == u.Id);

      // _userList.Remove(cItem);
      // Save();
    }

    private void Save()
    {
      // FileAdapter.WriteToXml<List<UserModel>>(_userList, _path);
    }
  }
}