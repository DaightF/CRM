using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// EF Core
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("TempDb"));

// Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

var app = builder.Build();

// Seed test data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    var user = new ApplicationUser
    {
        Id = Guid.NewGuid().ToString(),
        UserName = "manager@crm.kz",
        Email = "manager@crm.kz"
    };
    db.Users.Add(user);

    db.Clients.AddRange(
        new Clients { Id = 1, Name = "ТОО Ромашка", Phone = "87775556666" },
        new Clients { Id = 2, Name = "ИП Иванов", Phone = "87001234567" }
    );

    db.Deals.AddRange(
        new Deal
        {
            Title = "Входящий звонок",
            Description = "Консультация по CRM",
            Amount = 2500,
            CreatedAt = DateTime.Now.AddDays(-2),
            Stage = DealStage.Incoming,
            User = user
        },
        new Deal
        {
            Title = "Оформление торгового зала",
            Description = "Подбор мебели и дизайна",
            Amount = 7500,
            CreatedAt = DateTime.Now.AddDays(-1),
            Stage = DealStage.InProduction,
            User = user
        },
        new Deal
        {
            Title = "Изготовление вывески",
            Description = "Установка и печать",
            Amount = 7246,
            CreatedAt = DateTime.Now,
            Stage = DealStage.Completed,
            User = user
        }
    );

    db.SaveChanges();
}

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "login",
    pattern: "Account/Login/{returnUrl?}",
    defaults: new { controller = "Account", action = "Login" });

app.Run();
