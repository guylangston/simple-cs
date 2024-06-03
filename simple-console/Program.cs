for(int cc=2; cc<20; cc++)
{
    Console.WriteLine($"Num: {cc} has Factors: {string.Join(',', Factorize(cc).Select(x=>x.ToString()))}");
}


List<int> Factorize(int n)
{
    var res = new List<int>();
    for(int cc=2; cc<n; cc++)
    {
        if (n % cc == 0) res.Add(cc);
    }
    return res;
}
