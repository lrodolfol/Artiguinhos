System.Console.Clear();
static void SumNumber(int numero)
{
    Console.WriteLine("====Sum===");
    for (int i = 1; i <= 10; i++)
    {
        Console.WriteLine("{0} + {1} = {2}", numero, i, (numero + i));
        Thread.Sleep(1000);
    }
}

static void MultiplyNumber(int numero)
{
    Console.WriteLine("====Multiply===");
    for (int i = 1; i <= 10; i++)
    {
        Console.WriteLine("{0} * {1} = {2}", numero, i, (numero * i));
        Thread.Sleep(1000);
    }
}

Number.GeneratedNumber sum = new Number.GeneratedNumber(SumNumber);
Number.GeneratedNumber multiply = new Number.GeneratedNumber(MultiplyNumber);
Random r = new Random();

while (true)
{
    int n = r.Next(11);
    sum(n);
    multiply(n);
}

public class Number
{
    public delegate void GeneratedNumber(int number); 
}