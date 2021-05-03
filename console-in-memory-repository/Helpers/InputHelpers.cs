using System;
using System.Text.RegularExpressions;

namespace Console_in_memory_repository.Helpers
{
    public static class InputHelpers
    {
        public static int GetIntegerValue(string caption)
        {
            int value = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.Write(caption);
                string input = Console.ReadLine();
                validInput = int.TryParse(input, out value);
                if (!validInput)
                {
                    Console.WriteLine();
                    Console.WriteLine("******** Deve ser informado um valor númerico inteiro. Tente novamente ********");
                    Console.WriteLine();
                }
            }
            return value;
        }

        public static int GetIntegerValue(string caption, int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                var temp = minValue;
                minValue = maxValue;
                maxValue = temp;
            }

            int value = minValue;
            bool insideRange = false;

            while (!insideRange)
            {
                value = GetIntegerValue(caption);
                insideRange = (value >= minValue && value <= maxValue);

                if (!insideRange)
                {
                    Console.WriteLine("**************** Opção inválida. Tente novamente ****************");
                }
            }

            return value;
        }

        public static bool GetBooleanValue(string caption)
        {
            string input;
            bool validInput;
            do
            {
                Console.Write($"{caption} (S/N) ");
                input = Console.ReadLine();
                validInput = Regex.Match(input, @"\b[SN]\b", RegexOptions.IgnoreCase).Success;
                if (!validInput)
                {
                    Console.WriteLine("**************** Opção inválida. Tente novamente ****************");
                }
            } while (!validInput);

            return input.ToUpper() == "S";
        }

        public static string GetRequiredValue(string caption)
        {
            string input;

            do
            {
                Console.Write(caption);
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine();
                    Console.WriteLine("******** Esse valor é requerido. Tente novamente. ********");
                    Console.WriteLine();
                }
            } while (string.IsNullOrWhiteSpace(input));
            return input;
        }

        public static T GetValidEnumValue<T>(string listCaption, string caption) where T: Enum
        {
            var options = EnumHelpers.ToListOfValuesAndDescription<T>();

            Console.WriteLine(listCaption);
            foreach(var option in options)
            {
                Console.WriteLine(option);
            }
            return EnumHelpers.GetByValue<T>(GetIntegerValue(caption));
        }

        public static T GetValidEnumValue<T>(string listCaption, string caption, int minValue, int maxValue) where T : Enum
        {
            var options = EnumHelpers.ToListOfValuesAndDescription<T>();

            Console.WriteLine(listCaption);
            foreach (var option in options)
            {
                Console.WriteLine(option);
            }
            return EnumHelpers.GetByValue<T>(GetIntegerValue(caption, minValue, maxValue));
        }
    }
}
