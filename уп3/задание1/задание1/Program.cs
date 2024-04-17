using System;

class Worker
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public float Rate { get; set; }
    public int Days { get; set; }
    
    public Worker(string name, string surname, float rate, int days)
    {
        Name = name;
        Surname = surname;
        Rate = rate;
        Days = days;
    }
    
    public void GetSalary()
    {
        Console.Write(Rate * Days);
    }
}

class Program
{
    static void Main()
    {
        Worker worker = new Worker("Иван", "Петров", 2160, 21);
        
        Console.Write($"Зарплата работника {worker.Name} {worker.Surname}: ");
        worker.GetSalary();
    }
}