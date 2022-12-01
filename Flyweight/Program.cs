namespace Flyweight;

abstract class Player
{
    public string? Name { get; set; }
    public int AttackPoint { get; set; }
    public short Health { get; set; }

    public abstract void Display();
}

class Archer : Player
{
    public Archer()
    {
        Name = "Archer";
        AttackPoint = 95;
        Health = 480;
    }

    public override void Display()
        => Console.WriteLine("Archer created");
}

class Warrior : Player
{
    public Warrior()
    {
        Name = "Warrior";
        AttackPoint = 80;
        Health = 650;
    }

    public override void Display()
        => Console.WriteLine("Warrior created");
}

class FlyWeightFactory
{
    private Dictionary<string, Player?> _units = new();

    public Player? GetUnit(string key)
    {
        Player? unit = null;

        if (_units.ContainsKey(key))
            unit = _units[key];
        else
        {
            unit = key switch
            {
                "Archer" => new Archer(),
                "Warrior" => new Warrior(),
                _ => null
            };

            _units.Add(key, unit);
        }

        return unit;
    }
}

class Program
{
    static void Main()
    {
        FlyWeightFactory factory = new();
        List<Player?> units = new();

        for (int i = 0; i < 1000000; i++)
        {
            // units.Add(new Archer());
            // units.Add(new Warrior());

            units.Add(factory?.GetUnit("Archer"));
            units.Add(factory?.GetUnit("Warrior"));

            // Console.WriteLine(units.Last()?.GetHashCode());
        }

        Console.WriteLine("Terminated");
        Console.ReadKey();
    }
}