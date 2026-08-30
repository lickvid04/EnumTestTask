using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace TMK.NETCore.Extensions {
    public static class Enums {
        private static string[] GetValuesFromEnum(this Enum value) => 
            value.ToString().Split(',', StringSplitOptions.TrimEntries);
        public static List<string> GetDescriptions<TEnum>(string term, int take = 15) {
            term = (term ?? "").ToUpper();

            return typeof(TEnum)
                .GetFields()
                .Select(a => a.GetCustomAttribute<DescriptionAttribute>())
                .Where(b => b != null && !string.IsNullOrWhiteSpace(b.Description))
                .Select(b => b.Description)
                .Where(desc => desc.ToUpper().Contains(term))
                .Distinct() 
                .Take(take) 
                .ToList();
        }
        /// <summary>
        /// Получить описание из атрибута Description
        /// </summary>
        public static string Description(this Enum value) {
                return string.Join("; ", GetValuesFromEnum(value)
                    .Select(a => value.GetType().GetField(a)?
                        .GetCustomAttribute<DescriptionAttribute>()?.Description ?? a)); 
        }
        /// <summary>
        /// Получить по строковому виду значение перечисления
        /// </summary>
        public static TEnum GetEnumByStringNum<TEnum>(this string num)
            where TEnum : struct, Enum {

            if (!int.TryParse(num, out int sKey)) {
                return default;
            }
            return Enum.GetValues<TEnum>()
                .Where(enNum => Convert.ToInt32(enNum) == sKey)
                .FirstOrDefault();
        }
        /// <summary>
        /// Получает все перечисленные значения, если перечисление содержит их несколько
        /// </summary>
        public static int[] GetArrayValues(this Enum value) {
            return GetValuesFromEnum(value)
                .Select(name => value.GetType().GetField(name))
                .OfType<FieldInfo>()
                .Select(field => Convert.ToInt32(field.GetValue(null)))
                .ToArray();
        }
        /// <summary>
        /// Собирает битовое перечисление из массива чисел
        /// </summary>
        public static TEnum ToFlagsEnum<TEnum>( this int[] fields)
            where TEnum : struct, Enum {
            if (!typeof(TEnum).IsDefined(typeof(FlagsAttribute), false)) {
                throw new ArgumentException($"{typeof(TEnum).Name} не является битовым перечислением");
            }
            int allowedFlag = Enum.GetValues<TEnum>()
                .Aggregate(0, (current, flag) =>
                    current | Convert.ToInt32(flag));

            if (fields.Any(value => (value & ~allowedFlag) != 0))
            {
                throw new ArgumentException("Неизвестный флаг");
            }

            int result = fields.Aggregate(0, 
                (current, value) => current | value);
            return Unsafe.As<int, TEnum>(ref result);
        }
        /// <summary>
        /// Вытаскивает все описания по перечислению
        /// </summary>
        public static string GetStringValues(this Enum value) {
            return string.Join(", ",
                GetValuesFromEnum(value)
                    .Select(name => value.GetType().GetField(name))
                    .OfType<FieldInfo>()
                    .Select(field => Convert.ToInt32(field.GetValue(null))));
        }
        /// <summary>
        /// Получить по строке в атрибуте Description перечисление
        /// </summary>
        public static TEnum GetEnumMemberByDescription<TEnum>(this string descr)
            where TEnum : struct, Enum {

            return typeof(TEnum)
                .GetFields()
                .Where(field => field.GetCustomAttribute<DescriptionAttribute>()?.Description == descr)
                .Select(field => field.GetValue(null))
                .OfType<TEnum>()
                .FirstOrDefault();
        }
        public static List<TEnum> GetEnumMembersByPartialDescription<TEnum>(this string description)
            where TEnum : struct, Enum {
                
                if (string.IsNullOrWhiteSpace(description)) {
                    return new List<TEnum>();
                }
                description = description.ToUpper();
                return typeof(TEnum)
                    .GetFields()
                    .Select(field => new
                    {
                        Field = field,
                        Description = field.GetCustomAttribute<DescriptionAttribute>()?.Description
                    })
                    .Where(a => !string.IsNullOrEmpty(a.Description)
                        && a.Description.ToUpper().Contains(description))        
                    .Select(a => a.Field.GetValue(null))
                    .OfType<TEnum>()
                    .ToList();
            }
        /// <summary>
        /// Получить по строковому виду значение перечисления
        /// </summary>
        public static TEnum GetEnumByString<TEnum>(this string str)
            where TEnum : struct, Enum {
                if (string.IsNullOrWhiteSpace(str))
                {
                    return default;
                }
                return Enum.GetValues<TEnum>()
                    .FirstOrDefault(value => string.Equals(value.ToString(),
                    str, StringComparison.OrdinalIgnoreCase));
            }
        /// <summary>
        /// Представить enum в виде списка ключ-значение
        /// </summary>
        public static Dictionary<int, string> GetListParam<TEnum>()
            where TEnum : struct, Enum {
            return Enum.GetValues<TEnum>()
                .Where(e => Convert.ToInt32(e) >= 0)
                .ToDictionary(
                    e => Convert.ToInt32(e),
                    e => e.Description()
                );
            
        }
    }
}