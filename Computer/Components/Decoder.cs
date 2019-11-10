using Computer.Helpers;
using Computer.Interfaces;
using Computer.LogicGates;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Computer.Components
{
    public class Decoder : IBussed
    {
        /// <summary>
        /// The input bus of the decoder
        /// </summary>
        public Bus Input { get; set; }

        /// <summary>
        /// The output bus of the decoder
        /// </summary>
        public Bus Output { get; set; }

        /// <summary>
        /// A list of NOT gates used for the decoder's logic
        /// </summary>
        public List<NOT> notGates;

        /// <summary>
        /// A list of MultiAND gates used for the decoder's logic
        /// </summary>
        public List<MultiAND> multies;


        /// <summary>
        /// A constructor to the decoder
        /// </summary>
        /// <param name="inputAmount">The amount of input wires the decoder has</param>
        public Decoder(int inputAmount)
        {
            //The amount of input wires the decoder has is determined by "inputAmount" parameter
            Input = new Bus(inputAmount);

            //The amount of output wires the decoder has is 2 to the power of inputAmount
            //For example if there are 8 input wires there would be 2^8 = 256 output wires
            Output = new Bus((int)Math.Pow(2, inputAmount));

            //Initalize the MultiAND and NOT gates lists
            multies = new List<MultiAND>();
            notGates = new List<NOT>();

            //Add a NOT gate for each input of the decoder
            for (int i = 0; i < inputAmount; i++)
            {
                notGates.Add(new NOT());
                notGates[i].InputA = Input[i];
            }

            //A BitArray used for binary counting
            BitArray binaryCounter;

            //Count all the binary numbers from 0 to Output.Count 
            for (int i = 0; i < Output.Count; i++)
            {
                //Add a MultiAND gate for each possible combination of wires coming both straight from 
                //the inputs or from the NOT gates
                //Basically, add a MultiAND for each binary number that the inputs may create so that
                // there would an output to them
                //For example if there are 8 inputs there would be 256 outputs meaning 256 MultiANDs
                multies.Add(new MultiAND(inputAmount));

                //Set the binary counter to be i (converted into BitArray automatically)
                binaryCounter = new BitArray(new[] { i });

                //Runs for each input wire
                for (int j = 0; j < inputAmount; j++)
                {
                    //This for loop basically sets all the possible combinations of
                    //input wires and input wires coming through NOT gates that there
                    //can be and correctly connectes to them to the approperiate MultiAND 
                    //that is then connected to the output of the decoder
                    if (!binaryCounter[j])
                        multies[i].Inputs[j] = notGates[j].Output;

                    else multies[i].Inputs[j] = Input[j];
                }

                //Connect each MultiAND to a different output wire of the decoder
                Output[i] = multies[i].Output;
            }
        }
    }
}
