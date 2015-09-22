namespace Composite_Another
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Component
    {
        public Component(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public abstract void Add(Component c);

        public abstract void Remove(Component c);

        public abstract void Display(int depth);
    }
}
