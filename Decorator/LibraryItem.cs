namespace Decorator
{
    using System;

    internal abstract class LibraryItem
    {
        public int CopiesCount { get; set; }

        public abstract void Display();
    }
}
