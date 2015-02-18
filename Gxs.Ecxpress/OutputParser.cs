namespace Gxs.Ecxpress
{
    public static class OutputParser
    {
        public static string[] Split(string input, int[] bounds)
        {
            var value = new string[bounds.Length];
            var lastBound = 0;

            for (var i = 0; i < bounds.Length; i++) {
                var nextBound = bounds[i] - lastBound;
                value[i] = input.Substring(lastBound, nextBound).Trim();
                lastBound = bounds[i];
            }

            return value;
        }
    }
}
