using CRM.Domain.Entity;
using CRM.Domain.ViewModels;

public enum DealStage
{
    Incoming,
    InProduction,
    Canceled,
    Completed
}

public class Deal
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public DealStage Stage { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public int UserId { get; set; } // текущий пользователь
    public User User { get; set; } = null!;

    public int? ReceiverId { get; set; } // пока не используется
    public User? Receiver { get; set; }
}

