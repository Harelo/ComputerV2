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

            InputA.WireUpdateEvent += (n) =>
            {
                if (n || InputB.value)
                    Output.value = true;
                else Output.value = false;
            };
        }
    }
}
