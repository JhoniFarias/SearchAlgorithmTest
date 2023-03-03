using System.Threading;
using System.Diagnostics;

public class Program
{
    public static List<int> numbers = Enumerable.Range(1, 10000000).ToList();
    private static void Main(string[] args)
    {
        Console.WriteLine("Digite um numero para realizar a busca");
        
        int numberToSearch = Convert.ToInt32(Console.ReadLine());

        LinearSearch(numberToSearch);
        BinarySearch(numberToSearch);
        LinqSearch(numberToSearch);
    }

    private static void LinearSearch(int numberToSearch)
    {
        Stopwatch timer = new Stopwatch();
        timer.Start();

        foreach (var item in numbers)
        {
            if (item == numberToSearch)
                break;
        }

        timer.Stop();

        Console.WriteLine($"LinearSearch: {timer.Elapsed}");
    }

    private static void BinarySearch(int numberToSearch)
    {
        Stopwatch timer = new Stopwatch();
        timer.Start();
        
        int start = numbers[0];
        int end = numbers[numbers.Count -1];

        while (start <= end)
        {
            int midle = end - ((end - start) / 2);

            if (numbers[midle] == numberToSearch)
                break;
           
            if (numbers[midle] > numberToSearch)
                end = midle - 1;
            else
                start = midle + 1;
        }

        timer.Stop();

        Console.WriteLine($"BinarySearch: {timer.Elapsed}");
    }

    private static void LinqSearch(int numberToSearch)
    {
        Stopwatch timer = new Stopwatch();
        timer.Start();
        
        numbers.First(p => p == numberToSearch);

        timer.Stop();

        Console.WriteLine($"LinqSearch: {timer.Elapsed}");
    }

}