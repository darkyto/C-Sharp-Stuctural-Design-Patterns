namespace Flyweight
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            FlyweightDemo();

            Console.WriteLine(new string('-', 60));
        }

        private static void FlyweightDemo()
        {
            // Build a document with text
            const string Document = "AAZZBBZB";
            var chars = Document.ToCharArray();

            var factory = new CharacterFactory();

            // extrinsic state
            int pointSize = 10;

            // For each character use a flyweight object
            foreach (char c in chars)
            {
                pointSize++;
                var character = factory.GetCharacter(c);
                character.Display(pointSize);
            }

            Console.WriteLine("Number of objects: {0}", factory.NumberOfObjects);
        }
    }
}
