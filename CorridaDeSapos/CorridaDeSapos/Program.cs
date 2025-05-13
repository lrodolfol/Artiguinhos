Console.WriteLine("====Welcome to !====");
Console.WriteLine("====Façam suas");



public class Corrida
{
    int maxDistance;
    Toad[] toads;
    CountdownEvent countdown;

    public Corrida(int maxDistance, Toad[] totalToad)
    {
        this.maxDistance = maxDistance;
        this.toads = totalToad;
        countdown = new CountdownEvent(this.toads.Length);

        for (int i = 0; i < totalToad.Length; i++)
        {
            toads[i] = new Toad($"Thread #{i+1}");
            toads[i].ArrivedEvent += ToadArrived;
        }


        Console.WriteLine($"End of {nameof(Corrida)}");
    }

    public void ToadArrived(Toad toad)
    {

    }

    public void Run()
    {
        for (int i = 0; i < toads.Length; i++)
        {
            Thread t = new Thread(() => toads[i].Jump(this.maxDistance, countdown));
            t.Start();
        }

        countdown.Wait();
    }
}

public class Toad
{
    public string Name { get; private set; }
    public int Distance { get; set; }
    public TimeSpan Time { get; set; }
    public event Action<Toad> ArrivedEvent;

    public Toad(string name)
    {
        Name = name;
    }

    private static Random random = new Random();
    public void Jump(int maxDistance, CountdownEvent countdown)
    {
        while(true)
        {
            Distance += random.Next(30);
            Console.WriteLine("{0} pulou {1:000} centimetos", Name, Distance);

            if (Distance > maxDistance)
            {
                ArrivedEvent(this);
                break;
            }
        }

        countdown.Signal();
        Thread.Sleep(1000);
    }
}