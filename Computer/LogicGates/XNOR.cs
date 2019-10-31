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
        //Private fields for the two inputs
        private Wire inputA, inputB;

        //Logic for handling input wire-changes (not value changes)
        public Wire InputA
        {
            get => inputA;
            private set
            {
                if (value != inputA)
                {
                    inputA = value;
                    if (value != null)
                    {
                        inputA.WireUpdateEvent += CheckInputs;
                        if (inputB != null)
                            CheckInputs(false);
                    }
                }
            }
        }

        public Wire InputB
        {
            get => inputB;
            private set
            {
                if (value != inputB)
                {
                    inputB = value;
                    if (value != null)
                    {
                        inputB.WireUpdateEvent += CheckInputs;
                        if (inputA != null)
                            CheckInputs(false);
                    }
                }
            }
        }

        public Wire Output { get; set; }

        public XNOR(Wire newInputA, Wire newInputB)
        {
            Output = new Wire();
            InputA = newInputA;
            InputB = newInputB;
        }

        private void CheckInputs(bool n) => Output.value = !(InputA.value ^ InputB.value);
    }
}
