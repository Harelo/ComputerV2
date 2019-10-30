using Computer.Helpers;
using Computer.Interfaces;

namespace Computer.LogicGates
{
    /// <summary>
    /// A gate with two inputs and an output. Only when both inputs are on the output is on
    /// </summary>
    public class AND : IWired
    {
        public Wire InputA { get; set; }
        public Wire InputB { get; set; }
        public Wire Output { get; set; }

        public AND()
        {
            InputA = new Wire();
            InputB = new Wire();
            Output = new Wire();

            //Events for updating the output depending on the inputs

            InputA.WireUpdateEvent += CheckInputs;
            InputB.WireUpdateEvent += CheckInputs;
        }

        /// <summary>
        /// Update output according to inputs
        /// </summary>
        /// <param name="n"></param>
        private void CheckInputs(bool n)
        {
            if (InputB.value && InputA.value)
                Output.value = true;
            else Output.value = false;
        }
    }
}
