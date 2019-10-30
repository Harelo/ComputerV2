using Computer.Helpers;
using Computer.Interfaces;

namespace Computer.LogicGates
{
    /// <summary>
    /// A gate which outputs true when either input is on
    /// </summary>
    public class OR : IWired
    {
        public Wire InputA { get; set; }
        public Wire InputB { get; set; }
        public Wire Output { get; set; }

        public OR()
        {
            InputA = new Wire();
            InputB = new Wire();
            Output = new Wire();

            InputA.WireUpdateEvent += CheckInputs;
            InputB.WireUpdateEvent += CheckInputs;
        }

        /// <summary>
        /// Check inputs when any input changes and update output accordingly
        /// </summary>
        /// <param name="n"></param>
        private void CheckInputs(bool n)
        {
            if (InputA.value || InputB.value)
                Output.value = true;
            else Output.value = false;
        }
    }
}
