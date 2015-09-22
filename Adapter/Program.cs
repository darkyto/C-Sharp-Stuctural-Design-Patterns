﻿namespace Adapter
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            ICompound water = new RichCompound("Water");
            water.Display();

            ICompound benzene = new RichCompound("Benzene");
            benzene.Display();

            ICompound ethanol = new RichCompound("Ethanol");
            ethanol.Display();
        }
    }
}
