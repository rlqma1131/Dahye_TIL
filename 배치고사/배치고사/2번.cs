class Program
{
    private static void Add(int result, int i)
    {
        result += i;
    }

    static void Main(string[] args)
    {
        int total = 10;
        Console.WriteLine(total);
        Add(200,   total       );
        Console.WriteLine(total);
    }
}