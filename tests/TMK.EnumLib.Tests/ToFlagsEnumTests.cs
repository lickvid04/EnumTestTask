using TMK.NETCore.Extensions;
namespace TMK.EnumLib.Tests;

public class ToFlagEnumTests
{
    [Fact]
    public void ToFlagEnum_ExpectedValuesDays()
    {
        int[] flagsValue = {2, 4, 8};
        string expected = "Tuesday, Wednesday, Thursday";
        Days flagsEnum = Enums.ToFlagsEnum<Days>(flagsValue);

        Assert.Equal(expected, flagsEnum.ToString());
    }

    [Fact]
    public void ToFlagEnum_UnknownFlagDays()
    {
        int[] flagsValue = {128};
        ArgumentException exception =
        Assert.Throws<ArgumentException>(
            () => Enums.ToFlagsEnum<Days>(flagsValue));

        Assert.Equal("Неизвестный флаг", exception.Message);
    }
}