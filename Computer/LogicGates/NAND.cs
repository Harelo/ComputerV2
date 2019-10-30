using Computer.Helpers;
using Computer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Computer.LogicGates
{
    /// <summary>
    /// A gate which outputs on when both inputs are off and outputs off when either or both is on
    /// </summary>
    public class NAND : IWired
    {
        public Wire InputA { get; set; }
        public Wire InputB { get; set; }

        public Wire Output { get; set; }

        public NAND()
        {
            InputA = new Wire();
            InputB = new Wire();
            Output = new Wire();

            Output.value = true;
            InputA.WireUpdateEvent += CheckInputs;
            InputB.WireUpdateEvent += CheckInputs;
        }

        private void CheckInputs(bool n)
        {
            Console.WriteLine(InputA.value & InputB.value);
            Output.value = !(InputA.value & InputB.value);
        }
    }
}
