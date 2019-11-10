using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using Computer.Components;

namespace Computer.UnitTests
{
    [TestClass]
    public class DecoderTests
    {
        [TestMethod]
        public void DecoderTesting()
        {
            //Create new 8x256 decoder
            Components.Decoder decoder = new Components.Decoder(8);
            //Change 3rd input to true (00000100 is the bus value)
            decoder.Input[2].value = true;

            //Assert that the decoder is indeed 8x256
            Assert.IsTrue(decoder.Input.Count == 8);
            Assert.IsTrue(decoder.Output.Count == 256);

            //Assert that the NOT gate for the 3rd input is false meaning that it updated correctly
            Assert.IsFalse(decoder.notGates[2].Output.value);

            //Assert that all inputs of the 5th (00000100) multiAND are on
            for (int i = 0; i < decoder.multies[4].Inputs.Count; i++)
                Assert.IsTrue(decoder.multies[4].Inputs[i].value);

            //Assert that the output of the 5th multiAND is on
            Assert.IsTrue(decoder.multies[4].Output.value);

            //Assert that the 5th output wire of the decoder is on
            Assert.IsTrue(decoder.Output[4].value);

            //Set the 4th input to true (00001100 is now the bus value)
            decoder.Input[3].value = true;

            //Assert that the 5th output wire of the decoder is no longer on
            Assert.IsFalse(decoder.Output[4].value);

            //Assert that all inputs of the 13th (00001100) multiAND are on
            for (int i = 0; i < decoder.multies[12].Inputs.Count; i++)
                Assert.IsTrue(decoder.multies[12].Inputs[i].value);

            //Assert that the 13th wire of the decoder's output is on
            Assert.IsTrue(decoder.Output[12].value);
        }
    }
}
