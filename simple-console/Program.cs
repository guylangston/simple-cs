Console.WriteLine("In");
Console.WriteLine(System.Diagnostics.Process.GetCurrentProcess().Id);
Console.ReadLine();
for(int cc=2; cc<20; cc++)
{
    Console.WriteLine($"Num: {cc} has Factors: {string.Join(',', Factorize(cc).Select(x=>x.ToString()))}");
}
Console.WriteLine("Out");
return 0;

IEnumerable<int> Factorize(int n)
{
    for(int cc=2; cc<n; cc++)
    {
        if (n % cc == 0) yield return cc;
    }
}
