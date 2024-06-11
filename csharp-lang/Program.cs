internal class Program
{
    private static void Main(string[] args)
    {
        var f = () => Console.WriteLine("a");
        f += () => Console.WriteLine("b");
        f += () => Console.WriteLine("c");
        f();

        Action ff = () => Console.WriteLine("1");
        ff();
    }
}

// Output:
// a
// b
// c
// 1
