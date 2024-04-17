using Npgsql;
using NpgsqlTypes;

namespace уп6;

public static class DatabaseRequests
{
    // просмотр задач на указаную дату
    public static void viemTasksForDayQuery(DateTime date)
    {
        Console.WriteLine($"Список задач на {date.ToShortDateString()}:");
        string formatedDate = date.ToString("yyyy-MM-dd");
        
        using var connection = DatabaseService.GetSqlConnection();
        connection.Open();

        var querySql = "SELECT * FROM Task WHERE duedata::date = @date";
        
        using var cmd = new NpgsqlCommand(querySql, connection);
        cmd.Parameters.AddWithValue("date", date);
        
        using var reader = cmd.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Console.WriteLine(
                    $"Id: {reader[0]}\n Название: {reader[1]}\n Описание: {reader[2]}\n Дата: {reader[3]}");
            }
        }
        else
        {
            Console.WriteLine("На выбранную дату задач нет.");
        }
        Console.WriteLine();
        Console.ReadLine();
    }

    // просмотр задач на неделю
    public static void viemTasksForWeek()
    {
        DateTime currentDate = DateTime.Today;
        DateTime startOfWeek = currentDate.AddDays(-(int)currentDate.DayOfWeek);
        DateTime endOfWeek = startOfWeek.AddDays(6);

        Console.WriteLine(
            $"Список задач на неделю с {startOfWeek.ToShortDateString()} по {endOfWeek.ToShortDateString()}:");
        
        var querySql = "SELECT * FROM Task WHERE duedata >= @start AND duedata <= @end";
        
        using var connection = DatabaseService.GetSqlConnection();
        connection.Open();
        using var cmd = new NpgsqlCommand(querySql, connection);
        
        cmd.Parameters.AddWithValue("start", startOfWeek);
        cmd.Parameters.AddWithValue("end", endOfWeek);
        
        using var reader = cmd.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Console.WriteLine(
                    $"Id: {reader[0]}\n Название: {reader[1]}\n Описание: {reader[2]}\n Дата: {reader[3]}");
            }
        }
        else
        {
            Console.WriteLine("На текущей неделе задач нет.");
        }
        Console.WriteLine();
        Console.ReadLine();
    }

    // просмотр всех задач
    public static void viemAllTasks()
    {
        Console.WriteLine("Список всех задач:");
        
        var querySql = "SELECT * FROM Task";
        
        using var connection = DatabaseService.GetSqlConnection();
        connection.Open();
        using var cmd = new NpgsqlCommand(querySql, connection);
        
        using var reader = cmd.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Console.WriteLine(
                    $"Id: {reader[0]}\n Название: {reader[1]}\n Описание: {reader[2]}\n Дата: {reader[3]}");
            }
        }
        else
        {
            Console.WriteLine("Задачи отсутствуют.");
        }
        Console.WriteLine();
        Console.ReadLine();
    }

    //просмотр предстоящих задач
    public static void viemUpcomingTasks()
    {
        Console.WriteLine("Предстоящие задачи:");
        
        var querySql = "SELECT * FROM Task WHERE DUEDATA >= CURRENT_DATE";
        
        using var connection = DatabaseService.GetSqlConnection();
        connection.Open();
        using var cmd = new NpgsqlCommand(querySql, connection);
        
        using var reader = cmd.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Console.WriteLine(
                    $"Id: {reader[0]}\n Название: {reader[1]}\n Описание: {reader[2]}\n Дата: {reader[3]}");
            }
        }
        else
        {
            Console.WriteLine("Предстоящих задач нет.");
        }
        Console.WriteLine();
        Console.ReadLine();
    }

    //просмотр выполненых задач
    public static void viemCompletedTasks()
    {
        Console.WriteLine("Выполненные задачи:");
        
        var querySql = "SELECT * FROM Task WHERE IsCompleted = TRUE";
        
        using var connection = DatabaseService.GetSqlConnection();
        connection.Open();
        using var cmd = new NpgsqlCommand(querySql, connection);
        
        using var reader = cmd.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Console.WriteLine(
                    $"Id: {reader[0]}\n Название: {reader[1]}\n Описание: {reader[2]}\n Дата: {reader[3]}");
            }
        }
        else
        {
            Console.WriteLine("Выполненных задач нет.");
        }
        Console.WriteLine();
        Console.ReadLine();
    }

    //удаление задач
    public static void deleteTask()
    {
        viemAllTasks();
        
        Console.Write("Введите ID задачи для удаления: ");
        int taskIdToDelete;
        if (!int.TryParse(Console.ReadLine(), out taskIdToDelete))
        {
            Console.WriteLine("Некорректный ввод. Введите целое число.");
            return;
        }
        
        var querySql = $"DELETE FROM Task WHERE id = {taskIdToDelete}";
        
        using var connection = DatabaseService.GetSqlConnection();
        connection.Open();
        using var cmd = new NpgsqlCommand(querySql, connection);
        
        int rowsAffected = cmd.ExecuteNonQuery();

        if (rowsAffected > 0)
        {
            Console.WriteLine($"Задача с ID {taskIdToDelete} успешно удалена.");
        }
        else
        {
            Console.WriteLine($"Не удалось найти задачу с ID {taskIdToDelete} для удаления.");
        }
        Console.WriteLine();
        Console.ReadLine();
    }

    public static void addNewTasksMenu()
    {
        Console.Write("Введите название задачи: ");
        string title = Console.ReadLine();

        Console.Write("Введите описание задачи: ");
        string description = Console.ReadLine();

        DateTime dueData;
        bool validDate;

        do
        {
            Console.WriteLine("Введите дату завершения задачи (в формате yyyy-MM-dd): ");
            string dateInput = Console.ReadLine();

            validDate = DateTime.TryParseExact(dateInput, "yyyy-MM-dd", null,
                System.Globalization.DateTimeStyles.None, out dueData);

            if (!validDate)
            {
                Console.WriteLine("Некорректный формат даты. Попробуйте снова.");
            }
        } while (!validDate);
        
        var querySql = 
            $"INSERT INTO Task (title, description, duedata) VALUES ('{title}', '{description}', '{dueData:yyyy-MM-dd}')";
        
        using var connection = DatabaseService.GetSqlConnection();
        connection.Open();
        using var cmd = new NpgsqlCommand(querySql, connection);
        
        int rowsAffected = cmd.ExecuteNonQuery();

        if (rowsAffected > 0)
        {
            Console.WriteLine("Новая задача добавлена.");
        }
        else
        {
            Console.WriteLine("Ошибка при добавлении новой задачи.");
        }

        Console.WriteLine();
        Console.ReadLine();
    }


    public static void DisplayTasks()
    {
        var querySql = "SELECT title, duedata FROM Task";
        
        using var connection = DatabaseService.GetSqlConnection();
        connection.Open();
        using var cmd = new NpgsqlCommand(querySql, connection);
        
        using var reader = cmd.ExecuteReader();
        
        if (!reader.HasRows)
        {
            Console.WriteLine("Список задач пуст.");
            return;
        }
        
        int index = 1;
        while (reader.Read())
        {
            string title = reader.GetString(0);
            DateTime dueData = reader.GetDateTime(1);
            Console.WriteLine($"{index}. {title} - {dueData.ToShortDateString()}");
            index++;
        }
    }


    public static void MarkTaskCompleted()
    {
        Console.Write("Введите номер задачи для отметки задачи выполненной (или 0 для отмены): ");
        if (!int.TryParse(Console.ReadLine(), out int taskNumber) || taskNumber < 0)
        {
            Console.WriteLine("Некорректный ввод или действие отменено.");
            return;
        }
        
        var querySql = $"UPDATE Task SET IsCompleted = true WHERE id = @TaskId";
        
        using var connection = DatabaseService.GetSqlConnection();
        
        using var cmd = new NpgsqlCommand(querySql, connection);
        cmd.Parameters.AddWithValue("@TaskId", taskNumber);
        
        connection.Open();
        int completedTaskCount = cmd.ExecuteNonQuery();
        
        if (completedTaskCount > 0)
        {
            Console.WriteLine("Задача помечена выполненной.");
        }
        else
        {
            Console.WriteLine("Ошибка: задача не найдена или уже выполнена.");
        }
        Console.WriteLine();
        Console.ReadLine();
        
    }

}