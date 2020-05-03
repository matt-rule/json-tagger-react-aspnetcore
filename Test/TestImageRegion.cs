using JsonTagger.BusinessLogic;
using NUnit.Framework;
using System.Linq;

namespace Test
{
    public static class TestImageRegion
    {
        [Test]
        public static void RangesForAxis()
        {
            int testDivisions = 4;
            int testWidth = 10;

            var ranges = ImageRegion.RangesForAxis(testDivisions, testWidth);

            Assert.AreEqual (0, ranges[0].Item1);
            Assert.AreEqual (1, ranges[0].Item2);
            Assert.AreEqual (2, ranges[1].Item1);
            Assert.AreEqual (4, ranges[1].Item2);
            Assert.AreEqual (7, ranges[3].Item1);
            Assert.AreEqual (9, ranges[3].Item2);
        }

        [Test]
        public static void ValidNumberOfRegionsForImageRect()
        {
            Assert.AreEqual (
                144,
                ImageRegion.Divide(12, 2000, 1500).Count()
            );
        }
    }
}