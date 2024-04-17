using System;

public class HelloWorld
{
    public static void Main()
    {
        /* задание 1
        string J = Console.ReadLine();
        string S = Console.ReadLine();

        int count = 0;

        foreach (char stone in S)
        {
            if (J.Contains(stone))
            {
                count++;
            }
        }

        Console.WriteLine($"Количество драгоценностей в камнях: {count}");
    */
        /* Задание 2
        Console.Write("Введите элементы массива candidates через пробел: ");
        int[] candidates = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        Console.Write("Введите target: ");
        int target = int.Parse(Console.ReadLine());

        Array.Sort(candidates);
        List<List<int>> result = new List<List<int>>();
        List<int> combination = new List<int>();

        FindCombinations(candidates, target, combination, result);

        Console.WriteLine("Результат:");
        foreach (var item in result)
        {
            Console.WriteLine($"[{string.Join(",", item)}]");
        }
    }

    static void FindCombinations(int[] candidates, int target, List<int> combination, List<List<int>> result, int start = 0)
    {
        if (target == 0)
        {
            result.Add(new List<int>(combination));
            return;
        }

        for (int i = start; i < candidates.Length && candidates[i] <= target; i++)
        {
            combination.Add(candidates[i]);
            FindCombinations(candidates, target - candidates[i], combination, result, i + 1);
            combination.RemoveAt(combination.Count - 1);

            while (i + 1 < candidates.Length && candidates[i] == candidates[i + 1])
                i++;
        }
        */

        /* Задание 3
        Console.Write("Введите элементы массива через пробел: ");
        string[] input = Console.ReadLine().Split(' ');

        bool foundDuplicate = false;
        Array.Sort(input);

        for (int i = 0; i < input.Length - 1; i++)
        {
            if (input[i] == input[i + 1])
            {
                foundDuplicate = true;
                break;
            }
        }

        Console.WriteLine(foundDuplicate ? "true" : "false");
    */
    }
}
