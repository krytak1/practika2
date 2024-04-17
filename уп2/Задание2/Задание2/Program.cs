using System;

class Train
{
    public string Destination { get; set; }
    public int TrainNumber { get; set; }
    public DateTime DepartureTime { get; set; }

    public Train(string destination, int trainNumber, DateTime departureTime)
    {
        Destination = destination;
        TrainNumber = trainNumber;
        DepartureTime = departureTime;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Номер поезда: {TrainNumber}");
        Console.WriteLine($"Пункт назначения: {Destination}");
        Console.WriteLine($"Время отправления: {DepartureTime.ToString("dd.MM.yyyy HH:mm")}");
    }
}

class Program
{
    static void Main()
    {
        Train[] trains = {
            new Train("Москва", 107, new DateTime(2024, 2, 15, 9, 0, 0)),
            new Train("Санкт-Петербург", 111, new DateTime(2024, 2, 15, 11, 30, 0)),
            new Train("Новосибирск", 169, new DateTime(2024, 2, 15, 14, 52,0))
        };

        Console.WriteLine("Введите номер поезда:");
        int trainNumber;
        while (!int.TryParse(Console.ReadLine(), out trainNumber))
        {
            Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число:");
        }

        Train foundTrain = null;
        foreach (var train in trains)
        {
            if (train.TrainNumber == trainNumber)
            {
                foundTrain = train;
                break;
            }
        }

        if (foundTrain != null)
        {
            foundTrain.PrintInfo();
        }
        else
        {
            Console.WriteLine("Поезд с указанным номером не найден.");
        }
    }
}
