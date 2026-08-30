using TMK.NETCore.Extensions;
namespace TMK.EnumLib.Tests;

public class DescriptionTests
{
    [Fact]
    public void DescriptionIsCorrect_Days()
    {
        Days day = Days.Monday;
        string description = day.Description();
        Assert.Equal("Понедельник", description);
    }

    [Fact]
    public void DescriptionIsIncorrect_Days()
    {
        Days day = Days.Tuesday;
        string description = day.Description();
        Assert.NotEqual("Понедельник", description);
    }

    [Fact]
    public void DescriptionIsCorrect_SubSystemType()
    {
        SubSystemType subSystem = SubSystemType.Storage;
        string description = subSystem.Description();
        Assert.Equal("Подсистема хранения данных", description);
    }

    [Fact]
    public void DescriptionIsIncorrect_SubSystemType()
    {
        SubSystemType subSystem = SubSystemType.Reference;
        string description = subSystem.Description();
        Assert.NotEqual("Подсистема хранения данных", description);
    }
}
