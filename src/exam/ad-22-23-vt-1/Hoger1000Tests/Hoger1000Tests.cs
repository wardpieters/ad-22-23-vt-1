using NUnit.Framework;

namespace AD
{
    [TestFixture]
    public partial class Hoger1000Tests
    {
        [TestCase(1, 2401)]
        [TestCase(4, 1372)]
        [TestCase(12, 4116)]
        [TestCase(14, 4802)]
        [TestCase(67, 3283)]
        [TestCase(97, 4753)]
        [TestCase(142, 6958)]
        [TestCase(143, 1001)]
        [TestCase(185, 1295)]
        [TestCase(197, 1379)]
        [TestCase(331, 2317)]
        [TestCase(500, 3500)]
        [TestCase(659, 4613)]
        [TestCase(969, 6783)]
        [TestCase(1000, 7000)]
        [TestCase(1001, 1001)]
        public void Hoger1000Test(int input, int expected)
        {
            // Act
            int actual = Hoger1000.ZoekHoger1000(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}