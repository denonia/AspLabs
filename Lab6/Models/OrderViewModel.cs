namespace Lab6.Models;

public class OrderViewModel
{
    public OrderViewModel(User user, int articleAmount)
    {
        User = user;
        ArticleAmount = articleAmount;
    }

    public User User { get; set; }
    public int ArticleAmount { get; set; }
}