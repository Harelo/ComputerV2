using Computer.Helpers;
using Computer.Interfaces;

namespace Computer.LogicGates
{
    /// <summary>
    /// A gate which outputs true when either input is off
    /// </summary>
    public class NOR : IWired
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
                    inputB.WireUpdateEvent += CheckInputs;
                    if (inputA != null)
                        CheckInputs(false);
                }
            }
        }

        public Wire Output { get; set; }

        public NOR(Wire newInputA, Wire newInputB)
        {
            Output = new Wire();
            InputA = newInputA;
            InputB = newInputB;
        }

        /// <summary>
        /// Check inputs when any input changes and update output accordingly
        /// </summary>
        /// <param name="n"></param>
        private void CheckInputs(bool n) => Output.value = !(InputA.value | InputB.value);
    }
}
