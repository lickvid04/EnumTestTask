using TMK.NETCore.Extensions;
namespace TMK.EnumLib.Tests;

public class GetEnumMemberByDescriptionTests
{
    [Theory]
    [InlineData("Подсистема ведения справочников", SubSystemType.Reference)]
    [InlineData("Подсистема разграничения доступа", SubSystemType.AccessControl)]
    public void GetEnum_ValidDescription_System(string desc, SubSystemType expected)
    {
        SubSystemType actual = Enums.GetEnumMemberByDescription<SubSystemType>(desc);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("Подсистема ведения", SubSystemType.Reference)]
    [InlineData("Подсистема разгр", SubSystemType.AccessControl)]
    public void GetEnum_InvalidDescription_System(string desc, SubSystemType expected)
    {
        SubSystemType actual = Enums.GetEnumMemberByDescription<SubSystemType>(desc);
        Assert.NotEqual(expected, actual);
    }

    [Theory]
    [InlineData("Понедельник", Days.Monday)]
    [InlineData("Суббота", Days.Saturday)]
    public void GetEnum_ValidDescription_Days(string desc, Days expected)
    {
        Days actual = Enums.GetEnumMemberByDescription<Days>(desc);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("Понедель", Days.Monday)]
    [InlineData("Суббо", Days.Saturday)]
    public void GetEnum_InvalidDescription_Days(string desc, Days expected)
    {
        Days actual = Enums.GetEnumMemberByDescription<Days>(desc);
        Assert.NotEqual(expected, actual);
    }
}