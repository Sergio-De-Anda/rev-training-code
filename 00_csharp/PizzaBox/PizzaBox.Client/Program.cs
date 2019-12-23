using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Adapters;
using PizzaBox.Storing.Repositories;
using AddressEntity=PizzaBox.Storing.Entities.Address;
using StoreEntity=PizzaBox.Storing.Entities.Store;
using PizzaEntity=PizzaBox.Storing.Entities.Pizza;
using CrustEntity=PizzaBox.Storing.Entities.Crust;
using SizeEntity=PizzaBox.Storing.Entities.Size;
using ToppingEntity=PizzaBox.Storing.Entities.Topping;
using PizzaTopping=PizzaBox.Storing.Entities.PizzaTopping;
using OrderEntity=PizzaBox.Storing.Entities.Order;
using OrderPizza=PizzaBox.Storing.Entities.OrderPizza;

namespace PizzaBox.Client
{
    class Program
    {
        private static OrderRepository _or = new OrderRepository();
        static StoreRepository _sr = new StoreRepository();
        private static CustomerRepository _cr = new CustomerRepository();
        private static ManagerRepository _mr = new ManagerRepository();
        private static UserRepository _ur = new UserRepository();
        private static PizzaRepository _pr = new PizzaRepository();
        static void Main()
        {
          // Console.Clear();
          // Start();
          test2();
        }

        // testing select, insert, delete, update in Entity Framework
        static void Test()
        {
          // SqlAdapter b = new SqlAdapter();
          
          // insert
          // AddressEntity newAddress = new AddressEntity();
          // newAddress.Street = "210 W 14th Street";
          // newAddress.City = "Arlington";
          // newAddress.AddressState = "Texas";
          // newAddress.ZipCode = 76013;
          // b.CreateAddress(newAddress);

          // select
          // List<AddressEntity> a = b.GetAddresses();
          // foreach (var item in a)
          // {
          //     Console.WriteLine(item);
          // }

          // update
          // AddressEntity newA = b.GetAddress();
          // newA.City = "Arlington";
          // b.UpdateAddress(newA);
          // Console.WriteLine(newA);

          // delete
          // b.DeleteAddress(newA);

          // UserModel u = new UserModel();
          // u.FirstName = "John";
          // u.LastName = "Doe";
          // u.Email = "john@email.com";
          // u.Password = "123";
          // u.UserType = "Customer";
          // u.Street = "203 N 15th Street";
          // u.City = "Arlington";
          // u.AddressState = "Texas";
          // u.ZipCode = 70610;
          // _ur.Create(u);

          //user
          // UserModel u = _ur.Read("john@email.com", "123");
          // StoreEntity s = _sr.Read("Pizza Planet");
          // Pizza
          // PizzaEntity p = new PizzaEntity();
          // p.SizeId = _pr.ReadSize("small").SizeId;
          // p.CrustId = _pr.ReadCrust("hand-tossed").CrustId;
          // PizzaTopping t1 = new PizzaTopping();
          // t1.Pizza = p;
          // t1.ToppingId = _pr.ReadTopping("pepperoni").ToppingId;
          // PizzaTopping t2 = new PizzaTopping();
          // t2.Pizza = p;
          // t2.ToppingId = _pr.ReadTopping("beef").ToppingId;
          // p.PizzaTopping.Add(t1);
          // p.PizzaTopping.Add(t2);
          // p.Cost = 9.99M;
          //Order
          // OrderEntity o = new OrderEntity();
          // o.OrderDate = DateTime.Now;
          // o.StoreId = s.StoreId;
          // o.UserId = 2;
          // o.TotalCost = 9.99M;
          // OrderPizza op = new OrderPizza();
          // op.Order = o;
          // op.Pizza = p;
          // o.OrderPizza.Add(op);
          // _or.Create(o);

          



          // Order
          // OrderModel o = _or.Read();
          



        }

        static void test2()
        {
          // Register
          // UserModel newU = new UserModel();
          // newU.FirstName = "Gerardo";
          // newU.LastName = "Martinez";
          // newU.Email = "gerardo@email.com";
          // newU.Password = "123";
          // newU.Street = "123 N Ave";
          // newU.City = "Arlington";
          // newU.AddressState = "Texas";
          // newU.ZipCode = 76010;
          // _ur.Create(newU);

          // Login
          // UserModel currentU = _ur.Read("gerardo@email.com", "123");

          // Make Order
          // StoreModel selectedStore = new StoreModel();
          // selectedStore.StoreName = _sr.Read("best pizza").StoreName;
          // PizzaModel p1 = new PizzaModel();
          // p1.Crust = _pr.ReadCrust("thin").CrustName;
          // p1.Size = _pr.ReadSize("small").SizeName;
          // p1.Toppings.Add(_pr.ReadTopping("pepperoni").ToppingName);
          // p1.Toppings.Add(_pr.ReadTopping("beef").ToppingName);
          // p1.Cost = 9.99M;
          // PizzaModel p2 = new PizzaModel();
          // p2.Crust = _pr.ReadCrust("hand-tossed").CrustName;
          // p2.Size = _pr.ReadSize("large").SizeName;
          // p2.Toppings.Add(_pr.ReadTopping("bacon").ToppingName);
          // p2.Toppings.Add(_pr.ReadTopping("beef").ToppingName);
          // p2.Cost = 9.99M;
          // OrderModel newOrder = new OrderModel();
          // newOrder.OrderDate = DateTime.Now;
          // newOrder.Store = selectedStore;
          // newOrder.User = currentU;
          // newOrder.Pizzas.Add(p1);
          // newOrder.Pizzas.Add(p2);
          // currentU.Orders.Add(newOrder);
          // _or.Create(newOrder);

          // Logout
          // Login

          // Print Orders
          // foreach (var o in currentU.Orders)
          // {
          //   Console.WriteLine(o.OrderDate);
          //   foreach (var p in o.Pizzas)
          //   {
          //       Console.WriteLine(p.Cost);
          //       Console.WriteLine(p.Crust);
          //       Console.WriteLine(p.Size);
          //       foreach (var t in p.Toppings)
          //       {
          //         Console.WriteLine(t);
          //         Console.WriteLine();
          //       }
          //   }
          // }

          // login manager
          UserModel currentU = _ur.Read("admin@pizzabox.com", "123");
          Console.WriteLine(currentU);
          
          // choose store
          StoreModel currentStore = _sr.Read("best pizza");
          // view store orders
          Console.WriteLine(currentStore.StoreName);
          foreach (var o in currentStore.Orders)
          {
            Console.WriteLine(o.OrderDate);
            foreach (var p in o.Pizzas)
            {
                Console.WriteLine(p.Cost);
                Console.WriteLine(p.Crust);
                Console.WriteLine(p.Size);
                foreach (var t in p.Toppings)
                {
                  Console.WriteLine(t);
                  Console.WriteLine();
                }
            }
          }



        }
        
        static void Exit()
        {
          Console.WriteLine("Exiting...");
          Environment.Exit(0);
        }
        static void Start()
        {
          Console.WriteLine("Welcome to PizzaBox!");
          Console.WriteLine("1. Login");
          Console.WriteLine("2. Manager Login");
          Console.WriteLine("3. Register");
          Console.WriteLine("4. Exit");
          Console.Write("What would you like to do? ");
          int input = ValidateUserInput();
          switch (input)
          {
            case 1:
              Login();
              break;
            case 2:
              ManagerLogin();
              break;
            case 3:
              Register();
              break;
            case 4:
              Exit();
              break;
            default:
              Start();
              break;
          }
        }

        public static void Login()
        {
          Console.Clear();
          Customer CurrentUser = new Customer();
          Console.Write("Email:");
          CurrentUser.Email = Console.ReadLine();
          Console.Write("Password:");
          CurrentUser.Password = Console.ReadLine();
          if(_cr.Read(CurrentUser) == null)
          {
            Console.Clear();
            Console.WriteLine("No user with that email/passord combination exists\nTry again\n");
            Start();
            return;
          }
          Console.Clear();
          Console.WriteLine("Successful login...\n");
          CustomerDashboard(_cr.Read(CurrentUser));
        }
        public static void ManagerLogin()
        {
          Console.Clear();
          Manager CurrentUser = new Manager();
          Console.Write("Manager Email:");
          string email = Console.ReadLine();
          Console.Write("Manager Password:");
          string pass = Console.ReadLine();
          CurrentUser = _mr._managerList.Find(x => x.Email == email && x.Password == pass);
          if(CurrentUser == null)
          {
            Console.Clear();
            Console.WriteLine("No manager with that email/passord combination exists\nTry again\n");
            Start();
            return;
          }
          // CurrentUser.CurrentStore = _sr.Read(new Store("Pizza Planet", "Arlington, TX"));
          Console.Clear();
          Console.WriteLine("Successful login...\n");
          ManagerDashboard(CurrentUser);
        }
        public static void Register()
        {
          Console.Clear();
          Customer c = new Customer();
          Console.Write("First Name: ");
          c.FirstName = Console.ReadLine();
          Console.Write("Last Name: ");
          c.LastName = Console.ReadLine();
          Console.Write("Email: ");
          c.Email = Console.ReadLine();
          Console.Write("Password: ");
          c.Password = Console.ReadLine();
          Console.Write("Address: ");
          // c.Address = Console.ReadLine();

          if (_cr.Read(c) != null)
          {
            Console.Clear();
            Console.WriteLine("User with that email already exists\nTry again\n");
            
            Start();
            return;
          }

        
          _cr.Create(c);
          Console.WriteLine("Registration successful for {0}", c.FirstName);
          CustomerDashboard(c);
          // return;
        }
        public static void CustomerDashboard(Customer c)
        {
          Console.WriteLine("Welcome {0}", c.FirstName);
          Console.WriteLine("1. Start Order");
          Console.WriteLine("2. View order history");
          Console.WriteLine("3. Logout");
          Console.Write("What would you like to do:");
          int input = ValidateUserInput();
          switch (input)
          {
            case 1:
              StartOrder(c);
              break;
            case 2:
              CustomerOrderHistory(c);
              break;
            case 3:
              Console.WriteLine("Bye {0}", c.FirstName);
              Start();
              // return;
              break;
            default:
              CustomerDashboard(c);
              break;
          }
        }
        public static void ManagerDashboard(Manager m)
        {
          Console.WriteLine("Welcome {0} from {1}", m.FirstName, m.CurrentStore);
          Console.WriteLine("1. View store orders");
          Console.WriteLine("2. Change current store");
          Console.WriteLine("3. Logout");
          Console.Write("What would you like to do:");
          int input = ValidateUserInput();
          switch (input)
          {
            case 1:
              ViewStoreOrders(m);
              break;
            case 2:
              ChangeCurrentStore(m);
              break;
            case 3:
              Console.WriteLine("Bye {0}", m.FirstName);
              Start();
              // return;
              break;
            default:
              ManagerDashboard(m);
              break;
          }
        }
        public static void StartOrder(Customer c)
        {
          Console.Clear();
          if(AllowOrderTwoHrPd(c))
          {
            CustomerDashboard(c);
            return;
          }
          Store s = new Store();
          Order o = new Order();
          s = ChooseStore();
          if(AllowOrderTwentyFourHrPd(s, c))
          {
            CustomerDashboard(c);
            return;
          }
          Console.WriteLine("You chose to order from {0}", s);
          
          o = CreateOrder();
          if (o == null)
          {
            Console.WriteLine("Error...\n");
            CustomerDashboard(c);
            return;
          }
          o.StoreName = s.Name;
          o.CustomerId = c.Id;
          // confirm order
          s.AddOrder(o);
          // _sr.Update(s);
          c.AddOrder(o);


          // _or.Create(o);
          _cr.Update(c);

          Console.Clear();
          Console.WriteLine("Order placed successfully");
          o.PrintOrder();
          CustomerDashboard(c);
        }
        public static bool AllowOrderTwoHrPd(Customer c)
        {
          if(c.Orders.Count > 0)
          {
            TimeSpan now = DateTime.Now - c.Orders[c.Orders.Count-1].OrderDate ;
            if(now < new TimeSpan(0, 2, 0, 0))
            {
              now = new TimeSpan(2,0,0) - now;
              Console.WriteLine("Error...\nMust wait {0} minutes to order again", now);
              return true;
            }
          }
          return false;
        }
        public static bool AllowOrderTwentyFourHrPd(Store s, Customer c)
        {
          Order o = c.Orders.Find(x => x.StoreName == s.Name);
          if(o != null)
          {
            TimeSpan now = DateTime.Now - o.OrderDate;
            if(now < new TimeSpan(0, 24, 0, 0) && s.Name == o.StoreName)
            {
              now = new TimeSpan(24,0,0) - now;
              Console.WriteLine("Error...\nMust wait {0} minutes to order from {1} again\n", now, s);
              CustomerDashboard(c);
              return true;
            }
          }
          return false;
        }
        public static void CustomerOrderHistory(Customer c)
        {
          Console.Clear();
          c.ViewOrderHistory();
          CustomerDashboard(c);
        }
        public static Store ChooseStore()
        {
          Console.Clear();
          Console.WriteLine("Stores: ");
          Console.WriteLine("1. Pizza Planet      Arlington, TX");
          Console.WriteLine("2. Best Pizza        Dallas, TX");
          Console.WriteLine("3. Freddie's Pizza   Dallas, TX");
          Console.Write("Choose store: ");
          int input = ValidateUserInput();
          switch (input)
          {
            // case 1:
            //   return _sr.Read(new Store("Pizza Planet", "Arlington, TX"));
            // case 2:
            //   return _sr.Read(new Store("Best Pizza", "Dallas, TX"));
            // case 3:
            //   return _sr.Read(new Store("Freddie's Pizza", "Dallas, TX"));
            default:
              ChooseStore();
              break;
          }
          return ChooseStore();
        }

        public static Order CreateOrder()
        {
          Console.Write("How many pizzas do you want? ");
          int input = ValidateUserInput();
          if(input == -1 || input == 0 || input > 100)
          {
            if(input > 100)
              Console.WriteLine("Can't order more than 100 pizzas");
            return null;
          }
          Order newOrder = new Order();
          // List<Pizza> pList = new List<Pizza>();
          for(int i = 0; i < input; i++)
          {
            Pizza newPizza = CreatePizza();
            // if(newPizza == null)
            //   return null;
            if(!newOrder.AddPizza(newPizza))
            {
              return null;
            }
            // pList.Add(newPizza);
            Console.WriteLine("Your pizza is a {0}", newPizza);
          }
          // Order o = new Order(pList);
          // if(o.OrderTotal >= 250.00M)
          // {
          //   Console.Clear();
          //   Console.WriteLine("Order total can't be more than $250");
          //   return null;
          // }
          return newOrder;
        }
        static Pizza CreatePizza()
        {
          Console.WriteLine("1. Large Pepperoni Pizza           $9.99");
          Console.WriteLine("2. Large Cheese Pizza              $7.99");
          Console.WriteLine("3. Ultimate Pizza                  $250.00");
          Console.WriteLine("4. Create your own pizza           $4.99-$9.99");
          Console.Write("Choose option: ");
          int input = ValidateUserInput();
          switch (input)
          {
            case 1:
              return new Pizza("Large", "Thick", "Pepperoni");
            case 2:
              return new Pizza("Large", "Hand-tossed", "Cheese");
            case 3:
              return new Pizza("test", "Hand-tossed", "Pepperoni");
            case 4:
              return CustomizePizza();
            default:
              return CreatePizza();
          }
        }
        static Pizza CustomizePizza()
        {
          Pizza newPizza = new Pizza();
          // newPizza.Size = ChooseSize();
          if(!newPizza.ChooseSize() || !newPizza.ChooseCrust() || !newPizza.ChooseTopping())
            return null;
          // newPizza.Crust = ChooseCrust();
          // if(!newPizza.ChooseCrust())
          //   return null;
          // newPizza.Topping = ChooseTopping();
          // if(!newPizza.ChooseTopping())
          //   return null;
          
          return newPizza;
        }

        // static string ChooseSize()
        // {
        //   Console.WriteLine("Sizes: ");
        //   Console.WriteLine("1. Small     $4.99");
        //   Console.WriteLine("2. Medium    $7.99");
        //   Console.WriteLine("3. Large     $9.99");
        //   Console.Write("Choose size: ");
        //   int input = ValidateUserInput();
        //   switch (input)
        //   {
        //     case 1:
        //       return "Small";
        //     case 2:
        //       return "Medium";
        //     case 3:
        //       return "Large";
        //     default:
        //       ChooseSize();
        //       break;
        //   }
        //   return ChooseSize();
        // }

        // static string ChooseCrust()
        // {
        //   Console.WriteLine("Crusts: ");
        //   Console.WriteLine("1. Hand-tossed");
        //   Console.WriteLine("2. Thin");
        //   Console.WriteLine("3. Cheese-stuffed");
        //   Console.Write("Choose crust: ");
        //   int input = ValidateUserInput();
        //   switch (input)
        //   {
        //     case 1:
        //       return "Hand-tossed";
        //     case 2:
        //       return "Thin";
        //     case 3:
        //       return "Cheese-stuffed";
        //     default:
        //       ChooseCrust();
        //       break;
        //   }
        //   return ChooseCrust();
        // }

        // static string ChooseTopping()
        // {
        //   Console.WriteLine("Topping: ");
        //   Console.WriteLine("1. Pepperoni");
        //   Console.WriteLine("2. Chicken");
        //   Console.WriteLine("3. Beef");
        //   Console.Write("Choose topping: ");
        //   int input = ValidateUserInput();
        //   switch (input)
        //   {
        //     case 1:
        //       return "Pepperoni";
        //     case 2:
        //       return "Chicken";
        //     case 3:
        //       return "Beef";
        //     default:
        //       ChooseTopping();
        //       break;
        //   }
        //   return ChooseTopping();
        // }
        
        static void ViewStoreOrders(Manager m)
        {
          Console.Clear();
          m.CurrentStore.ViewStoreOrders();
          ManagerDashboard(m);
        }

        static void ChangeCurrentStore(Manager m)
        {
          m.CurrentStore = ChooseStore();
          ManagerDashboard(m);
        }

        // static Store SelectStore()
        // {
        //   return new Store("Best Pizza", "Dallas");
        // }

        public static int ValidateUserInput()
        {
          int input;
          try
          {
            input = Convert.ToInt32(Console.ReadLine());
          }
          catch (Exception e)
          {
            var a = e.Data;
            Console.WriteLine("Invalid input\nTry Again");
            return -1;
          }
          return input;
        }

    }
}
