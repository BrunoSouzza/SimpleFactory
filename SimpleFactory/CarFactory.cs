namespace SimpleFactory
{
    public sealed class CarFactory
    {
        public static Car Create(string type)
        {
            return type switch
            {
                "1" => new Audi(),
                "2" => new Ferrari(),
                _ => throw new ApplicationException($"The car {type} not found"),
            };

        }
    }
}
