using Computer.Helpers;
using Computer.Interfaces;

namespace Computer.LogicGates
{
    public class AND : IWired
    {
        public Wire InputA { get; set; }
        public Wire Output { get; set; }
    }
}
