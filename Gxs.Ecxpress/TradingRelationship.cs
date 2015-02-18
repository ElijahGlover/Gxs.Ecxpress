using System;
using System.Collections.Generic;
using System.Linq;

namespace Gxs.Ecxpress
{
    public class TradingRelationship
    {
        public TradingRelationship(IList<string> args)
        {
            if (args == null || args.Count < 4)
                throw new ArgumentException("args");
            ApplicationReference = args[0];
            Direction = args[1];
            Qualifier = args[2];
            UserId = args[3];
        }

        public string ApplicationReference { get; private set; }
        public string Direction { get; private set; }
        public string Qualifier { get; private set; }
        public string UserId { get; private set; }

        public static IList<TradingRelationship> Parse(string[] source)
        {
            return source.Skip(2)
               .Select(p => OutputParser.Split(p, new [] { 15, 17, 22, 38 }))
               .Select(p => new TradingRelationship(p))
               .ToList();
        }
    }
}
