using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Adapters;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controllers
{
    [Route("/[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static UserRepository _ur = new UserRepository();
        private static OrderRepository _or = new OrderRepository();
        private static StoreRepository _sr = new StoreRepository();
        private static PizzaRepository _pr = new PizzaRepository();
        public static UserModel _currentUser = null;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
          return View();
        }

        public IActionResult Register(RegisterViewModel r)
        {
          if(_currentUser != null)
          {
            if(_currentUser.Admin)
              return RedirectToAction("AdminDashboard");
            else
              return RedirectToAction("UserDashboard");
          }
          return View(r);
        }

        [HttpPost]
        public IActionResult ValidateRegistration(RegisterViewModel r)
        {
          if(ModelState.IsValid)
          {
            UserModel newUser = new UserModel();
            newUser.FirstName = r.FirstName;
            newUser.LastName = r.LastName;
            newUser.Email = r.Email;
            newUser.Password = r.Password;
            newUser.Address.Street = r.Street;
            newUser.Address.City = r.City;
            newUser.Address.AddressState = r.State;
            newUser.Address.ZipCode = r.ZipCode;
            _ur.Create(newUser);
            return RedirectToAction("Login");
          }
          ViewBag.Error = "Registration failed. Try Again";
          return View("Register", r);
        }

        public IActionResult Login(LoginViewModel l)
        {
          if(_currentUser != null)
          {
            if(_currentUser.Admin)
              return RedirectToAction("AdminDashboard");
            else
              return RedirectToAction("UserDashboard");
          }
          return View(l);
        }

        [HttpPost]
        public IActionResult ValidateCredentials(LoginViewModel l)
        {
          if(_currentUser != null)
          {
            if(_currentUser.Admin)
              return RedirectToAction("AdminDashboard");
            else
              return RedirectToAction("UserDashboard");
          }
          if(ModelState.IsValid)
          {
            UserModel currentUser = _ur.Read(l.Email, l.Password);
            if(currentUser == null)
            {
              ViewBag.Error = "Login failed. Try Again";
              return View("login");
            }

            _currentUser = currentUser;

            if(_currentUser.Admin)
              return RedirectToAction("AdminDashboard");
            else
              return RedirectToAction("UserDashboard");
          }

          return RedirectToAction("Login");
        }

        public IActionResult AdminDashboard(AdminViewModel m)
        {
          if(ModelState.IsValid)
          {
            m.User = _currentUser;
            m.Store = _sr.Read(m.StoreSelected);
            m.Sum = _sr.GetSalesByMonth(m.Store, m.MonthSelected);
          }
          return View(m);
        }

        public IActionResult ViewStoreOrders(AdminViewModel m)
        {
          if(ModelState.IsValid)
          {
            m.User = _currentUser;
            m.Store = _sr.Read(m.StoreSelected);
            ViewBag.Store = _sr.Read(m.StoreSelected);
            return View(m);
          }
          return View(m);
        }

        public IActionResult ViewSales(AdminViewModel m)
        {
          if(ModelState.IsValid)
          {
            m.User = _currentUser;
            m.Store = _sr.Read(m.StoreSelected);
            ViewBag.Store = _sr.Read(m.StoreSelected);
            ViewBag.Sum = _sr.GetSalesByMonth(m.Store, m.MonthSelected);
            return View(m);
          }
          return View(m);
        }

        public IActionResult UserDashboard()
        {
          if(_currentUser == null)
            return RedirectToAction("login");
          return View("UserDashboard", _currentUser);
        }

        

        public IActionResult StartOrder()
        {
          if(_currentUser == null)
          {
            return RedirectToAction("login");
          }
          ViewBag.User = _currentUser;
          return View(new OrderViewModel());
        }
        
        [HttpPost()]
        public IActionResult Order(OrderViewModel o)
        {
          if(ModelState.IsValid)
          {
            if(_currentUser == null)
              return RedirectToAction("login");
            OrderModel newOrder = new OrderModel();
            newOrder.User = _currentUser;
            newOrder.StoreName = o.Store;
            newOrder.OrderDate = DateTime.Now;
            newOrder.TotalCost = 0;
            for (int i =0; i< o.Quantity;i++ )
            {
              PizzaModel newPizza = new PizzaModel();
              newPizza.Crust = o.Crust;
              newPizza.Size = o.Size;
              newPizza.Cost = _pr.ReadSize(o.Size).Price + _pr.ReadCrust(o.Crust).Price;
              if(o.Topping != null)
              {
                newPizza.Toppings.Add(o.Topping);
                newPizza.Cost += _pr.ReadTopping(o.Topping).Price;
              }
              newOrder.TotalCost += newPizza.Cost;
              if(newOrder.TotalCost >= 250M)
              {
                return RedirectToAction("UserDashboard");
              }
              newOrder.Pizzas.Add(newPizza);
            }
            _currentUser.Orders.Add(newOrder);
            _or.Create(newOrder);
            return RedirectToAction("UserDashboard");
          }
          ViewBag.User = _currentUser;
          return View("StartOrder", o);
        }

        public IActionResult ViewOrders()
        {
          if(_currentUser == null)
          {
            return RedirectToAction("login");
          }
          ViewBag.User = _currentUser;
          return View();
        }

        public IActionResult Logout()
        {
          _currentUser = null;
          return RedirectToAction("index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
