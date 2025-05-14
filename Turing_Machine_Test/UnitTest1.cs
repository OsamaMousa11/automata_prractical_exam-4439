using Xunit;

public class TuringMachineWWTests
{
    private readonly TuringMachine _turingMachine;
    public TuringMachineWWTests()
    {
        _turingMachine = new TuringMachine();
    }
    [Theory]
    [InlineData("0101", true)]
    [InlineData("0011", false)]
    [InlineData("11", true)]
    [InlineData("1010", true)]
    [InlineData("011011", true)]
    [InlineData("010", false)]
    [InlineData("", true)] 
    [InlineData("1", false)] 
    public void TestIsWW(string input, bool expected)
    {
        bool result = _turingMachine.IsWW(input);
        Assert.Equal(expected, result);
    }
}