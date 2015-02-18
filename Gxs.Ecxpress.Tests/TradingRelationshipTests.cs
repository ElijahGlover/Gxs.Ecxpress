using NUnit.Framework;
using System.Linq;

namespace Gxs.Ecxpress.Tests
{
    [TestFixture]
    public class TradingRelationshipTests
    {
        [Test]
        public void Parse()
        {
            var input = new[] {
                "HEADER",
                "------",
                "*NULL          S 0    9377777134575                                                               "
            };

            var actual = TradingRelationship.Parse(input);

            Assert.AreEqual(1, actual.Count);
            var item = actual.First();
            Assert.AreEqual("*NULL", item.ApplicationReference);
            Assert.AreEqual("S", item.Direction);
            Assert.AreEqual("0", item.Qualifier);
            Assert.AreEqual("9377777134575", item.UserId);
        }
    }
}
