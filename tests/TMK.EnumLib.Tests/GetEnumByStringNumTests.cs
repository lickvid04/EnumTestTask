using TMK.NETCore.Extensions;
namespace TMK.EnumLib.Tests;

public class GetEnumByStringNumTests
{
    [Theory]
    [InlineData("1", Days.Monday)]
    [InlineData("2", Days.Tuesday)]
    [InlineData("4", Days.Wednesday)]
    public void GetEnumByStringNum_ValidDaysNumbers(string number, Days expected)
    {
        Days actual = Enums.GetEnumByStringNum<Days>(number);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("-3")]
    [InlineData("-5")]
    public void GetEnumByStringNum_InvalidDaysNumbers(string number)
    {
        Days actual = Enums.GetEnumByStringNum<Days>(number);
        Assert.Equal(Days.None, actual);
    }

    [Fact]
    public void GetEnumByStringNum_ValidSystemNumber()
    {
        SubSystemType actual = Enums.GetEnumByStringNum<SubSystemType>("3");
        Assert.Equal(SubSystemType.DataProcessing, actual);
    }

    [Fact]
    public void GetEnumByStringNum_InvalidSystemNumber()
    {
        SubSystemType actual = Enums.GetEnumByStringNum<SubSystemType>("100");
        Assert.Equal(SubSystemType.Storage, actual);
    }

}
