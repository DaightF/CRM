using CRM.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


public class DealController : Controller
{
    private readonly AppDbContext _context;

    public DealController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var deals = _context.Deals
            .Include(d => d.User)
            .ToList();

        var allStages = Enum.GetValues(typeof(DealStage)).Cast<DealStage>();

        var dealsByStage = allStages.ToDictionary(
            stage => stage,
            stage => new List<Deal>()
        );

        foreach (var deal in deals)
        {
            dealsByStage[deal.Stage].Add(deal);
        }

        var viewModel = new DealBoardViewModel
        {
            DealsByStage = dealsByStage
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult UpdateStage(int dealId, DealStage newStage)
    {
        var deal = _context.Deals.FirstOrDefault(d => d.Id == dealId);
        if (deal == null)
        {
            return NotFound();
        }

        deal.Stage = newStage;
        _context.SaveChanges();

        return Ok(new { success = true });
    }

    [HttpPost]
    public IActionResult CreateFromBoard(CreateDealViewModel model)
    {
        if (!ModelState.IsValid)
            return RedirectToAction("Board");

        int? userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null)
            return RedirectToAction("Login", "Account");

        var deal = new Deal
        {
            Title = model.Title,
            Description = model.Description,
            Amount = model.Amount,
            CreatedAt = DateTime.Now,
            Stage = model.Stage,
            UserId = userId.Value // текущий пользователь — создатель
        };

        _context.Deals.Add(deal);
        _context.SaveChanges();

        return RedirectToAction("Index", "Deal");
    }





}
