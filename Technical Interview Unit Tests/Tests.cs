using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechOneTechnicalTest;

namespace Technical_Interview_Unit_Tests
{
    [TestClass]
    public sealed class Tests
    {
        // Create a single reusable translator instance
        private readonly TechOneTechnicalTest.Components.Pages.NumericalTranslator translator = new();

        #region Single Digit Tests

        [TestMethod]
        public void TestDigit_One() =>
            Assert.AreEqual("One", translator.ConversionAlgorithm(1));

        [TestMethod]
        public void TestDigit_Nine() =>
            Assert.AreEqual("Nine", translator.ConversionAlgorithm(9));

        [TestMethod]
        public void TestDigit_Nineteen() =>
            Assert.AreEqual("Nineteen", translator.ConversionAlgorithm(19));

        #endregion

        #region Teen and Tens Tests

        [TestMethod]
        public void TestTeen_Twelve() =>
            Assert.AreEqual("Twelve", translator.ConversionAlgorithm(12));

        [TestMethod]
        public void TestTeen_Seventeen() =>
            Assert.AreEqual("Seventeen", translator.ConversionAlgorithm(17));

        [TestMethod]
        public void TestTens_Ten() =>
            Assert.AreEqual("Ten", translator.ConversionAlgorithm(10));

        [TestMethod]
        public void TestTens_Twenty() =>
            Assert.AreEqual("Twenty", translator.ConversionAlgorithm(20));

        [TestMethod]
        public void TestTens_TwentyNine() =>
            Assert.AreEqual("Twenty-Nine", translator.ConversionAlgorithm(29));

        [TestMethod]
        public void TestTens_Eighty() =>
            Assert.AreEqual("Eighty", translator.ConversionAlgorithm(80));

        [TestMethod]
        public void TestTens_ThirtyThree() =>
            Assert.AreEqual("Thirty-Three", translator.ConversionAlgorithm(33));

        [TestMethod]
        public void TestTens_NinetyNine() =>
            Assert.AreEqual("Ninety-Nine", translator.ConversionAlgorithm(99));

        #endregion

        #region Hundreds Tests

        [TestMethod]
        public void TestHundred_OneHundred() =>
            Assert.AreEqual("One Hundred", translator.ConversionAlgorithm(100));

        [TestMethod]
        public void TestHundred_TwoHundred() =>
            Assert.AreEqual("Two Hundred", translator.ConversionAlgorithm(200));

        [TestMethod]
        public void TestHundred_OneHundredTwentyThree() =>
            Assert.AreEqual("One Hundred and Twenty-Three", translator.ConversionAlgorithm(123));

        [TestMethod]
        public void TestHundred_OneHundredFive() =>
            Assert.AreEqual("One Hundred and Five", translator.ConversionAlgorithm(105));

        [TestMethod]
        public void TestHundred_OneHundredTen() =>
            Assert.AreEqual("One Hundred and Ten", translator.ConversionAlgorithm(110));

        [TestMethod]
        public void TestHundred_TwoHundredFifteen() =>
            Assert.AreEqual("Two Hundred and Fifteen", translator.ConversionAlgorithm(215));

        [TestMethod]
        public void TestHundred_NineHundredNinetyNine() =>
            Assert.AreEqual("Nine Hundred and Ninety-Nine", translator.ConversionAlgorithm(999));

        #endregion

        #region Thousands Tests

        [TestMethod]
        public void TestThousand_OneThousand() =>
            Assert.AreEqual("One Thousand", translator.ConversionAlgorithm(1000));

        [TestMethod]
        public void TestThousand_TwoThousand() =>
            Assert.AreEqual("Two Thousand", translator.ConversionAlgorithm(2000));

        [TestMethod]
        public void TestThousand_TwentyThousand() =>
            Assert.AreEqual("Twenty Thousand", translator.ConversionAlgorithm(20000));

        [TestMethod]
        public void TestThousand_TwoHundredThousand() =>
            Assert.AreEqual("Two Hundred Thousand", translator.ConversionAlgorithm(200000));

        [TestMethod]
        public void TestThousand_TwoHundredThousandFive() =>
            Assert.AreEqual("Two Hundred Thousand Five", translator.ConversionAlgorithm(200005));

        [TestMethod]
        public void TestThousand_OneThousandFive() =>
            Assert.AreEqual("One Thousand Five", translator.ConversionAlgorithm(1005));

        [TestMethod]
        public void TestThousand_OneThousandOne() =>
            Assert.AreEqual("One Thousand One", translator.ConversionAlgorithm(1001));

        [TestMethod]
        public void TestThousand_OneThousandTwoHundredThirtyFour() =>
            Assert.AreEqual("One Thousand Two Hundred and Thirty-Four", translator.ConversionAlgorithm(1234));

        [TestMethod]
        public void TestThousand_TenThousand() =>
            Assert.AreEqual("Ten Thousand", translator.ConversionAlgorithm(10000));

        [TestMethod]
        public void TestThousand_OneHundredThousand() =>
            Assert.AreEqual("One Hundred Thousand", translator.ConversionAlgorithm(100000));

        [TestMethod]
        public void TestRecursive_CompoundNumber() =>
            Assert.AreEqual("One Hundred and Twenty Thousand Three Hundred and Five", translator.ConversionAlgorithm(120305));

        [TestMethod]
        public void TestRecursive_MixedSegments() =>
            Assert.AreEqual("One Million One Thousand One", translator.ConversionAlgorithm(1001001));

        #endregion

        #region Millions and Billions Tests

        [TestMethod]
        public void TestMillion_OneMillion() =>
            Assert.AreEqual("One Million", translator.ConversionAlgorithm(1000000));

        [TestMethod]
        public void TestMillion_OneMillionOne() =>
            Assert.AreEqual("One Million One", translator.ConversionAlgorithm(1000001));

        [TestMethod]
        public void TestMillion_TenMillion() =>
            Assert.AreEqual("Ten Million", translator.ConversionAlgorithm(10000000));

        [TestMethod]
        public void TestMillion_OneHundredMillion() =>
            Assert.AreEqual("One Hundred Million", translator.ConversionAlgorithm(100000000));

        [TestMethod]
        public void TestMillion_OneHundredMillionOne() =>
            Assert.AreEqual("One Hundred Million One", translator.ConversionAlgorithm(100000001));

        [TestMethod]
        public void TestBillion_Complex() =>
            Assert.AreEqual(
                "Nine Billion Eight Hundred and Seventy-Six Million Five Hundred and Forty-Three Thousand Two Hundred and Ten",
                translator.ConversionAlgorithm(9876543210));

        [TestMethod]
        public void TestBillion_OneBillionOne() =>
            Assert.AreEqual("One Billion One", translator.ConversionAlgorithm(1000000001));

        [TestMethod]
        public void TestBillion_TenBillion() =>
            Assert.AreEqual("Ten Billion", translator.ConversionAlgorithm(10000000000));

        [TestMethod]
        public void TestBillion_OneHundredBillion() =>
            Assert.AreEqual("One Hundred Billion", translator.ConversionAlgorithm(100000000000));

        #endregion

        #region Trillions and Beyond
        [TestMethod]
        public void TestTrillion_OneTrillion() =>
            Assert.AreEqual("One Trillion", translator.ConversionAlgorithm(1000000000000));

        [TestMethod]
        public void TestTrillion_OneTrillionOne() =>
            Assert.AreEqual("One Trillion One", translator.ConversionAlgorithm(1000000000001));

        [TestMethod]
        public void TestTrillion_Complex() =>
            Assert.AreEqual(
                "One Trillion Two Hundred and Thirty-Four Billion Five Hundred and Sixty-Seven Million Eight Hundred and Ninety Thousand One Hundred and Twenty-Three",
                translator.ConversionAlgorithm(1234567890123));

        #endregion

        #region Negative Number Tests

        [TestMethod]
        public void TestNegative_SingleDigit() =>
            Assert.AreEqual("Negative Seven", translator.ConversionAlgorithm(-7));

        [TestMethod]
        public void TestNegative_TwoDigit() =>
            Assert.AreEqual("Negative Forty-Two", translator.ConversionAlgorithm(-42));

        [TestMethod]
        public void TestNegative_ComplexNumber() =>
            Assert.AreEqual("Negative One Hundred and Twenty-Three", translator.ConversionAlgorithm(-123));

        [TestMethod]
        public void TestNegative_Large() =>
            Assert.AreEqual("Negative Nine Billion Eight Hundred and Seventy-Six Million Five Hundred and Forty-Three Thousand Two Hundred and Ten",
                translator.ConversionAlgorithm(-9876543210));

        [TestMethod]
        public void TestNegative_HundredThousand() =>
            Assert.AreEqual("Negative One Hundred Thousand", translator.ConversionAlgorithm(-100000));

        [TestMethod]
        public void TestNegative_Million() =>
            Assert.AreEqual("Negative One Million", translator.ConversionAlgorithm(-1000000));

        [TestMethod]
        public void TestNegative_ComplexLarge() =>
            Assert.AreEqual(
                "Negative One Hundred and Twenty-Three Trillion Four Hundred and Fifty-Six Billion Seven Hundred and Eighty-Nine Million Twelve Thousand Three Hundred and Forty-Five",
                translator.ConversionAlgorithm(-123456789012345));

        #endregion

        #region Miscellaneous Tests

        [TestMethod]
        public void TestMisc_LeadingZeros() =>
            Assert.AreEqual("One Hundred and Twenty-Three", translator.ConversionAlgorithm(0000123));

        [TestMethod]
        public void TestMisc_Zero() =>
            Assert.AreEqual("Zero", translator.ConversionAlgorithm(0));

        [TestMethod]
        public void TestFormat_HyphenConsistency() =>
            Assert.AreEqual("Forty-Two", translator.ConversionAlgorithm(42));

        [TestMethod]
        public void TestFormat_Spacing() =>
            Assert.AreEqual("One Thousand Ten", translator.ConversionAlgorithm(1010));

        #endregion

        #region Edge Case Tests

        [TestMethod]
        public void TestEdge_MinLong() =>
            Assert.AreEqual("Input number is too small", translator.ConversionAlgorithm(long.MinValue));

        [TestMethod]
        public void TestEdge_MaxLong() =>
            Assert.AreEqual(
                "Nine Sextillion Two Hundred and Twenty-Three Quintillion Three Hundred and Seventy-Two Trillion Thirty-Six Billion Eight Hundred and Fifty-Four Million Seven Hundred and Seventy-Five Thousand Eight Hundred and Seven",
                translator.ConversionAlgorithm(long.MaxValue));

        [TestMethod]
        public void TestEdge_NegativeOne() =>
            Assert.AreEqual("Negative One", translator.ConversionAlgorithm(-1));

        [TestMethod]
        public void TestEdge_NegativeTen() =>
            Assert.AreEqual("Negative Ten", translator.ConversionAlgorithm(-10));

        [TestMethod]
        public void TestEdge_ZeroWithLongType() =>
            Assert.AreEqual("Zero", translator.ConversionAlgorithm(0L));

        [TestMethod]
        public void TestExtreme_LargeBoundary() =>
            Assert.AreEqual(
                "Nine Sextillion Two Hundred and Twenty-Three Quintillion Three Hundred and Seventy-Two Trillion Thirty-Six Billion Eight Hundred and Fifty-Four Million Seven Hundred and Seventy-Five Thousand Eight Hundred and Seven",
                translator.ConversionAlgorithm(9_223_372_036_854_775_807));

        #endregion
    }
}
