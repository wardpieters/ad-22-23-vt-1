using NUnit.Framework;

namespace AD
{
    [TestFixture]
    public partial class KwadratenStringTests
    {
        [TestCase(-29, "_")]
        [TestCase(-13, "_")]
        [TestCase(-13, "_")]
        [TestCase(-9, "_")]
        [TestCase(-9, "_")]
        [TestCase(-4, "_")]
        [TestCase(-1, "_")]
        [TestCase(0, "_0_")]
        [TestCase(0, "_0_")]
        [TestCase(1, "_0_1_")]
        [TestCase(3, "_0_1_4_9_")]
        [TestCase(5, "_0_1_4_9_16_25_")]
        [TestCase(9, "_0_1_4_9_16_25_36_49_64_81_")]
        [TestCase(12, "_0_1_4_9_16_25_36_49_64_81_100_121_144_")]
        [TestCase(15, "_0_1_4_9_16_25_36_49_64_81_100_121_144_169_196_225_")]
        [TestCase(15, "_0_1_4_9_16_25_36_49_64_81_100_121_144_169_196_225_")]
        [TestCase(20, "_0_1_4_9_16_25_36_49_64_81_100_121_144_169_196_225_256_289_324_361_400_")]
        [TestCase(24, "_0_1_4_9_16_25_36_49_64_81_100_121_144_169_196_225_256_289_324_361_400_441_484_529_576_")]
        [TestCase(27, "_0_1_4_9_16_25_36_49_64_81_100_121_144_169_196_225_256_289_324_361_400_441_484_529_576_625_676_729_")]
        [TestCase(28, "_0_1_4_9_16_25_36_49_64_81_100_121_144_169_196_225_256_289_324_361_400_441_484_529_576_625_676_729_784_")]
        [TestCase(29, "_0_1_4_9_16_25_36_49_64_81_100_121_144_169_196_225_256_289_324_361_400_441_484_529_576_625_676_729_784_841_")]
        [TestCase(31, "_0_1_4_9_16_25_36_49_64_81_100_121_144_169_196_225_256_289_324_361_400_441_484_529_576_625_676_729_784_841_900_961_")]
        [TestCase(45, "_0_1_4_9_16_25_36_49_64_81_100_121_144_169_196_225_256_289_324_361_400_441_484_529_576_625_676_729_784_841_900_961_1024_1089_1156_1225_1296_1369_1444_1521_1600_1681_1764_1849_1936_2025_")]
        public void KwadratenStringTest(int input, string expected)
        {
            // Act
            string actual = KwadratenStrings.KwadratenString(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}