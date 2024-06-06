namespace simple_nunit;

public class ExampleNUnit
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void WillPass()
    {
        Assert.Pass();
    }

    [Test]
    public void WillFail()
    {
        Assert.AreEqual(123, 123.1);
    }
}
