namespace Bridge.Formatters
{
    using System;

    public interface IFormatter
    {
        string Format(string key, string value);
    }
}
