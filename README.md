# Simple Factory

### Without using Simple Factory 

---
Observe a implementação abaixo, nela demonstrateremos uma abordagem sem a utilização do padrão Simple Factory e quais os problemas que tal implementação pode ocasionar.

> Classe Concreta Audi
```cs
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

``` 

> Classe Concreta Ferrari
```cs
public class Ferrari
{
    public string Name { get; set; }

    public Ferrari()
    {
        Name = $"Ferrari";
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
```

Note que trata-se de implementações comuns e que possuem comportamentos semelhantes.

Criamos a classe static **Dealership** onde teremos a implementação da **Escolha do Carro (ChooseCar)**

```cs
public static void ChooseCar()
{
    Console.WriteLine("==== Choose you Car ====");
    Console.WriteLine("1: Audi");
    Console.WriteLine("2: Ferrari");

    var chooserCar = Console.ReadLine();

    switch (chooserCar)
    {
        case "1":
            var audi = new Audi();
            audi.Make();
            audi.Sale();
            break;
        case "2":
            var ferrari = new Ferrari();
            ferrari.Make();
            ferrari.Sale();
            break;
        default:
            Console.WriteLine("Car does not exist!");
            break;
    }
}
```

Esse programa funciona e se executarmos a classe **Program**, podemos observar seu funcionamento correto. 

Saída do Console - Opção 1
```cs
==== Choose you Car ====
1: Audi
2: Ferrari
1
Built an Audi
Sold an Audi

```
Saída do Console - Opção 2
```cs
==== Choose you Car ====
1: Audi
2: Ferrari
2
Built an Ferrari
Sold an Ferrari

```

>Problemas dessa implementação
* Estamos programando para implementações e não para interfaces
* Forte acomplamento entre as classes
* O cliente conhece os detalhes de implementação
* Alteração no produto (Audi | Ferrari) exige alteração no cliente
* Vialoção do Open/Closed (SOLID)
---
### Using Simple Factory 