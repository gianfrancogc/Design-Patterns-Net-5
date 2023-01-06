using BuilderDemoMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BuilderDemoMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlanDirector _director;

        public HomeController(IPlanDirector director)
        {
            _director = director;
        }


        public IActionResult Index()
        {
            PricingPlansModel model = new PricingPlansModel();

            // Build Basic Plan

            var basicPlanBuilder = new BasicPlanBuilder();
            _director.SetPlanBuilder(basicPlanBuilder);
            _director.BuildBasicPlan();
            model.BasicPlan = basicPlanBuilder.GetPlan();

            var enterprisePlanBuilder = new EnterprisePlanBuilder();
            _director.SetPlanBuilder(enterprisePlanBuilder);
            _director.BuildEnterprisePlan();
            model.EnterprisePlan = enterprisePlanBuilder.GetPlan();

            // Build Custom Plan 

            var customPlanBuilder = new BasicPlanBuilder();
            customPlanBuilder.BuildDiskSpaceFeature();
            customPlanBuilder.BuildBandwidthFeature();
            model.CustomPlan = customPlanBuilder.GetPlan();
            return View(model);
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
