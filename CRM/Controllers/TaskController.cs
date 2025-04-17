using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRM.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ClientCount = 12;
            ViewBag.DealCount = 5;
            ViewBag.ReminderCount = 3;

            return View();
        }
    }

}
