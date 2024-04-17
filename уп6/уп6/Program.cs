namespace уп6;

public class Program
{
    public static void Main()
    {
        Console.WriteLine();
        Console.WriteLine("Добро пожаловать в ежедневник!");
        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Посмотреть задачи");
            Console.WriteLine("2. Добавить новые задачи");
            Console.WriteLine("3. Удалить задачи");
            Console.WriteLine("4. Пометить задачи выполненными");
            Console.WriteLine("5. Выход");
            Console.WriteLine();

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    viemTasksMenu();
                    break;
                case "2":
                    DatabaseRequests.addNewTasksMenu();
                    break;
                case "3":
                    DatabaseRequests.deleteTask();
                    break;
                case "4":
                    DatabaseRequests.DisplayTasks();
                    DatabaseRequests.MarkTaskCompleted();
                    break;
                case "5":
                    Console.WriteLine("До свидания!");
                    return;
                default:
                    Console.WriteLine("Некорректный выбор, попробуйте снова.");
                    break;
            }
        }
// Меню просмотра задач
        static void viemTasksMenu()
        {
            Console.WriteLine("Выберите тип задач:");
            Console.WriteLine("1. Задачи на сегодня");
            Console.WriteLine("2. Задачи на завтра");
            Console.WriteLine("3. Задачи на неделю");
            Console.WriteLine("4. Все задачи");
            Console.WriteLine("5. Предстоящие задачи");
            Console.WriteLine("6. Выполненные задачи");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    DatabaseRequests.viemTasksForDayQuery(DateTime.Today);
                    break;
                case "2":
                    DatabaseRequests.viemTasksForDayQuery(DateTime.Today.AddDays(1));
                    break;
                case "3":
                    DatabaseRequests.viemTasksForWeek();
                    break;
                case "4":
                    DatabaseRequests.viemAllTasks();
                    return;
                case "5":
                    DatabaseRequests.viemUpcomingTasks();
                    return;
                case "6":
                    DatabaseRequests.viemCompletedTasks();
                    return;
                default:
                    Console.WriteLine("Некорректный выбор, попробуйте снова.");
                    break;
            }
        }
    }
}
       