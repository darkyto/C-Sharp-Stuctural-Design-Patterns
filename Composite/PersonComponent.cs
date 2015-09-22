namespace Composite
{
    using System;
    using System.Collections.Generic;

    public abstract class PersonComponent
    {
        protected PersonComponent(string name)
        {
            this.Name = name;
        }

        protected string Name { get; private set; }

        public abstract void Add(PersonComponent person);

        public abstract void Remove(PersonComponent person);

        public abstract void Display(int depth);
    }
}
