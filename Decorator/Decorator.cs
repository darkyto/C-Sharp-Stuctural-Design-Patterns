namespace Decorator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal abstract class Decorator : LibraryItem
    {
        protected Decorator(LibraryItem libraryItem)
        {
            this.LibraryItem = libraryItem;
        }

        protected LibraryItem LibraryItem { get; set; }

        public override void Display()
        {
            this.LibraryItem.Display();
        }
    }
}
