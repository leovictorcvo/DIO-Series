using Console_in_memory_repository.Enums;
using Console_in_memory_repository.Helpers;
using System;
using Xunit;

namespace Console_in_memory_repository_test
{
    public class ECategoriesExtensionTest
    {
        [Fact]
        public void ShouldReturnListOfStringShowingValueAndText()
        {
            var list = EnumHelpers.ToListOfValuesAndDescription<ECategories>();
            var enumValues = Enum.GetValues(typeof(ECategories));
            Assert.Equal(enumValues.Length, list.Count);
        }
    }
}
