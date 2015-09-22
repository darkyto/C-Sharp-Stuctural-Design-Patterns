namespace Decorator
{
    using System;
    using System.Collections.Generic;

    internal class Video : LibraryItem
    {
        private readonly string director;
        private readonly string title;
        private readonly int playtime;

        public Video(string director, string title, int playtime, int copiesCount)
        {
            this.director = director;
            this.title = title;
            this.playtime = playtime;
            this.CopiesCount = copiesCount;
        }

        public override void Display()
        {
            Console.WriteLine("Video ----- ");
            Console.WriteLine(" Director: {0}", this.director);
            Console.WriteLine(" Title: {0}", this.title);
            Console.WriteLine(" # Copies: {0}", this.CopiesCount);
            Console.WriteLine(" Playtime: {0}", this.playtime);
        }
    }
}
