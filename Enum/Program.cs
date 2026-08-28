using TMK.NETCore.Extensions;

namespace TestTask1
{
    class Program {
        public static void Main(string[] args) {
            /*
            Days day = Days.Monday;
            string description = day.Description();
            Console.WriteLine($"День: {description}");
            */

            
            string term = Console.ReadLine();
            List<string> descriptions = Enums.GetDescriptions<SubSystemType>(term);
            foreach (string desc in descriptions)
            {
                Console.WriteLine($"Подсистема: {desc}");
            }
            
            /*
            string num = Console.ReadLine();
            SubSystemType testEnum = Enums.GetEnumByStringNum<SubSystemType>(num);
            Console.WriteLine($"Подсистема по строковому виду: {testEnum.Description()}");

            Days testEnum2 = Enums.GetEnumByStringNum<Days>(num);
            Console.WriteLine($"День по строковому виду: {testEnum2.Description()}");
            */
            Days day = Days.Monday | Days.Wednesday;
            
            int[] array = day.GetArrayValues();
            foreach (int value in array)
            {
                Console.WriteLine($"Значение: {value}");
            }
            

            
            //Console.WriteLine("Укажите размер массива: ");
            //int size = int.Parse(Console.ReadLine());
            /*
            int size = 3;
            int[] flagsValue =  new int[size];
            for (int i = 0; i < size; i++) {
                Console.WriteLine($"Укажите значение {i + 1}: ");
                flagsValue[i] = int.Parse(Console.ReadLine());
            }
            Days flagsEnum = Enums.ToFlagsEnum<Days>(flagsValue);
            Console.WriteLine($"Флаги: {flagsEnum}");
            */
        }
    }
}
