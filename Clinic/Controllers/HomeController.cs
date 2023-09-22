using BLL.Interface;
using Clinic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Clinic.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDashboardRep dash;

        public HomeController(IDashboardRep dash)
        {
            this.dash = dash;
        }

        public IActionResult Index()
        {
            return View();
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


        // Ajax
        [HttpGet]
        public JsonResult Chart()
        {
            var ChartData = dash.GetAll();
            return Json(ChartData);
        }
    }
}