using TMK.NETCore.Extensions;
namespace TMK.EnumLib.Tests;

public class GetEnumMemebersByPartialDescriptionTests
{
    [Theory]
    [InlineData("раз", SubSystemType.AccessControl)]
    public void GetEnum_ValidDescriptionsSystem(string descr, SubSystemType expected)
    {
        List<SubSystemType> actual = descr.GetEnumMembersByPartialDescription<SubSystemType>();

        Assert.Contains(expected, actual);
    }

    [Theory]
    [InlineData("рпкерыпвп")]
    public void GetEnum_InvalidDescriptionsSystem(string descr)
    {
        List<SubSystemType> actual = descr.GetEnumMembersByPartialDescription<SubSystemType>();

        Assert.Empty(actual);
    }

    [Theory]
    [InlineData("Понед", Days.Monday)]
    public void GetEnum_ValidDescriptionsDays(string descr, Days expected)
    {
        List<Days> actual = descr.GetEnumMembersByPartialDescription<Days>();

        Assert.Contains(expected, actual);
    }

    [Theory]
    [InlineData("варпаи")]
    public void GetEnum_InvalidDescriptionsDays(string descr)
    {
        List<Days> actual = descr.GetEnumMembersByPartialDescription<Days>();

        Assert.Empty(actual);
    }
}