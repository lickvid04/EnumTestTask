using TMK.NETCore.Extensions;
namespace TMK.EnumLib.Tests;

public class GetListParamTests
{
    [Fact]
    public void GetListParam_ExpectedSystem()
    {
        Dictionary<int, string> systems = Enums.GetListParam<SubSystemType>();

        Assert.NotEmpty(systems);
        Assert.True(systems.ContainsKey(1));
        Assert.Equal("Подсистема ведения справочников", systems[1]);
    }

    [Fact]
    public void GetListParam_NonExpectedSystem()
    {
        Dictionary<int, string> systems = Enums.GetListParam<SubSystemType>();

        Assert.True(systems.ContainsKey(3));
        Assert.NotEqual("Подсистема ведения справочников", systems[3]);
    }

    [Fact]
    public void GetListParam_ExpectedDays()
    {
        Dictionary<int, string> days = Enums.GetListParam<Days>();

        Assert.NotEmpty(days);
        Assert.True(days.ContainsKey(8));
        Assert.Equal("Четверг", days[8]);
    }
    
    [Fact]
    public void GetListParam_NonExpectedDays()
    {
        Dictionary<int, string> days = Enums.GetListParam<Days>();

        Assert.True(days.ContainsKey(8));
        Assert.NotEqual("Понедельник", days[8]);
    }
}