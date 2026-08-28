using TMK.NETCore.Extensions;
namespace TMK.EnumLib.Tests;

public class GetEnumByStringTests
{
    [Theory]
    [InlineData("DataProcessing", SubSystemType.DataProcessing)]
    [InlineData("refeRENce", SubSystemType.Reference)]
    public void GetEnum_ValidSystem(string field, SubSystemType expected)
    {
        SubSystemType actual = Enums.GetEnumByString<SubSystemType>(field);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("dgbdhpsg", SubSystemType.DataProcessing)]
    [InlineData("варпкенвп", SubSystemType.Reference)]
    public void GetEnum_InvalidSystem(string field, SubSystemType expected)
    {
        SubSystemType actual = Enums.GetEnumByString<SubSystemType>(field);
        Assert.NotEqual(expected, actual);
    }

    [Theory]
    [InlineData("Monday", Days.Monday)]
    [InlineData("SatURDay", Days.Saturday)]
    public void GetEnum_ValidDays(string field, Days expected)
    {
        Days actual = Enums.GetEnumByString<Days>(field);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("dgfd", Days.Monday)]
    [InlineData("смисви", Days.Saturday)]
    public void GetEnum_InvalidDays(string field, Days expected)
    {
        Days actual = Enums.GetEnumByString<Days>(field);
        Assert.NotEqual(expected, actual);
    }
}