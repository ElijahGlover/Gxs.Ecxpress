using System;
using System.Collections.Generic;
using System.Linq;

namespace Gxs.Ecxpress
{
    public class PostboxItem
    {
        public PostboxItem(IList<string> args)
        {
            if (args == null || args.Count < 4)
                throw new ArgumentException("args");
            RecipientId = args[0];
            DateTime = args[1];
            ApplicationReference = args[2];
            SenderReference = args[3];
            ServiceReference = args[4];
        }

        public string RecipientId { get; private set; }
        public string DateTime { get; private set; }
        public string ApplicationReference { get; private set; }
        public string SenderReference { get; private set; }
        public string ServiceReference { get; private set; }

        public static IList<PostboxItem> Parse(string[] source)
        {
            return source.Skip(2)
               .Select(p => OutputParser.Split(p, new [] { 36, 53, 68, 83, 102 }))
               .Select(p => new PostboxItem(p))
               .ToList();
        }
    }
}
