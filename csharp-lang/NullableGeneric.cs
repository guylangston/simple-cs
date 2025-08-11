public class SomePropCollection
{
    Dictionary<string, object> dict = new()
    {
        {"Hello", "World"},
        {"Answer", 42},
    };

    public TProp? GetProp<TProp>(string name)
    {
        if (dict.TryGetValue(name, out var val))
        {
            if (val is TProp pp)
            {
                return pp;
            }
            throw new InvalidCastException($"value found but {val.GetType()} vs {typeof(TProp)}");
        }
        return default;
    }
}

public static class SomePropCollectionVerify
{
    public static void Test()
    {
        var col = new SomePropCollection();
        var x = col.GetProp<string>("Hello");
        Console.WriteLine($"Hello => {x.GetType()}, {x}");
        var y = col.GetProp<int>("Answer");
        Console.WriteLine($"Hello => {y.GetType()}, {y}");
    }
}
