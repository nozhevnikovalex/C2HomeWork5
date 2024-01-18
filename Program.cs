using System;


class Play : IDisposable
{
    public string Name { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int Year { get; set; }

    // Конструктор класу
    public Play(string name, string author, string genre, int year)
    {
        Name = name;
        Author = author;
        Genre = genre;
        Year = year;
    }

    public void Info()
    {
        Console.WriteLine($"Назва: {Name}");
        Console.WriteLine($"Автор: {Author}");
        Console.WriteLine($"Жанр: {Genre}");
        Console.WriteLine($"Рік: {Year}");
    }

    public void Dispose()
    {
        Console.WriteLine($"Play {Name} has been disposed.");
        // Additional logic for resource disposal can be implemented here
    }

    // Деструктор класу
    ~Play()
    {
        Console.WriteLine($"Об'єкт {Name} утилізований.");
        Dispose();
    }
}

// Store type enumeration
enum StoreType
{
    Grocery,
    Household,
    Clothing,
    Footwear
}

class Store : IDisposable
{
    // Properties of the class
    public string Name { get; set; }
    public string Address { get; set; }
    public StoreType Type { get; set; }

    // Class constructor
    public Store(string name, string address, StoreType type)
    {
        Name = name;
        Address = address;
        Type = type;
    }

    // Method to display information about the store
    public void Info()
    {
        Console.WriteLine($"Store Name: {Name}");
        Console.WriteLine($"Address: {Address}");
        Console.WriteLine($"Store Type: {Type}");
    }

    // Implementation of the Dispose method from the IDisposable interface
    public void Dispose()
    {
        DisposeResources();
        GC.SuppressFinalize(this); // Remove the object from the finalization queue
    }

    // Method to dispose of resources
    private void DisposeResources()
    {
        Console.WriteLine($"Store {Name} has been disposed.");
        // Additional logic for resource disposal can be implemented here
    }

    // Destructor of the class (called during automatic disposal)
    ~Store()
    {
        Console.WriteLine($"Store {Name} has been finalized.");
        DisposeResources();
    }
}



class Program
{
    static void Main()
    {
        // Play class testing
        Test1();

        Test2();
                

        // Checking Dispose for manual disposal
        Store store2 = new Store("Household Store 2", "Work St, 456", StoreType.Household);
        store2.Info();
        store2.Dispose();

        GC.Collect();        
        Console.Read();
    }

    static void Test1()
    {
        Play play1 = new Play("Трагедія короля Ліра", "Вільям Шекспір", "Трагедія", 1606);
        play1.Info();
    }

    static void Test2()
    {
        Store store1 = new Store("Supermarket 1", "Main St, 123", StoreType.Grocery);
        store1.Info();
    }

}
