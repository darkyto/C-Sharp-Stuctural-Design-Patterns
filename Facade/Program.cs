namespace Facade
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            var homeTheaterPro = HomeTheaterPro.CreateInstance();

            homeTheaterPro.InitHomeSystem();
            homeTheaterPro.Next();
            homeTheaterPro.Next();
            homeTheaterPro.Stop();
        }
    }
}
