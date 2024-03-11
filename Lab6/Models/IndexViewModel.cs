namespace Lab6.Models;

public class IndexViewModel
{
    public IndexViewModel(int? age)
    {
        Age = age;
    }

    public int? Age { get; set; }
}