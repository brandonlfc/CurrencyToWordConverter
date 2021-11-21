using NUnit.Framework;

namespace NumbersToEnglish
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void VerifyOutputMatchesInput()
        { 
            string ConvertedValue = CurrencyToEnglish.ToWords("124.5");
            Assert.AreEqual("One Hundred Twenty Four Dollars and Five Cents", ConvertedValue.Trim()); 
        }

        [Test]
        public void VerifyOutputDosentMatchInput()
        {
            string ConvertedValue = CurrencyToEnglish.ToWords("124.5");
            Assert.AreEqual("One Hundred Twenty Four Dollars and Six Cents", ConvertedValue.Trim());
        }
    }
}