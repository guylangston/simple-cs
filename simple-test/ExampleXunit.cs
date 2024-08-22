namespace simple_test;

public class ExampleXunit
{
    [Fact]
    public void WillPass()
    {
        Assert.Equal(123, 123);
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
