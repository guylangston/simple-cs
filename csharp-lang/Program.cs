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
        // warmup
        for (int cc = 0; cc < 10000; cc++)
        {
            ProfileMe();
        }

        val = 0;
        ProfileMe();
        if (val != 1111) throw new Exception(val.ToString());
    }
}
