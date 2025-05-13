using System.Text.Json;

Console.WriteLine("======================================================================");
Console.WriteLine("===Study of the monitor class with Pulse, PulseAll and Wait methods===");
Console.WriteLine("======================rodolfo0ti@gmail.com============================");

var numberOfConsumers = 1;
var numberOfProducers = 3;

var myBuffer = new MyBuffer();

for (int i = 1; i <= numberOfProducers; i++)
{
    Thread t = new Thread(() => ProduceMessages(myBuffer));
    t.Name = $"Producer Th#{i}";
    t.Start();
}

for (int i = 1; i <= numberOfConsumers; i++)
{
    Thread t = new Thread(() => ConsumeMessages(myBuffer));
    t.Name = $"Consumer Th#{i}";
    t.Start();
}

void ConsumeMessages(MyBuffer myBuffer)
{
    while (true)
    {
        var msg = myBuffer.Consume();
        var person = JsonSerializer.Deserialize<Person>(msg);

        Console.WriteLine($"{person!.Name} was consumed by: {Thread.CurrentThread.Name}");

        Pause();
    }
}

void ProduceMessages(MyBuffer myBuffer)
{
    string[] name = new string[]
        {
            "Alice", "Bob", "Charlie", "David", "Eva",
            "Frank", "Grace", "Hank", "Ivy", "Jack",
            "Kelly", "Leo", "Mia", "Nathan", "Olivia",
            "Paul", "Quinn", "Rachel", "Sam", "Tina",
            "Ulysses", "Victoria", "Walter", "Xena", "Yasmine",
            "Zane", "Amy", "Ben", "Cynthia", "Derek",
            "Emily", "Felix", "Gina", "Henry", "Isabel",
            "Jason", "Karen", "Liam", "Megan", "Nolan",
            "Oscar", "Pamela", "Quincy", "Rita", "Steve",
            "Trevor", "Uma", "Vincent", "Wendy", "Xavier"
        };

    while (true)
    {
        var rand = new Random().Next(1, name.Length);
        var strPerson = JsonSerializer.Serialize(new Person(name[rand], rand, Thread.CurrentThread.Name!));
        myBuffer.Produce(strPerson);
        myBuffer.ShowLog();

        Pause();
    }
}

void Pause()
{
    Thread.Sleep(2000);
}

public class MyBuffer
{
    const short MaxMessage = 10;
    Queue<string> Messages = new Queue<string>();
    readonly object key = new object();

    public void Produce(string message)
    {
        lock (key)
        {
            while (Messages.Count >= MaxMessage)
                Monitor.Wait(key);

            Messages.Enqueue(message);
            Monitor.PulseAll(key);
        }
    }

    public string Consume()
    {
        lock (key)
        {
            while (Messages.Count <= 0)
                Monitor.Wait(key);

            var msg = Messages.Dequeue();
                Monitor.PulseAll(key);

            return msg;
        }
    }

    public void ShowLog()
    {
        lock (key)
        {
            Console.Write($"\n\nNa fila => ({Messages.Count}) \n");
            Messages.ToList().ForEach(x =>
            {
                Console.WriteLine(x);
            });
        }
    }
}

public class Person
{
    public Person(string name, int age, string producer) =>
        (Name, Age, Producer) = (name, age, producer);

    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Producer { get; set; }

    public override string ToString() =>
        $"Person: {Name} - Age {Age}";
}