using NUnit.Framework;
using System.Linq;

namespace Gxs.Ecxpress.Tests
{
    [TestFixture]
    public class MailboxItemTests
    {
        [Test]
        public void Parse()
        {
            var input = new [] {
                "HEADER",
                "------",
                "9377777777777                       Y ORDERS         15844          001111111111111111       2 "
            };

            var actual = MailboxItem.Parse(input);

            Assert.AreEqual(1, actual.Count);
            var item = actual.First();
            Assert.AreEqual("9377777777777", item.SenderId);
            Assert.AreEqual("Y", item.St);
            Assert.AreEqual("ORDERS", item.ApplicationReference);
            Assert.AreEqual("15844", item.SenderReference);
            Assert.AreEqual("001111111111111111", item.ServiceReference);
            Assert.AreEqual("2", item.Size);
        }
    }
}
