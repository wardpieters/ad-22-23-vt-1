using NUnit.Framework;

namespace AD
{
    public class BigIntTests
    {
        [TestCase("34.5")]
        [TestCase("54e2")]
        [TestCase("abc")]
        [TestCase("+13")]
        public void BigInt_1_Constructor_1_WrongInput(string input)
        {
            // Arrange
            BigInt b;

            // Act

            // Assert
            Assert.Throws(typeof(BigIntWrongInputException), () => b = new BigInt(input));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("0")]
        public void BigInt_1_Constructor_2_Zero(string input)
        {
            // Arrange
            BigInt b;

            // Act
            b = new BigInt(input);

            // Assert
            Assert.IsTrue(b.isPositive);
            Assert.IsNotNull(b.first);
            Assert.AreEqual(0, b.first.value);
            Assert.IsNull(b.first.next);
        }

        [TestCase("0", 0, true)]
        [TestCase("1", 1, true)]
        [TestCase("7", 7, true)]
        [TestCase("9", 9, true)]
        [TestCase("-1", 1, false)]
        [TestCase("-3", 3, false)]
        [TestCase("-9", 9, false)]
        public void BigInt_1_Constructor_3_OneDigit(string input, int expected_value, bool expected_positive)
        {
            // Arrange
            BigInt b;

            // Act
            b = new BigInt(input);

            // Assert
            Assert.AreEqual(expected_positive, b.isPositive);
            Assert.IsNotNull(b.first);
            Assert.AreEqual(expected_value, b.first.value);
            Assert.IsNull(b.first.next);
        }

        [Test, Sequential]
        public void BigInt_1_Constructor_4_BiggerNumbers(
            [Values(
                "123",
                "12345678",
                "120",
                "987600",
                "397513948752134619234601348570923475093247562304865",
                "-123",
                "-12345678",
                "-120",
                "-987600",
                "-397513948752134619234601348570923475093247562304865"
            )] string input)
        {
            // Arrange
            BigInt b;

            // Act
            b = new BigInt(input);

            // Assert
            BigIntDigit ptr = b.first;
            for (int i = input.Length - 1; (i >= 0) && (ptr != null); i--)
            {
                Assert.AreEqual(input[i] - '0', ptr.value);
                ptr = ptr.next;
            }
            Assert.IsNull(ptr);
            Assert.AreEqual((input[0] != '-'), b.isPositive);
        }

        [Test, Sequential]
        public void BigInt_2_ToString(
            [Values(
                "0", "1", "7", "9", "-1", "-3", "-9",
                "123",
                "12345678",
                "120",
                "987600",
                "397513948752134619234601348570923475093247562304865",
                "-123",
                "-12345678",
                "-120",
                "-987600",
                "-397513948752134619234601348570923475093247562304865"
            )] string input)
        {
            // Arrange
            BigInt b = new BigInt(input);
            string expected = input;

            // Act
            string actual = b.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("0", 0)]
        [TestCase("123", 6)]
        [TestCase("111", 3)]
        [TestCase("1357", 16)]
        [TestCase("-123", 6)]
        [TestCase("-111", 3)]
        [TestCase(null, 0)]
        public void BigInt_3_Sum(string input, int expected)
        {
            // Arrange
            BigInt b = new BigInt(input);

            // Act
            int actual = b.Sum();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("0", "1")]
        [TestCase("1", "2")]
        [TestCase("9", "10")]
        [TestCase("10", "11")]
        [TestCase("73", "74")]
        [TestCase("120", "121")]
        [TestCase("129", "130")]
        [TestCase("12345678", "12345679")]
        [TestCase("1000000000", "1000000001")]
        [TestCase("99999999999999999999999999999999", "100000000000000000000000000000000")]
        [TestCase("99999999999999999799999999999999", "99999999999999999800000000000000")]
        public void BigInt_4_Increment(string input, string expected)
        {
            // Arrange
            BigInt b = new BigInt(input);

            // Act
            b.Increment();
            string actual = b.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("0", "1", true)]
        [TestCase("1", "2", true)]
        [TestCase("9", "10", true)]
        [TestCase("10", "11", true)]
        [TestCase("73", "74", true)]
        [TestCase("120", "121", true)]
        [TestCase("129", "130", true)]
        [TestCase("12345678", "12345679", true)]
        [TestCase("1000000000", "1000000001", true)]
        [TestCase("99999999999999999999999999999999", "100000000000000000000000000000000", true)]
        [TestCase("99999999999999999799999999999999", "99999999999999999800000000000000", true)]
        [TestCase("-1000", "-999", false)]
        [TestCase("-124", "-123", false)]
        [TestCase("-11", "-10", false)]
        [TestCase("-10", "-9", false)]
        [TestCase("-1", "0", true)]
        public void BigInt_5_Increment_Better(string input, string expected_value, bool expected_positive)
        {
            // Arrange
            BigInt b = new BigInt(input);

            // Act
            b.IncrementBetter();
            string actual_value = b.ToString();
            bool actual_positive = b.isPositive;

            // Assert
            Assert.AreEqual(expected_value, actual_value);
            Assert.AreEqual(expected_positive, actual_positive);
        }
    }
}