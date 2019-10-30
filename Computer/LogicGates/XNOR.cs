using Computer.Helpers;
using Computer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Computer.LogicGates
{
    /// <summary>
    /// A gate of which the output is only on when both inputs are off or on but not just one of them
    /// </summary>
    public class XNOR : IWired
    {
        public Wire InputA { get; set; }
        public Wire InputB { get; set; }
        public Wire Output { get; set; }

        public XNOR()
        {
            InputA = new Wire();
            InputB = new Wire();
            Output = new Wire();

            Output.value = true;

            InputA.WireUpdateEvent += CheckInputs;
            InputB.WireUpdateEvent += CheckInputs;
        }

        private void CheckInputs(bool n) => Output.value = !(InputA.value ^ InputB.value);
    }
}
