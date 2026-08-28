using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace TMK.NETCore.Extensions {
    public static class Enums {
        private static string[] GetConsoleValues(this Enum value) => 
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
        /// <param name="value">Enum</param>
        public static string Description(this Enum value) {
                return string.Join("; ", GetConsoleValues(value)
                    .Select(a => value.GetType().GetField(a)?
                        .GetCustomAttribute<DescriptionAttribute>()?.Description ?? a)); 
        }
        /// <summary>
        /// Получить по строковому виду значение перечисления
        /// </summary>
        /// <typeparam name="TEnum">Перечисление</typeparam>
        /// <param name="str">Строковое значение</param>
        /// <returns></returns>
        public static TEnum GetEnumByStringNum<TEnum>(this string num)
            where TEnum : struct, Enum {

            if (!int.TryParse(num, out int sKey)) {
                return default;
            }
            return Enum.GetValues<TEnum>()
                .Where(a => Convert.ToInt32(a) == sKey)
                .FirstOrDefault();
        }
        /// <summary>
        /// Получает все перечисленные значения, если перечисление содержит их несколько
        /// </summary>
        /// <param name="value">перечисление</param>
        /// <returns></returns>
        public static int[] GetArrayValues(this Enum value) {
            return GetConsoleValues(value)
                .Select(name => value.GetType().GetField(name))
                .OfType<FieldInfo>()
                .Select(field => Convert.ToInt32(field.GetValue(null)))
                .ToArray();
        }
        /// <summary>
        /// Собирает битовое перечисление из массива чисел
        /// </summary>
        /// <typeparam name="TEnum">перечисление</typeparam>
        /// <param name="fields">массив чисел</param>
        /// <returns></returns>
        // TODO: метод пока не проверяет, что переданные числа это флаги, которые объявлены в TEnum
        // Сейчас метод примет любое число, которое в том числе не соответствует ни одному флагу
        // Например, сейчас метод спокойно примет число 128 без ошибки, хотя такого флага нет
        // В дальнейшем необходимо добавить проверку
        public static TEnum ToFlagsEnum<TEnum>( this int[] fields)
            where TEnum : struct, Enum {
            if (!typeof(TEnum).IsDefined(typeof(FlagsAttribute), false)) {
                throw new ArgumentException($"{typeof(TEnum).Name} не является битовым перечислением");
            }

            int result = 0;
            if (fields != null) {
                foreach (var i in fields) {
                    result = result | i;
                }
            }
            return Unsafe.As<int, TEnum>(ref result);
        }
        /// <summary>
        /// Вытаскивает все описания по перечислению
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetStringValues(this Enum value) {
            return string.Join(", ",
                GetConsoleValues(value)
                    .Select(name => value.GetType().GetField(name))
                    .OfType<FieldInfo>()
                    .Select(field => Convert.ToInt32(field.GetValue(null))));
        }
        /// <summary>
        /// Получить по строке в атрибуте Description перечисление
        /// </summary>
        /// <typeparam name="TEnum">Перечисление</typeparam>
        /// <param name="descr">Описание</param>
        /// <returns></returns>
        public static TEnum GetEnumMemberByDescription<TEnum>(this string descr)
            where TEnum : struct, Enum {

            return typeof(TEnum)
                .GetFields()
                .Where(field =>
                    field.Name == descr ||
                    field.GetCustomAttribute<DescriptionAttribute>()?.Description == descr)
                .Select(field => field.GetValue(null))
                .OfType<TEnum>()
                .FirstOrDefault();
        }
        public static List<TEnum> GetEnumMembersByPartialDescription<TEnum>(this string description)
            where TEnum : struct, Enum {
                description = description.ToUpper();
                if (string.IsNullOrWhiteSpace(description)) {
                    return new List<TEnum>();
                }
            
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
        /// <typeparam name="TEnum">Перечисление</typeparam>
        /// <param name="str">Строковое значение</param>
        /// <returns></returns>
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
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static Dictionary<int, string> GetListParam<TEnum>()
            where TEnum : struct, Enum {
            Dictionary<int, string> res = new Dictionary<int, string>();
            foreach (Enum en in Enum.GetValues(typeof(TEnum))) {
                int key = (int)Enum.Parse(typeof(TEnum), en + "", true);
                if (key == -1) {
                    continue;
                }
                res.Add(key, en.Description());
            }

            return res;
        }
    }
}