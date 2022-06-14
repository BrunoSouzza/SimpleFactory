namespace SimpleFactory;

public class Audi
{
    public string Name { get; set; }

    public Audi()
    {
        Name = "Audi";
    }

    public void Make()
    {
        Console.WriteLine($"Built an {Name}");
    }

    public void Sale()
    {
        Console.WriteLine($"Sold an {Name}");
    }
}
