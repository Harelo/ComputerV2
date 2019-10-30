using Computer.Helpers;
using Computer.Interfaces;

namespace Computer.LogicGates
{
    /// <summary>
    /// A gate which outputs true when either input is off
    /// </summary>
    public class NOR : IWired
    {
        public Wire InputA { get; set; }
        public Wire InputB { get; set; }
        public Wire Output { get; set; }

        public NOR()
        {
            InputA = new Wire();
            InputB = new Wire();
            Output = new Wire();

            Output.value = true;
            InputA.WireUpdateEvent += CheckInputs;
            InputB.WireUpdateEvent += CheckInputs;
        }

        /// <summary>
        /// Check inputs when any input changes and update output accordingly
        /// </summary>
        /// <param name="n"></param>
        private void CheckInputs(bool n) => Output.value = !(InputA.value | InputB.value);
    }
}
