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

        // Создаём словарь с пустыми списками для всех стадий
        var dealsByStage = allStages.ToDictionary(
            stage => stage,
            stage => new List<Deal>()
        );

        // Добавляем сделки в соответствующие стадии
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

}
