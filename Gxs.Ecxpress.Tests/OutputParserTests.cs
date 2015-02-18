using NUnit.Framework;

namespace Gxs.Ecxpress.Tests
{
    [TestFixture]
    public class OutputParserTests
    {
        [Test]
        public void SplitString()
        {
            const string value = "9327777777777                       Y                10978          001111111111111111       2 ";
            var bounds = new int[] { 36, 53, 68, 93, 95 };
            var actual = OutputParser.Split(value, bounds);
            Assert.AreEqual(5, actual.Length);
            Assert.AreEqual("9327777777777", actual[0]);
            Assert.AreEqual("Y", actual[1]);
            Assert.AreEqual("10978", actual[2]);
            Assert.AreEqual("001111111111111111", actual[3]);
            Assert.AreEqual("2", actual[4]);
        }
    }
}
