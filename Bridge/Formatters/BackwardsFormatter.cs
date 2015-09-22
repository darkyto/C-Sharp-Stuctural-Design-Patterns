namespace Bridge.Formatters
{
    using System;
    using System.Linq;

    public class BackwardsFormatter : IFormatter
    {
        public string Format(string key, string value)
        {
            return string.Format(
                "{0}: {1}", 
                key, 
                new string(value.Reverse().ToArray()));
        }
    }
}
