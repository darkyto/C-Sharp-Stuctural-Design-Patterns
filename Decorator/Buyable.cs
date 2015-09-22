namespace Decorator
{
    using System;
    using System.Collections.Generic;

    internal class Buyable : Decorator
    {
        private readonly decimal price;

        public Buyable(LibraryItem item, decimal price)
            : base(item)
        {
            this.price = price;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("Price: $" + this.price);
        }
    }
}
