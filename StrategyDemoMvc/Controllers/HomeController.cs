using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StrategyDemoMvc.Models;
using StrategyDemoMvc.Strategy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyDemoMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IShippingContext _shippingContext;

        public HomeController(IShippingContext shippingContext)
        {
            _shippingContext = shippingContext;
        }

        public IActionResult Index()
        {
            var model = GetOrderDetails();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(CheckoutModel model)
        {
            model.ShippingMethods = GetShippingMethods();

            switch (model.SelectedMethod)
            {
                case 1:
                    _shippingContext.SetStrategy(new FreeShippingStrategy());
                    break;
                case 2:
                    _shippingContext.SetStrategy(new LocalShippingStrategy());
                    break;
                case 3:
                    _shippingContext.SetStrategy(new WorldwideShippingStrategy());
                    break;
            }

            model.FinalTotal = _shippingContext.ExecuteStrategy(model.OrderTotal);

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private List<ShippingMethod> GetShippingMethods()
        {
            return new List<ShippingMethod>()
    {
        new ShippingMethod()
        {
            Id = 1,
            Name="Free Shipping ($0.00)"
        },
        new ShippingMethod() {
            Id = 2,
            Name="Local Shipping ($10.00)"
        },
        new ShippingMethod() {
            Id = 3,
            Name="Worldwide Shipping ($50.00)"
        }
    };
        }

        private CheckoutModel GetOrderDetails()
        {
            var model = new CheckoutModel()
            {
                OrderTotal = 100.00m,
                ShippingMethods = GetShippingMethods()
            };
            return model;
        }
    }
}
