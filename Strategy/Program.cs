namespace Strategy; // Strategiya


interface ISerializer
{
    void Serialize();
}


class JsonSerializer : ISerializer
{
    public void Serialize()
        => Console.WriteLine("Json Serialize");
}


class XMLSerializer : ISerializer
{
    public void Serialize()
        => Console.WriteLine("XML Serialize");
}


class BinarySerializer : ISerializer
{
    public void Serialize()
        => Console.WriteLine("Binary Serialize");
}


class Context
{
    private readonly ISerializer _serializer;

    public Context(ISerializer serializer)
        => _serializer = serializer;

    public void Serialize()
        => _serializer.Serialize();
}


class Program
{
    static void Main()
    {
        Context _context = new Context(new BinarySerializer());
        _context.Serialize();
    }
}