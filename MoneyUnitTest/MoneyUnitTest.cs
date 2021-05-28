using DDD.Demo.Base_Patterns.value_object;
using Xunit;

namespace MoneyUnitTest
{
    public class MoneyUnitTest
    {
        [Fact]
        public void TestAllocate2()
        {
            //
            int[] allocation = { 3, 7 };
            Money[] result = Money.Dollars(0.05m).Allocate(allocation);
            Assert.Equal(Money.Dollars(0.02m), result[0]);
            Assert.Equal(Money.Dollars(0.03m), result[1]);
        }
    }
}
