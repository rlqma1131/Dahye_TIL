class Program
{
    static void Main(string[] args)
    {
        int x = 2;
        int y = 3;

        x += x * ++y; // 2에 4가 더해져서 x는 6이 된다.

        Console.WriteLine(x++); // 1이 더해져서  x는 7이 된다.
    }
}