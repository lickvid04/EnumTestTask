using TMK.NETCore.Extensions;
namespace TMK.EnumLib.Tests;

public class GetArrayValuesTests
{
    [Theory]
    [InlineData(Days.Monday | Days.Friday, new int[] { 1, 16 })]
    [InlineData(Days.Tuesday, new int[] { 2 })]
    [InlineData(Days.Wednesday, new int[] { 4 })]
    public void GetArrayValues_ValidDays(Days day, int[] expected)
    {
        int[] actual = day.GetArrayValues();
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(Days.Monday | Days.Wednesday, new int[] { 0, 3 })]
    [InlineData(Days.Tuesday | Days.Thursday, new int[] { 1, 7 })]
    public void GetArrayValues_InvalidDays(Days day, int[] expected)
    {
        int[] actual = day.GetArrayValues();
        Assert.NotEqual(expected, actual);
    }

    [Theory]
    [InlineData(SubSystemType.Reference, new int[] { 1})]
    public void GetArrayValues_ValidSystems(SubSystemType system, int[] expected)
    {
        int[] actual = system.GetArrayValues();
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(SubSystemType.Reference, new int[] { 0 })]
    public void GetArrayValues_InvalidSystems(SubSystemType system, int[] expected)
    {
        int[] actual = system.GetArrayValues();
        Assert.NotEqual(expected, actual);
    }
}