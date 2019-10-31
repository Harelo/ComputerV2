using Computer.Helpers;
using Computer.Interfaces;

namespace Computer.LogicGates
{
    /// <summary>
    /// A gate which inverts its' input and outputs the result
    /// </summary>
    public class NOT : IWired
    {
        //Private field for the input
        private Wire inputA;
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
                        inputA.WireUpdateEvent += CheckInput;
                        CheckInput(inputA.value);
                    }
                }
            }
        }
        public Wire Output { get; set; }

        public NOT(Wire newInputA)
        {
            Output = new Wire();
            InputA = newInputA;
        }

        /// <summary>
        /// Check input when it changes and update output accordingly
        /// </summary>
        /// <param name="n"></param>
        private void CheckInput(bool n) => Output.value = !n;
    }
}
