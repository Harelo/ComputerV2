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

            InputA.WireUpdateEvent += (n) =>
            {
                if (InputB.value && n)
                    Output.value = true;
                else Output.value = false;
            };

            InputB.WireUpdateEvent += (n) =>
            {
                if (InputA.value && n)
                    Output.value = true;
                else Output.value = false;
            };
        }
    }
}
