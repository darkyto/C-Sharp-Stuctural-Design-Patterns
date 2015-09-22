namespace Adapter
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The 'ConcreteAdapter' class
    /// </summary>
    public class RichCompound : ICompound
    {
        private readonly string chemical;

        private readonly float boilingPoint;
        private readonly float meltingPoint;
        private readonly double molecularWeight;
        private readonly string molecularFormula;

        public RichCompound(string chemical)
        {
            this.chemical = chemical;
            var bank = new CompoundDatabank();

            this.boilingPoint = bank.GetCriticalPoint(this.chemical, "B");
            this.meltingPoint = bank.GetCriticalPoint(this.chemical, "M");
            this.molecularWeight = bank.GetMolecularWeight(this.chemical);
            this.molecularFormula = bank.GetMolecularStructure(this.chemical);
        }

        public void Display()
        {
            Console.WriteLine("Compound: {0} ------ ", this.chemical);
            Console.WriteLine(" Formula: {0}", this.molecularFormula);
            Console.WriteLine(" Weight : {0}", this.molecularWeight);
            Console.WriteLine(" Melting Pt: {0}", this.meltingPoint);
            Console.WriteLine(" Boiling Pt: {0}", this.boilingPoint);
            Console.WriteLine();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("Compound: {0} ------ ", this.chemical);
            sb.AppendFormat(" Formula: {0}", this.molecularFormula);
            sb.AppendFormat(" Weight : {0}", this.molecularWeight);
            sb.AppendFormat(" Melting Pt: {0}", this.meltingPoint);
            sb.AppendFormat(" Boiling Pt: {0}", this.boilingPoint);

            return sb.ToString();
        }
    }
}
