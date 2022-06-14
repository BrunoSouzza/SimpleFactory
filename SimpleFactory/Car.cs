namespace SimpleFactory
{
    public abstract class Car
    {
        public string? Name { get; set; }
        public abstract void Make();
        public abstract void Sale();
    }
}
