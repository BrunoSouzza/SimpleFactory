namespace SimpleFactory;

public class Audi : Car
{
    public Audi()
    {
        Name = "Audi";
    }

    public override void Make()
    {
        Console.WriteLine($"Built an {Name}");
    }

    public override void Sale()
    {
        Console.WriteLine($"Sold an {Name}");
    }
}
