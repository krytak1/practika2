using System;

class Worker
{
    private string _name { get; set; }
    private string _surname { get; set; }
    private float _rate { get; set; }
    private int _days { get; set; }
    
    public Worker(string name, string surname, float rate, int days)
    {
        _name = name;
        _surname = surname;
        _rate = rate;
        _days = days;
    }
    public string GetName()
    {
        return _name;
    }

    public string GetSurname()
    {
        return _surname;
    }

    public double GetRate()
    {
        return _rate;
    }

    public int GetDays()
    {
        return _days;
    }
    public void GetSalary()
    {
        Console.Write(_rate * _days);
    }
}

class Program
{
    static void Main()
    {
        Worker worker = new Worker("Иван", "Петров", 2160, 21);
        
        Console.Write($"Зарплата работника {worker.GetName()} {worker.GetSurname()}: ");
        worker.GetSalary();
    }
}