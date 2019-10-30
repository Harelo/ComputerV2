using Computer.Helpers;
using Computer.Interfaces;

namespace Computer.LogicGates
{
    public class NOT : IWired
    {
        public Wire Input { get; set; }
        public Wire Output { get; set; }

        public NOT()
        {
            Output = new Wire();
            Input = new Wire();
            Output.value = true;
            Input.WireUpdateEvent += (n) => Output.value = !n;
        }
    }
}
