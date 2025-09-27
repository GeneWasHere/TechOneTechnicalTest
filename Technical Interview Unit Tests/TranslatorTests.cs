using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechOneTechnicalTest;

namespace Technical_Interview_Unit_Tests
{
    [TestClass]
    public sealed class TranslatorTests
    {
        //Calls the NumericalTranslator component from the main project
        private readonly TechOneTechnicalTest.Components.Pages.NumericalTranslator translator = new();


        [TestMethod]
        public void TestDigit_One()
        {
            string result = translator.BruteTranslatorAlgorithm(1);
            Assert.AreEqual("One", result);
        }

        [TestMethod]
        public void TestDigit_Nine()
        {
            string result = translator.BruteTranslatorAlgorithm(9);
            Assert.AreEqual("Nine", result);
        }

        [TestMethod]
        public void TestTeen_Twelve()
        {
            string result = translator.BruteTranslatorAlgorithm(12);
            Assert.AreEqual("Twelve", result);
        }

        [TestMethod]
        public void TestTeen_Seventeen()
        {
            string result = translator.BruteTranslatorAlgorithm(17);
            Assert.AreEqual("Seventeen", result);
        }

        [TestMethod]
        public void TestTens_Ten()
        {
            string result = translator.BruteTranslatorAlgorithm(10);
            Assert.AreEqual("Ten", result);
        }

        [TestMethod]
        public void TestTens_Twenty()
        {
            string result = translator.BruteTranslatorAlgorithm(20);
            Assert.AreEqual("Twenty", result);
        }

        [TestMethod]
        public void TestTens_Eighty()
        {
            string result = translator.BruteTranslatorAlgorithm(80);
            Assert.AreEqual("Eighty", result);
        }

        [TestMethod]
        public void TestTens_ThirtyThree()
        {
            string result = translator.BruteTranslatorAlgorithm(33);
            Assert.AreEqual("Thirty-Three", result);
        }

        [TestMethod]
        public void TestTens_Eighty() =>
            Assert.AreEqual("Eighty", translator.ConversionAlgorithm(80));

        [TestMethod]
        public void TestHundred_OneHundredTwentyThree()
        {
            string result = translator.BruteTranslatorAlgorithm(123);
            Assert.AreEqual("One Hundred and Twenty-Three", result);
        }

        [TestMethod]
        public void TestHundred_OneHundredFive()
        {
            string result = translator.BruteTranslatorAlgorithm(105);
            Assert.AreEqual("One Hundred and Five", result);
        }

        [TestMethod]
        public void TestHundred_OneHundredTen()
        {
            string result = translator.BruteTranslatorAlgorithm(110);
            Assert.AreEqual("One Hundred and Ten", result);
        }

        [TestMethod]
        public void TestThousand_OneThousand()
        {
            string result = translator.BruteTranslatorAlgorithm(1000);
            Assert.AreEqual("One Thousand", result);
        }

        [TestMethod]
        public void TestThousand_OneThousandFive()
        {
            string result = translator.BruteTranslatorAlgorithm(1005);
            Assert.AreEqual("One Thousand Five", result);
        }

        [TestMethod]
        public void TestThousand_OneThousandOne()
        {
            string result = translator.BruteTranslatorAlgorithm(1001);
            Assert.AreEqual("One Thousand One", result);
        }

        [TestMethod]
        public void TestThousand_OneThousandTwoHundredThirtyFour()
        {
            string result = translator.BruteTranslatorAlgorithm(1234);
            Assert.AreEqual("One Thousand Two Hundred Thirty-Four", result);
        }

        [TestMethod]
        public void TestThousand_TenThousand()
        {
            string result = translator.BruteTranslatorAlgorithm(10000);
            Assert.AreEqual("Ten Thousand", result);
        }

        [TestMethod]
        public void TestThousand_OneHundredThousand()
        {
            string result = translator.BruteTranslatorAlgorithm(100000);
            Assert.AreEqual("One Hundred Thousand", result);
        }

        // --- Millions Tests ---
        [TestMethod]
        public void TestMillion_OneMillion()
        {
            string result = translator.BruteTranslatorAlgorithm(1000000);
            Assert.AreEqual("One Million", result);
        }

        [TestMethod]
        public void TestMillion_OneMillionOne()
        {
            string result = translator.BruteTranslatorAlgorithm(1000001);
            Assert.AreEqual("One Million One", result);
        }

        [TestMethod]
        public void TestMillion_TenMillion()
        {
            string result = translator.BruteTranslatorAlgorithm(10000000);
            Assert.AreEqual("Ten Million", result);
        }

        [TestMethod]
        public void TestMillion_OneHundredMillion()
        {
            string result = translator.BruteTranslatorAlgorithm(100000000);
            Assert.AreEqual("One Hundred Million", result);
        }

        [TestMethod]
        public void TestMillion_OneHundredMillionOne()
        {
            string result = translator.BruteTranslatorAlgorithm(100000001);
            Assert.AreEqual("One Hundred Million One", result);
        }

        [TestMethod]
        public void TestBillion_NineBillionEightHundredSeventySixMillionFiveHundredFortyThreeThousandTwoHundredTen()
        {
            string result = translator.BruteTranslatorAlgorithm(9876543210);
            Assert.AreEqual("Nine Billion Eight Hundred Seventy-Six Million Five Hundred Forty-Three Thousand Two Hundred Ten", result);
        }

        [TestMethod]
        public void TestBillion_OneBillionOne()
        {
            string result = translator.BruteTranslatorAlgorithm(1000000001);
            Assert.AreEqual("One Billion One", result);
        }

        [TestMethod]
        public void TestBillion_TenBillion()
        {
            string result = translator.BruteTranslatorAlgorithm(10000000000);
            Assert.AreEqual("Ten Billion", result);
        }

        [TestMethod]
        public void TestBillion_OneHundredBillion()
        {
            string result = translator.BruteTranslatorAlgorithm(100000000000);
            Assert.AreEqual("One Hundred Billion", result);
        }

        [TestMethod]
        public void TestTrillion_OneTrillion()
        {
            string result = translator.BruteTranslatorAlgorithm(1000000000000);
            Assert.AreEqual("One Trillion", result);
        }

        [TestMethod]
        public void TestTrillion_OneTrillionOne()
        {
            string result = translator.BruteTranslatorAlgorithm(1000000000001);
            Assert.AreEqual("One Trillion One", result);
        }

        [TestMethod]
        public void TestTrillion_ComplexTrillion()
        {
            string result = translator.BruteTranslatorAlgorithm(1234567890123);
            Assert.AreEqual("One Trillion Two Hundred Thirty-Four Billion Five Hundred Sixty-Seven Million Eight Hundred Ninety Thousand One Hundred Twenty-Three", result);
        }

        [TestMethod]
        public void TestMisc_LeadingZeros()
        {
            string result = translator.BruteTranslatorAlgorithm(0000123);
            Assert.AreEqual("One Hundred and Twenty-Three", result);
        }

        [TestMethod]
        public void TestMisc_Zero()
        {
            string result = translator.BruteTranslatorAlgorithm(0);
            Assert.AreEqual("Zero", result);
        }

        [TestMethod]
        public void TestMisc_MaxInt()
        {
            string result = translator.BruteTranslatorAlgorithm(int.MaxValue);
            Assert.AreEqual("Two Billion One Hundred Forty-Seven Million Four Hundred Eighty-Three Thousand Six Hundred Forty-Seven", result);
        }

        [TestMethod]
        public void TestMisc_NegativeNumber()
        {
            string result = translator.BruteTranslatorAlgorithm(-123);
            Assert.AreEqual("Negative One Hundred and Twenty-Three", result);
        }
        [TestMethod]
        public void TestMisc_NegativeTrillion()
        {
            string result = translator.BruteTranslatorAlgorithm(-1000000000000);
            Assert.AreEqual("Negative One Trillion", result);
        }
        [TestMethod]
        public void TestMisc_NegativeComplexNumber()
        {
            string result = translator.BruteTranslatorAlgorithm(-9876543210);
            Assert.AreEqual("Negative Nine Billion Eight Hundred Seventy-Six Million Five Hundred Forty-Three Thousand Two Hundred Ten", result);
        }

        // --- Edge Case Tests ---

        [TestMethod]
        public void TestEdge_MinLong()
        {
            string result = translator.BruteTranslatorAlgorithm(long.MinValue);
            Assert.AreEqual("Error: Number is at the lowest possible numer of long, an unrealistic input", result);
        }

        [TestMethod]
        public void TestEdge_MaxLong()
        {
            string result = translator.BruteTranslatorAlgorithm(long.MaxValue);
            Assert.AreEqual("Nine Quintillion Two Hundred Twenty-Three Quadrillion Three Hundred Seventy-Two Trillion Thirty-Six Billion Eight Hundred Fifty-Four Million Seven Hundred Seventy-Five Thousand Eight Hundred Seven", result);
        }

        [TestMethod]
        public void TestEdge_NegativeOne()
        {
            string result = translator.BruteTranslatorAlgorithm(-1);
            Assert.AreEqual("Negative One", result);
        }

        [TestMethod]
        public void TestEdge_NegativeTen()
        {
            string result = translator.BruteTranslatorAlgorithm(-10);
            Assert.AreEqual("Negative Ten", result);
        }

        [TestMethod]
        public void TestEdge_NegativeHundredThousand()
        {
            string result = translator.BruteTranslatorAlgorithm(-100000);
            Assert.AreEqual("Negative One Hundred Thousand", result);
        }

        [TestMethod]
        public void TestEdge_NegativeMillion()
        {
            string result = translator.BruteTranslatorAlgorithm(-1000000);
            Assert.AreEqual("Negative One Million", result);
        }

        [TestMethod]
        public void TestEdge_NegativeComplex()
        {
            string result = translator.BruteTranslatorAlgorithm(-123456789012345);
            Assert.AreEqual("Negative One Hundred Twenty-Three Trillion Four Hundred Fifty-Six Billion Seven Hundred Eighty-Nine Million Twelve Thousand Three Hundred Forty-Five", result);
        }

        [TestMethod]
        public void TestEdge_ZeroWithLongType()
        {
            string result = translator.BruteTranslatorAlgorithm(0L);
            Assert.AreEqual("Zero", result);
        }
    }
}