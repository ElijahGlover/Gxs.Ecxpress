using System;
using System.Collections.Generic;
using System.Linq;

namespace Gxs.Ecxpress
{
    public class MailboxItem
    {
        public MailboxItem(IList<string> args)
        {
            if (args == null || args.Count < 5)
                throw new ArgumentException("args");
            SenderId = args[0];
            St = args[1];
            ApplicationReference = args[2];
            SenderReference = args[3];
            ServiceReference = args[4];
            Size = args[5];
        }

        public string SenderId { get; private set; }
        public string St { get; private set; }
        public string ApplicationReference { get; private set; }
        public string SenderReference { get; private set; }
        public string ServiceReference { get; private set; }
        public string Size { get; private set; }

        public static IList<MailboxItem> Parse(string[] source)
        {
            return source.Skip(2)
                .Select(p => OutputParser.Split(p, new [] { 36, 38, 53, 68, 93, 95 }))
                .Select(p => new MailboxItem(p))
                .ToList();
        }
    }
}
