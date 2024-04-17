using System;

class Student
{
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string GroupNumber { get; set; }
    public int[] Grades { get; set; }

    public Student(string lastName, DateTime dateOfBirth, string groupNumber, int[] grades)
    {
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        GroupNumber = groupNumber;
        Grades = grades;
    }

    public void ChangeLastName(string newLastName)
    {
        LastName = newLastName;
    }

    public void ChangeDateOfBirth(DateTime newDateOfBirth)
    {
        DateOfBirth = newDateOfBirth;
    }

    public void ChangeGroupNumber(string newGroupNumber)
    {
        GroupNumber = newGroupNumber;
    }

    public static void findInfo(string name, DateTime dateOfBirth, Student[] students)
    {
        Student student = Array.Find(students, s => s.LastName == name && s.DateOfBirth == dateOfBirth);

        if (student != null)
        {
            Console.WriteLine("\nинформация о студенте:");
            student.printInfo();
        }
        else
        {
            Console.WriteLine("\nСтудент с указанными данными не найден.");
        }
    }

    public void printInfo()
    {
        Console.WriteLine($"Фамилия: {LastName}");
        Console.WriteLine($"Дата рождения: {DateOfBirth.ToShortDateString()}");
        Console.WriteLine($"Hомер группы: {GroupNumber}");
        Console.WriteLine("Успеваемость:");

        for (int i = 0; i < Grades.Length; i++)
        {
            Console.WriteLine($"Предмет {i + 1}: {Grades[i]}");
        }
    }
}

class Program
{
    static void Main()
    {
        Student[] students = new Student[]
        {
            new Student("Иванов", new DateTime(2005, 10, 17), "Группа 622", new int[] { 4, 5, 3, 4, 5 }),
            new Student("Петров", new DateTime(2006, 2, 23), "Группа 622", new int[] { 5, 4, 4, 3, 5 }),
            new Student("Сидоров", new DateTime(2005, 7, 10), "Группа 722", new int[] { 3, 4, 5, 5, 4 })
        };

        Student.findInfo("Петров", new DateTime(2006, 2, 23), students);
        Student.findInfo("Иванов", new DateTime(2006, 1, 1), students);

        students[0].ChangeLastName("Иванов");
        students[0].ChangeDateOfBirth(new DateTime(2006, 1, 10));
        students[0].ChangeGroupNumber("Группа 722");

        Student.findInfo("Иванов", new DateTime(2006, 1, 10), students);

        Console.WriteLine("Введите имя студента: ");
        string studentName = Console.ReadLine();

        Console.WriteLine("Введите дату рождения студента (в формате dd.MM.уууу):");
        DateTime studentDateOfBirth;
        while (DateTime.TryParseExact(Console.ReadLine(), "dd.MM.уyyу", null, System.Globalization.DateTimeStyles.None, out studentDateOfBirth))
        {
            Console.WriteLine("Неверный формат даты. Пожалуйста, введите дату в формате dd.MM.уууу:");
        }
        Student.findInfo(studentName, studentDateOfBirth, students);
    }
}