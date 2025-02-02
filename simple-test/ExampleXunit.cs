using Xunit.Abstractions;

namespace simple_test;

public class ExampleXunit
{
    ITestOutputHelper outp;

    public ExampleXunit(ITestOutputHelper outp)
    {
        this.outp = outp;
    }

    [Fact]
    public void CanWriteOutput() => outp.WriteLine("Hello World");

    [Fact]
    public void WillPass()
    {
        Assert.Equal(123, 123);
    }

    [Fact]
    public void CanDebug()
    {
        var a = 10;
        var b = 20;
        var c = 30;
        var res = a + b + c;
        Assert.Equal(60, res);
    }

    // [Fact]
    // public void WillFail()
    // {
    //     Assert.Equal(123, 1230);
    // }

    [Theory]
    [InlineData(10, 2)]
    [InlineData(20, 10)]
    public void IsFactor(int num, int factor)
    {
        Assert.Equal(0, num % factor);
    }

    [Fact(Skip="Will always fail")]
    public void MayFail()
    {
        var random = new Random((int)DateTime.Now.Ticks);
        Assert.True(random.Next(0, 10) > 5);
    }
}
