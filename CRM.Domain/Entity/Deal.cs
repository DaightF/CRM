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
    public string Title { get; set; }       // новое
    public string Description { get; set; } // новое
    public DateTime CreatedAt { get; set; } // новое
    public DealStage Stage { get; set; }    // новое

    public int Amount { get; set; }

    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
}
