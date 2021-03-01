using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaPizzaz;

namespace PizzaPizzazCalculationsTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            decimal expectedResult = App.GrossProfit;
            decimal actualResult = PizzaPizzazCalculations.DailyProfitInformation();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
