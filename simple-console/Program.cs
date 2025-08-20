Console.WriteLine("In");
Console.WriteLine(System.Diagnostics.Process.GetCurrentProcess().Id);
if (args.Length > 0 && args[0] == "--wait") 
{
    Console.WriteLine("Press [ENTER] to continue...");
    Console.ReadLine();
}
for(int cc=2; cc<20; cc++)
{
    var factors = Factorize(cc).ToArray(); // for easy debugger attach
    Console.WriteLine($"Num: {cc} has Factors: {string.Join(',', factors.Select(x=>x.ToString()))}");
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
