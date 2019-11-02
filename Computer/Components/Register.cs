using Computer.Helpers;
using Computer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Computer.Components
{
    public class Register : IBussed
    {
        private List<MemoryUnit> units;
        public Wire EnableWire { get; set; }
        public Wire SetWire { get; set; }
        public Bus Input { get; set; }
        public Bus Output { get; set; }

        public Register(int bitAmount)
        {
            EnableWire = new Wire();
            SetWire = new Wire();
            Input = new Bus(bitAmount);
            Output = new Bus(bitAmount);
            units = new List<MemoryUnit>();

            for (int i = 0; i < bitAmount; i++)
            {
                units.Add(new MemoryUnit());
                Output[i] = units[i].Output;
                Input[i] = units[i].InputA;
            }

            EnableWire.WireUpdateEvent += (n) =>
            {
                foreach (MemoryUnit u in units)
                    u.EnableWire.value = n;
            };

            SetWire.WireUpdateEvent += (n) =>
            {
                foreach (MemoryUnit u in units)
                    u.SetWire.value = n;
            };
        }
    }
}
