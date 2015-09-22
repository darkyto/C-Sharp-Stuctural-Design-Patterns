namespace Composite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Commander : PersonComponent
    {
        private ICollection<PersonComponent> subjects;

        public Commander(string name)
            : base(name)
        {
            this.subjects = new List<PersonComponent>();
        }

        public override void Add(PersonComponent person)
        {
            this.subjects.Add(person);
        }

        public override void Remove(PersonComponent person)
        {
            this.subjects.Remove(person);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('=', depth) + this.Name);

            foreach (var person in this.subjects)
            {
                person.Display(depth + 4);
            }
        }
    }
}
