using deserializer;
using System.Diagnostics;
using System.Xml.Serialization;

int choose = 0;
while (choose != 3)
{
    while (choose < 1 || choose > 3)
    {
        Console.Clear();
        ShowOptions();
        choose = int.Parse(Console.ReadLine());
    }
    ChooseOne(choose);
    ShowOptions();
    choose = int.Parse(Console.ReadLine());
}
Console.WriteLine(new String('*',30));
Console.WriteLine("Program zakończył działanie");
Console.WriteLine(new String('*', 30));
Console.ReadKey();
static void ShowOptions()
{
    Console.WriteLine(new String('*', 30));
    Console.WriteLine("1\tDodaj samochód");
    Console.WriteLine("2\tWyświetl samochody");
    Console.WriteLine("3\tWyjdź");
    Console.WriteLine(new String('*', 30));
}
static void ChooseOne(int choose)
{
    List<Car> listOfCars = Deserialize();
    switch (choose)
    {
        case 1:
            AddCarsToList(listOfCars);
            Serialize(listOfCars);
            break;
        case 2:
            {
                ViewList(listOfCars);
            }
            break;
        case 3:
            {
                Environment.Exit(0);
            }
            break;
    }
}
static List<Car> AddCarsToList(List<Car> listOfCars)
{
    int choose = -1;
    while (choose < 0)
    {
        Console.Clear();
        Console.WriteLine("Ile samochodów chcesz dodać?\n0\tWyjście");
        choose = int.Parse(Console.ReadLine());
    }
    if (choose == 0) return null;
    for (int i = 0; i < choose; i++)
    {
        DisplayItLikeATable(i);
        Car car = AddNewCar();
        if(car != null)
        listOfCars.Add(car);
    }
    return listOfCars;
}
static void Serialize(List<Car> listOfCars)
{
    
    using (var writer = new StreamWriter(XmlFileName))
    {
        Serializer.Serialize(writer, listOfCars);
    }
}
static Car AddNewCar()
{
    string manufacturer, model, color, fuel;
    ushort year, engineSize;
    byte power, topSpeed;
    Car car=null;
    try
    {
        Console.WriteLine("Producent");
        manufacturer = Console.ReadLine();
        Console.WriteLine("Model");
        model = Console.ReadLine();
        Console.WriteLine("Rok produkcji");
        year = ushort.Parse(Console.ReadLine());
        Console.WriteLine("Rodzaj paliwa:");
        fuel = Console.ReadLine();
        Console.WriteLine("Pojemność silnika(cm3)");
        engineSize = ushort.Parse(Console.ReadLine());
        Console.WriteLine("Moc [KM]");
        power = byte.Parse(Console.ReadLine());
        Console.WriteLine("Prędkość maksymalna");
        topSpeed = byte.Parse(Console.ReadLine());
        Console.WriteLine("Kolor");
        color = Console.ReadLine();

        car = new Car
        {
            Manufacturer = manufacturer,
            Model = model,
            Year = year,
            Fuel = fuel,
            EngineSize = engineSize,
            Power = power,
            TopSpeed = topSpeed,
            Color = color
        };
        return car;

    }
    catch(Exception e)
    {
        Console.WriteLine("Nieprawidłowe dane");
        Console.WriteLine(e.Message);
        Console.WriteLine("Działanie programu zostało przerwane");
        Console.ReadKey();
        Environment.Exit(0);
    }
     
    return null;
}
static List<Car> Deserialize()
{
    List<Car> listOfCars = new List<Car>();
    using(var reader = new StreamReader(XmlFileName))
    {
        List<Car> loadedList=(List<Car>)Serializer.Deserialize(reader);
        listOfCars.AddRange(loadedList);
    }
    return listOfCars;
}
static void ViewList(List<Car> listOfCars)
{
    for(int i=0;i<listOfCars.Count;i++)
    {
        DisplayItLikeATable(i);
        Console.WriteLine($"Producent:\n\t{listOfCars[i].Manufacturer}");
        Console.WriteLine($"Model:\n\t{listOfCars[i].Model}");
        Console.WriteLine($"Rok produkcji:\n\t{listOfCars[i].Year}");
        Console.WriteLine($"Rodzaj paliwa:\n\t{listOfCars[i].Fuel}");
        Console.WriteLine($"Pojemność silnika [cm3]:\n\t{listOfCars[i].EngineSize}");
        Console.WriteLine($"Moc[KM]:\n\t{listOfCars[i].Power}");
        Console.WriteLine($"Prędkość maksymalna [km/h]:\n\t{listOfCars[i].TopSpeed}");
        Console.WriteLine($"Kolor:\n\t{listOfCars[i].Color}");
    }
}
static void DisplayItLikeATable(int i)
{
    Console.WriteLine(new String('-', 20));
    Console.WriteLine($"Samochód nr {i + 1}");
    Console.WriteLine(new String('-', 20));
}
public partial class Program
{
    private static XmlSerializer Serializer = new XmlSerializer(typeof(List<Car>));
    private static string XmlFileName = @"Car.xml";
}
