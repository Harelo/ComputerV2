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
            set
            {
                if (value != inputA)
                {
                    inputA = value;
                    inputA.WireUpdateEvent += CheckInput;
                    CheckInput(inputA.value);
                }
            }
        }
        public Wire Output { get; set; }

        public NOT()
        {
            Output = new Wire();
            InputA = new Wire();
        }

        /// <summary>
        /// Check input when it changes and update output accordingly
        /// </summary>
        /// <param name="n"></param>
        private void CheckInput(bool n) => Output.value = !n;
    }
}
