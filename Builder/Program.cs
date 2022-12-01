/*
using System.Text;


namespace Builder;


// Product
// IBuilder
// ConcreteBuilder1, ConcreteBuilder2
// Director (Optional)


class House
{
    public string? Name { get; set; }
    public int Walls { get; set; }
    public int Doors { get; set; }
    public int Windows { get; set; }
    public bool HasRoof { get; set; }
    public bool HasGarage { get; set; }
    public bool HasGarden { get; set; }
    public bool HasPool { get; set; }

    public override string ToString()
    => @$"
        Name {Name}
        Walls {Walls}
        Doors {Doors}
        Windows {Windows}
        HasRoof {HasRoof}
        HasGarage {HasGarage}
        HasGarden {HasGarden}
        HasPool {HasPool}";
}


interface IHouseBuilder
{
    House House { get; set; }

    IHouseBuilder BuildWalls(int count);
    IHouseBuilder BuildDoors(int count);
    IHouseBuilder BuildWindows(int count);
    IHouseBuilder BuildRoof();
    IHouseBuilder BuildGarage();
    IHouseBuilder BuildGarden();
    IHouseBuilder BuildPool();

    void Reset();
    House Build();
}


class WoodHouseBuilder : IHouseBuilder
{
    public House House { get; set; }

    public WoodHouseBuilder()
    {
        House = new House { Name = "WoodHouse" };
    }

    public IHouseBuilder BuildDoors(int count)
    {
        House.Doors = count;
        return this;
    }
    public IHouseBuilder BuildGarage()
    {
        House.HasGarage = true;
        return this;
    }
    public IHouseBuilder BuildGarden()
    {
        House.HasGarden = true;
        return this;
    }
    public IHouseBuilder BuildPool()
    {
        House.HasPool = true;
        return this;
    }
    public IHouseBuilder BuildRoof()
    {
        House.HasRoof = true;
        return this;
    }
    public IHouseBuilder BuildWalls(int count)
    {
        House.Walls = count;
        return this;
    }
    public IHouseBuilder BuildWindows(int count)
    {
        House.Windows = count;
        return this;
    }
    public House Build()
    {
        var result = House;
        Reset();
        return result;
    }

    public void Reset() => House = new House();
}


class StoneHouseBuilder : IHouseBuilder
{
    public House House { get; set; }


    public StoneHouseBuilder()
    {
        House = new House { Name = "StoneHouse" };
    }

    public IHouseBuilder BuildDoors(int count)
    {
        House.Doors = count;
        return this;
    }
    public IHouseBuilder BuildGarage()
    {
        House.HasGarage = true;
        return this;
    }
    public IHouseBuilder BuildGarden()
    {
        House.HasGarden = true;
        return this;
    }
    public IHouseBuilder BuildPool()
    {
        House.HasPool = true;
        return this;
    }
    public IHouseBuilder BuildRoof()
    {
        House.HasRoof = true;
        return this;
    }
    public IHouseBuilder BuildWalls(int count)
    {
        House.Walls = count;
        return this;
    }
    public IHouseBuilder BuildWindows(int count)
    {
        House.Windows = count;
        return this;
    }

    public House Build()
    {
        var result = House;
        Reset();
        return result;
    }

    public void Reset() => House = new House();
}


// optional
class Director
{
    private IHouseBuilder _builder;
    public Director(IHouseBuilder builder)
    {
        _builder = builder;
    }

    public void ChangeBuilder(IHouseBuilder builder)
        => _builder = builder;


    public House BuildMinimalHouse()
        => _builder.BuildWalls(4)
            .BuildDoors(1)
            .BuildWindows(2)
            .BuildRoof()
            .Build();

    public House BuildFullFeaturedHouse()
        => _builder.BuildWalls(12)
            .BuildDoors(3)
            .BuildWindows(6)
            .BuildGarage()
            .BuildGarden()
            .BuildPool()
            .BuildRoof()
            .Build();
}


class Program
{
    static void Main()
    {
        IHouseBuilder builder = new WoodHouseBuilder();

        // House house = builder
        //     .BuildGarage()
        //     .BuildDoors(2)
        //     .BuildWalls(7)
        //     .BuildGarden()
        //     .Build();

        Director director = new(new WoodHouseBuilder());
        // director.ChangeBuilder(new StoneHouseBuilder());

        House house;

        house = director.BuildMinimalHouse();
        house = director.BuildFullFeaturedHouse();

        Console.WriteLine(house);

        // FluentValidation 
        //     StringBuilder sb = new();
        // 
        //     string fullname = sb
        //         .Append("Tural")
        //         .Append(" ")
        //         .Append("Novruzov")
        //         .ToString();
        // 
        //     Console.WriteLine(fullname); 
    }
}
*/





// Task
//
// EndPointBuilder
// -baseUrl: string
// -routeParameters: StringBuilder
// -queryStrings: StringBuilder
// +EndPointBuilder(baseUrl:string)
// +AppendRoute(route: string) : EndPointBuilder
// +AppendQueryString(key: string, value: string) : EndPointBuilder
// +Build() : string




using System.Text;

class EndPointBuilder
{
    private string baseUrl;

    private StringBuilder routeParameters;
    private StringBuilder queryStrings;

    public EndPointBuilder(string baseUrl)
    {
        this.baseUrl = baseUrl;
        routeParameters = new();
        queryStrings = new();
    }

    public EndPointBuilder AppendRoute(string route)
    {
        routeParameters.Append('/');
        routeParameters.Append(route);
        return this;
    }

    public EndPointBuilder AppendQueryString(string key, string value)
    {
        queryStrings.Append(key);
        queryStrings.Append('=');
        queryStrings.Append(value);
        queryStrings.Append('&');
        return this;
    }

    public string Build()
    {
        var url = $"{baseUrl}{routeParameters}";

        if (queryStrings.Length > 0)
            url += $"?{queryStrings.ToString().TrimEnd('&')}";

        return url;
    }
}


class Program
{
    static void Main()
    {
        EndPointBuilder builder = new("https://www.logbook.itstep.org");

        string url = builder
            .AppendRoute("api")
            .AppendRoute("v1")
            .AppendRoute("students")
            .AppendQueryString("name", "Nur")
            .AppendQueryString("surname", "Huseyn")
            .Build();

        Console.WriteLine(url);
    }
}