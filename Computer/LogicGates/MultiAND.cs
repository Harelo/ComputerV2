using Computer.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Computer.LogicGates
{
    /// <summary>
    /// Like an AND gate, but with any number of inputs
    /// </summary>
    public class MultiAND
    {
        /// <summary>
        /// Output wire
        /// </summary>
        public Wire Output { get; set; }

        /// <summary>
        /// Private field for the input bus
        /// </summary>
        private Bus inputs;
        /// <summary>
        /// Public getter and setter for the input bus
        /// </summary>
        public Bus Inputs
        {
            get => inputs;
            set
            {
                //Clear previous inputs bus' bus update event
                if (inputs != null)
                    inputs.BusUpdateEvent -= CheckInputs;

                //Add bus update event handler to the new bus
                value.BusUpdateEvent += CheckInputs;

                //Default output value is true
                bool output = true;

                //Go over each wire in the bus
                for (int i = 0; i < value.Count; i++)
                    //AND the output with each wire's value in the bus
                    output &= value[i].value;

                //Set the inputs bus to the new value
                inputs = value;

                //Set the output value to the new output
                Output.value = output;
            }
        }


        /// <summary>
        /// Public constructor for the MultiAND gate
        /// </summary>
        /// <param name="bitAmount">Amount of bits in the input bus</param>
        public MultiAND(int bitAmount)
        {
            Output = new Wire();
            Inputs = new Bus(bitAmount);

            //Set a bus event handler for the inputs bus
            Inputs.BusUpdateEvent += CheckInputs;
        }

        /// <summary>
        /// Update output according to inputs
        /// </summary>
        /// <param name="n"></param>
        private void CheckInputs(Wire[] newValue, int indexChanged)
        {
            bool output = true;
            for (int i = 0; i < Inputs.Count; i++)
                output &= newValue[i].value;

            Output.value = output;
        }
    }
}
