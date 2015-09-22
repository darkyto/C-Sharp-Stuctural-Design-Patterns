namespace Composite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Person : PersonComponent
    {
        public Person(string name)
            : base(name)
        {     
        }

        public override void Add(PersonComponent person)
        {
            Console.WriteLine("Cannot add to a person");
        }

        public override void Remove(PersonComponent person)
        {
            Console.WriteLine("Cannot remove to a person");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + this.Name);
        }
    }
}
