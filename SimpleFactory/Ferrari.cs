namespace SimpleFactory
{
    public class Ferrari
    {
        public string Name { get; set; }

        public Ferrari()
        {
            Name = $"Ferrari";
        }

        public void Make()
        {
            Console.WriteLine($"Buil an {Name}");
        }

        public void Sale()
        {
            Console.WriteLine($"Sold an {Name}");
        }
    }
}
