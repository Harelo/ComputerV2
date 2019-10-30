using Computer.Helpers;
using Computer.Interfaces;

namespace Computer.LogicGates
{
    public class NOT : IWired
    {
        public Wire InputA { get; set; }
        public Wire Output { get; set; }

        public NOT()
        {
            Output = new Wire();
            InputA = new Wire();
            Output.value = true;
            InputA.WireUpdateEvent += (n) => Output.value = !n;
        }
    }
}
