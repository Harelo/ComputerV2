using Computer.Helpers;
using Computer.Interfaces;
using Computer.LogicGates;

namespace Computer.Components
{
    public class MemoryUnit : IWired
    {
        public Wire InputA { get; set; }
        public Wire Output { get; set; }
        public Wire SetWire { get; set; }
        public static NAND nand1, nand2, nand3, nand4;

        public MemoryUnit()
        {
            InputA = new Wire();
            Output = new Wire();
            SetWire = new Wire();
            nand1 = new NAND();
            nand2 = new NAND();
            nand3 = new NAND();
            nand4 = new NAND();

            nand1.InputA = InputA;
            nand1.InputB = SetWire;

            nand2.InputB = nand1.Output;
            nand2.InputA = SetWire;

            nand3.InputA = nand1.Output;
            nand3.InputB = nand4.Output;

            nand4.InputB = nand2.Output;
            nand4.InputA = nand3.Output;

            Output = nand3.Output;
        }
    }
}
