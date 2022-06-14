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

---
Um **Simple Factory** permite usar interfaces para criar objetos sem expor a lógica da criação do objeto ao cliente.

> Classe Car

```cs
public abstract class Car
{
    public string? Name { get; set; }
    public abstract void Make();
    public abstract void Sale();
}
```

Note que criamos um classe abastrata permitindo que um classe concreta lhe herde e realize as implementações **Make()**, **Sale()** e **Name**.

>Classe Audi
```cs
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
```
>Classe Ferrari
```cs
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
```
Fazemos agora a implementação da classe abstrata **Car** nas classes concretas **Audi** e **Ferrari**.

>Classe CarFactory
```cs
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
```
Note que criamos essa classe sealed para garantir que ninguem a herde. Criamos um método Create, que terá a responsabilidade de criar o Carro baseado no tipo.

> Classe Dealership
```cs
 public class Dealership
{
    public static void ChooseCar()
    {
        Console.WriteLine("==== Choose you Car ====");
        Console.WriteLine("1: Audi");
        Console.WriteLine("2: Ferrari");

        var chooserCar = Console.ReadLine();

        try
        {
            var car = CarFactory.Create(chooserCar);
            car.Make();
            car.Sale();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }
}
```
Observe que agora não temos mais o detalhe da implementação do lado do cliente, pois centralizamos a criação dos objetos em um local, facilitando a manutenção.

>Benéfícios dessa implementação
* Estamos programando para interfaces e não para implementações
* Fraco acomplamento entre as classes
* Centralizamos a criação dos objetos
* Cliente não conhece a implementação