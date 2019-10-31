using Computer.Helpers;
using Computer.Interfaces;
using Computer.LogicGates;

namespace Computer.Components
{
    /// <summary>
    /// A single unit of memory that stores one bit
    /// </summary>
    public class MemoryUnit : IWired
    {
        public Wire InputA { get; set; }
        public Wire Output { get; set; }
        public Wire SetWire { get; set; }
        public Wire EnableWire { get; set; }

        private NAND nand1, nand2, nand3, nand4;
        private AND enabler;

        //The logic for storing a bit - 4 nand gates
        public MemoryUnit()
        {
            InputA = new Wire();
            Output = new Wire();
            SetWire = new Wire();
            EnableWire = new Wire();

            nand1 = new NAND(InputA, SetWire);
            nand2 = new NAND(nand1.Output, SetWire);
            //Wire tempWire = new Wire();
            //tempWire.value = true;
            nand3 = new NAND(nand1.Output, nand4.Output);
            nand4 = new NAND(nand2.Output, nand3.Output);
            //tempWire = nand4.Output;

            //The enabler section for enabling outputing the value stored in the memory unit
            enabler = new AND(nand3.Output, EnableWire);

            //nand1.InputA = InputA;
            //nand1.InputB = SetWire;

            //nand2.InputB = nand1.Output;
            //nand2.InputA = SetWire;

            //nand3.InputA = nand1.Output;
            //nand3.InputB = nand4.Output;

            //nand4.InputB = nand2.Output;
            //nand4.InputA = nand3.Output;

            Output = enabler.Output;
        }
    }
}