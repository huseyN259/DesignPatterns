namespace Observer; // Müşahidəçi

// Also known as: Event-Subscriber, Listener
// Subject   - Publisher 
// Observers - Subscribers
// Publisher

class ProductManager
{
    private readonly List<IObserver> _observers = new();

    public void UpdatePrice(string message)
        => Notify(message);

    public void Attach(IObserver observer)
        => _observers.Add(observer);

    public void Detach(IObserver observer)
        => _observers.Remove(observer);

    private void Notify(string message)
    {
        foreach (var observer in _observers)
            observer.Update(message);
    }
}


// Observers
interface IObserver
{
    void Update(string message);
}


class CustomerObserver : IObserver
{
    public void Update(string message)
        => Console.WriteLine($"Message to customer: {message}");
}


class EmployeeObserver : IObserver
{
    public void Update(string message)
        => Console.WriteLine($"Message to employee: {message}");
}


class Program
{
    static void Main()
    {
        ProductManager productManager = new ProductManager();

        var customer = new CustomerObserver();
        var employee = new EmployeeObserver();

        productManager.Attach(customer);
        productManager.Attach(employee);

        productManager.UpdatePrice("Product price changed!");

        productManager.Detach(employee);
        Console.WriteLine();

        productManager.UpdatePrice("Discount 50%");
    }
}