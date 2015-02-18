using NUnit.Framework;
using System.Linq;

namespace Gxs.Ecxpress.Tests
{
    [TestFixture]
    public class PostboxItemTests
    {
        [Test]
        public void Parse()
        {
            var input = new[] {
                "HEADER",
                "------",
                "TRADANET                            20141018:161241  PBLIST         11111111111111 222222222222222222      "
            };

            var actual = PostboxItem.Parse(input);

            Assert.AreEqual(1, actual.Count);
            var item = actual.First();
            Assert.AreEqual("TRADANET", item.RecipientId);
            Assert.AreEqual("20141018:161241", item.DateTime);
            Assert.AreEqual("PBLIST", item.ApplicationReference);
            Assert.AreEqual("11111111111111", item.SenderReference);
            Assert.AreEqual("222222222222222222", item.ServiceReference);
        }
    }
}
