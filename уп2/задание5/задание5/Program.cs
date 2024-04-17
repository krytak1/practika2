using System;

class NewClass
{
    public string Property1 { get; set; }
    public int Property2 { get; set; }

    public NewClass(string property1, int property2)
    {
        Property1 = property1;
        Property2 = property2;
    }

    public NewClass()
    {
        Property1 = "Default";
        Property2 = 0;
    }

    ~NewClass()
    {
        Console.WriteLine("Объект NewClass удален.");
    }
}

class Program
{
    static void Main()
    {
        NewClass obj1 = new NewClass("asdasd", 123);
        Console.WriteLine("Свойство1: " + obj1.Property1);
        Console.WriteLine("Свойство2: " + obj1.Property2);
        
        NewClass obj2 = new NewClass();
        Console.WriteLine("Свойство1: " + obj2.Property1);
        Console.WriteLine("Свойство2: " + obj2.Property2);

        obj1 = null;
        obj2 = null;
        GC.Collect();
    }
}