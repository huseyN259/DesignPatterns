namespace TemplateMethod;


abstract class SQLEngine
{
    public void TemplateMethod()
    {
        Connect();
        ExecuteCommand();
        CloseConnection();
    }

    public abstract void Connect();
    public abstract void ExecuteCommand();
    public abstract void CloseConnection();
}


class MsSql : SQLEngine
{
    public override void Connect()
        => Console.WriteLine("MsSql Connect");

    public override void ExecuteCommand()
        => Console.WriteLine("MsSql ExecuteCommand");

    public override void CloseConnection()
        => Console.WriteLine("MsSql CloseConnection");
}

class MySql : SQLEngine
{
    public override void Connect()
        => Console.WriteLine("MySql Connect");

    public override void ExecuteCommand()
        => Console.WriteLine("MySql ExecuteCommand");

    public override void CloseConnection()
        => Console.WriteLine("MySql CloseConnection");
}

class Program
{
    static void Main()
    {
        MsSql msSql = new MsSql();
        msSql.TemplateMethod();

        MySql mySql = new MySql();
        mySql.TemplateMethod();
    }
}