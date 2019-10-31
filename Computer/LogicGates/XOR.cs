using Computer.Helpers;
using Computer.Interfaces;

namespace Computer.LogicGates
{
    /// <summary>
    /// A gate of which the output is only on when one of the inputs is on but not both
    /// </summary>
    public class XOR : IWired
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

        public XOR(Wire newInputA, Wire newInputB)
        {
            Output = new Wire();
            InputA = newInputA;
            InputB = newInputB;
        }

        private void CheckInputs(bool n) => Output.value = InputA.value ^ InputB.value;
    }
}
