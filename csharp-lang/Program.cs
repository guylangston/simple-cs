internal class Program
{
    static int val = 0;
    private static int ProfileMe()
    {
        var f = () => val += 1;
        f += () => val += 10;
        f += () => val += 100;
        f();

        Action ff = () => val += 1000;
        ff();
        return val;
    }

    private static void Main(string[] args)
    {
       SomePropCollectionVerify.Test();
    }

    public static void ArrayCasting()
    {
        IEnumerable<int> a = new int[] { 1, 2, 3 };
        var b = a.ToArray(); // cast is already array? NO
        Console.WriteLine(Object.ReferenceEquals(a, b)); // false
    }
}
