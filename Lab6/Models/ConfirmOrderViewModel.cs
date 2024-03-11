namespace Lab6.Models;

public class ConfirmOrderViewModel
{
    public ConfirmOrderViewModel(Product[] products)
    {
        Products = products;
    }

    public Product[] Products { get; set; }
}