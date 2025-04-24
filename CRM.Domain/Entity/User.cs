public class User
{
    public int Id { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    public string PasswordHash { get; set; }

    public List<Deal> Deals { get; set; }  // связь с их сделками
    public List<Deal> ReceivedDeals { get; set; }

}
