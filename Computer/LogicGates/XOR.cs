using Computer.Helpers;
using Computer.Interfaces;

namespace Computer.LogicGates
{
    /// <summary>
    /// A gate of which the output is only when one of the inputs is on but not both
    /// </summary>
    public class XOR : IWired
    {
        public Wire InputA { get; set; }
        public Wire InputB { get; set; }
        public Wire Output { get; set; }

        public XOR()
        {
            InputA = new Wire();
            InputB = new Wire();
            Output = new Wire();

            InputA.WireUpdateEvent += CheckInputs;
            InputB.WireUpdateEvent += CheckInputs;
        }

        private void CheckInputs(bool n) => Output.value = InputA.value ^ InputB.value;
    }
}
