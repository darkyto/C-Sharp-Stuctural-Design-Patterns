namespace Composite_Another
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Composite : Component
    {
        private ArrayList children = new ArrayList();

        // Constructor
        public Composite(string name)
            : base(name)
        {
        }

        public override void Add(Component component)
        {
            this.children.Add(component);
        }

        public override void Remove(Component component)
        {
            this.children.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + this.Name);

            // Recursively display child nodes
            foreach (Component component in this.children)
            {
                component.Display(depth + 2);
            }
        }
    }
}
