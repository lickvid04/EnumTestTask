using TMK.NETCore.Extensions;
namespace TMK.EnumLib.Tests;

public class GetStringValuesTests
{
    [Theory]
    [InlineData(Days.Monday | Days.Friday, "1, 16")]
    [InlineData(Days.Tuesday, "2")]
    public void GetStringValues_ValidDays(Days day, string expected)
    {
        string actual = day.GetStringValues();
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(Days.Monday | Days.Wednesday, "0, 3")]
    [InlineData(Days.Tuesday, "28")]
    public void GetStringValues_InvalidDays(Days day, string expected)
    {
        string actual = day.GetStringValues();
        Assert.NotEqual(expected, actual);
    }

    [Theory]
    [InlineData(SubSystemType.DataProcessing, "3")]
    [InlineData(SubSystemType.AccessControl, "2")]
    public void GetStringValues_ValidSystems(SubSystemType system, string expected)
    {
        string actual = system.GetStringValues();
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(SubSystemType.Reference, "5")]
    [InlineData(SubSystemType.AccessControl, "6")]
    public void GetStringValues_InvalidSystems(SubSystemType system, string expected)
    {
        string actual = system.GetStringValues();
        Assert.NotEqual(expected, actual);
    }
}