using Computer.Helpers;
using Computer.Interfaces;

namespace Computer.LogicGates
{
    /// <summary>
    /// A gate which inverts its' input and outputs the result
    /// </summary>
    public class NOT : IWired
    {
        public Wire InputA { get; set; }
        public Wire Output { get; set; }

        public NOT()
        {
            Output = new Wire();
            InputA = new Wire();

            //When input is off (by default) output should be on
            Output.value = true;

            //Event for changing the output when the input changes
            InputA.WireUpdateEvent += (n) => Output.value = !n;
        }
    }
}
