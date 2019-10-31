using Computer.Helpers;
using Computer.Interfaces;

namespace Computer.LogicGates
{
    /// <summary>
    /// A gate with two inputs and an output. Only when both inputs are on the output is on
    /// </summary>
    public class AND : IWired
    {
        //Private fields for the two inputs
        private Wire inputA, inputB;

        //Logic for handling input wire-changes (not value changes)
        public Wire InputA
        {
            get => inputA;
            set
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
            set
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

        public AND()
        {
            Output = new Wire();
            InputA = new Wire();
            InputB = new Wire();
        }

        /// <summary>
        /// Update output according to inputs
        /// </summary>
        /// <param name="n"></param>
        private void CheckInputs(bool n) => Output.value = InputA.value & InputB.value;
    }
}
