using Computer.Helpers;
using Computer.Interfaces;

namespace Computer.LogicGates
{
    /// <summary>
    /// A gate which outputs true when either input is on
    /// </summary>
    public class OR : IWired
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
                    inputA.WireUpdateEvent += CheckInputs;
                    if (inputB != null)
                        CheckInputs(false);
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
                    inputB.WireUpdateEvent += CheckInputs;
                    if (inputA != null)
                        CheckInputs(false);
                }
            }
        }

        public Wire Output { get; set; }

        public OR()
        {
            Output = new Wire();
            InputA = new Wire();
            InputB = new Wire();

            InputA.WireUpdateEvent += CheckInputs;
            InputB.WireUpdateEvent += CheckInputs;
        }

        /// <summary>
        /// Check inputs when any input changes and update output accordingly
        /// </summary>
        /// <param name="n"></param>
        private void CheckInputs(bool n) => Output.value = InputA.value | InputB.value;
    }
}
