using System;
using System.Collections.Generic;

namespace Console_in_memory_repository.Helpers
{
    public static class EnumHelpers
    {
        public static List<string> ToListOfValuesAndDescription<T>() where T: Enum
        {
            var result = new List<string>();
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                result.Add($"{(int)value} - {(T)value}");
            }
            return result;
        }

        public static T GetByValue<T>(int value) where T : Enum => (T)Enum.ToObject(typeof(T), value);

    }
}
