using CRM.Domain.Entity;
using CRM.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;

public class AccountController : Controller
{
    private readonly AppDbContext _context;

    public AccountController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);
        if (user == null || user.PasswordHash != HashPassword(model.Password))
        {
            ModelState.AddModelError("", "Неверный email или пароль");
            return View(model);
        }

        HttpContext.Session.SetInt32("UserId", user.Id);

        if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
            return Redirect(model.ReturnUrl);

        return RedirectToAction("Index", "Deal");
    }

    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public IActionResult Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        if (_context.Users.Any(u => u.Email == model.Email))
        {
            ModelState.AddModelError("Email", "Email уже зарегистрирован");
            return View(model);
        }

        var newUser = new User
        {
            Email = model.Email,
            UserName = model.Email.Split('@')[0],
            PasswordHash = HashPassword(model.Password)
        };

        _context.Users.Add(newUser);
        _context.SaveChanges();

        HttpContext.Session.SetInt32("UserId", newUser.Id);

        return RedirectToAction("Index", "Deal");
    }

    [HttpPost]
    public IActionResult Logout()
    {
        HttpContext.Session.Remove("UserId");
        return RedirectToAction("Login", "Account");
    }



    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
}
