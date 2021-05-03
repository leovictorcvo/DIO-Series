using Console_in_memory_repository.Helpers;
using System;
using Xunit;

namespace Console_in_memory_repository_test
{
    public class EnumHelperTest
    {
        enum ETest: sbyte
        {
            FirstValue = 1,
            SecondValue = 2
        }

        [Fact]
        public void ShouldAcceptEnumWithUnderlyingDifferentFromInt()
        {
            EnumHelpers.ToListOfValuesAndDescription<ETest>();
        }

        [Fact]
        public void ShouldReturnListWithAllOptions()
        {
            var list = EnumHelpers.ToListOfValuesAndDescription<ETest>();
            Assert.Equal(2, list.Count);
        }

        [Fact]
        public void ShouldFormatTheValuesInIdAndDescriptionFormat()
        {
            var list = EnumHelpers.ToListOfValuesAndDescription<ETest>();
            Assert.Equal("1 - FirstValue", list[0]);
        }

        [Fact]
        public void ShouldReturnCorrectValue()
        {
            var value = EnumHelpers.GetByValue<ETest>(1);
            Assert.Equal(ETest.FirstValue, value);
        }
    }
}
