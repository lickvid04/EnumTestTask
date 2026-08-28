using TMK.NETCore.Extensions;

namespace TMK.EnumLib.Tests;

public class GetDescriptionsTest
{
    [Theory]
    [InlineData("Пятн", "Пятница")]
    [InlineData("понЕДЕл", "Понедельник")]
    [InlineData("Отсутсвующий", null)]
    public void GetDescriptions_StringIsCorrect_Days(string term, string? expected)
    {
        List<string> descriptions = Enums.GetDescriptions<Days>(term);
        if (expected is null)
        {
            Assert.Empty(descriptions);
        }
        else
        {
            Assert.Contains(expected, descriptions);
        }
    }

    [Theory]
    [InlineData("Подсис", "Подсистема хранения данных")]
    [InlineData("хран", "Подсистема хранения данных")]
    [InlineData("НеСуществующая", null)]
    public void GetDescriptions_StringIsCorrect_SubSystemsType(string term, string? expected)
    {
        List<string> descriptions = Enums.GetDescriptions<SubSystemType>(term);
        if (expected is null)
        {
            Assert.Empty(descriptions);
        }
        else
        {
            Assert.Contains(expected, descriptions);
        }
    }

}