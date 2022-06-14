namespace SimpleFactory
{
    public class Ferrari : Car
    {
        public Ferrari()
        {
            Name = $"Ferrari";
        }

        public override void Make()
        {
            Console.WriteLine($"Buil an {Name}");
        }

        public override void Sale()
        {
            Console.WriteLine($"Sold an {Name}");
        }
    }
}
