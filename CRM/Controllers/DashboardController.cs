using CRM.DAL;
using CRM.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM.Controllers
{

    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new DashboardViewModel
            {
                TotalClients = _context.Clients.Count(),
                TotalDeals = _context.Deals.Count()
            };

            return View(model);
        }

    }

}
