using Microsoft.VisualStudio.TestTools.UnitTesting;
using Computer.LogicGates;

namespace Computer.UnitTests
{
    [TestClass]
    public class LogicGateTests
    {
        [TestMethod]
        public void NOTClass_InputChange_OutputInverted()
        {
            // Arrange
            NOT notGate = new NOT();

            // Act
            notGate.InputA.value = true;

            // Assert
            Assert.IsFalse(notGate.Output.value);
        }

        [TestMethod]
        public void AND_InputsChanged_OutputUpdateCorrectly()
        {
            //When both inputs are off output should be off
            AND andGate = new AND();
            Assert.IsFalse(andGate.Output.value);

            //When InputA only is on output should be off
            andGate.InputA.value = true;
            Assert.IsFalse(andGate.Output.value);

            //When both inputs are on output should be on
            andGate.InputB.value = true;
            Assert.IsTrue(andGate.Output.value);

            //When InputB only is on output should be off
            andGate.InputA.value = false;
            Assert.IsFalse(andGate.Output.value);

            //When both inputs are off again output should remain off
            andGate.InputB.value = false;
            Assert.IsFalse(andGate.Output.value);
        }

        [TestMethod]
        public void OR_InputChanged_OutputUpdatesCorrectly()
        {
            //When both inputs are off output should be off
            OR orGate = new OR();
            Assert.IsFalse(orGate.Output.value);

            //When InputA only is on output should be on
            orGate.InputA.value = true;
            Assert.IsTrue(orGate.Output.value);

            //When both inputs are on output should be on
            orGate.InputB.value = true;
            Assert.IsTrue(orGate.Output.value);

            //When InputB only is on output should be on
            orGate.InputA.value = false;
            Assert.IsTrue(orGate.Output.value);

            //When both inputs are off again output should be off
            orGate.InputB.value = false;
            Assert.IsFalse(orGate.Output.value);
        }

        [TestMethod]
        public void XOR_InputChanged_OutputUpdatesCorrectly()
        {
            //When both inputs are off output should be off
            XOR xorGate = new XOR();
            Assert.IsFalse(xorGate.Output.value);

            //When InputA only is on output should be on
            xorGate.InputA.value = true;
            Assert.IsTrue(xorGate.Output.value);

            //When both inputs are on output should be off
            xorGate.InputB.value = true;
            Assert.IsFalse(xorGate.Output.value);

            //When InputB only is on output should be on
            xorGate.InputA.value = false;
            Assert.IsTrue(xorGate.Output.value);

            //When both inputs are off again output should be off
            xorGate.InputB.value = false;
            Assert.IsFalse(xorGate.Output.value);
        }


        [TestMethod]
        public void NAND_InputsChanged_OutputUpdateCorrectly()
        {
            //When both inputs are off output should be on
            NAND nandGate = new NAND();
            Assert.IsTrue(nandGate.Output.value);

            //When InputA only is on output should be on
            nandGate.InputA.value = true;
            Assert.IsTrue(nandGate.Output.value);

            //When both inputs are on output should be off
            nandGate.InputB.value = true;
            Assert.IsFalse(nandGate.Output.value);

            //When InputB only is on output should be on
            nandGate.InputA.value = false;
            Assert.IsTrue(nandGate.Output.value);

            //When both inputs are off again output should be on
            nandGate.InputB.value = false;
            Assert.IsTrue(nandGate.Output.value);
        }

        [TestMethod]
        public void NOR_InputChanged_OutputUpdatesCorrectly()
        {
            //When both inputs are off output should be on
            NOR norGate = new NOR();
            Assert.IsTrue(norGate.Output.value);

            //Any other option - output is off

            norGate.InputA.value = true;
            Assert.IsFalse(norGate.Output.value);

            norGate.InputB.value = true;
            Assert.IsFalse(norGate.Output.value);

            norGate.InputA.value = false;
            Assert.IsFalse(norGate.Output.value);

            //When both inputs are off again output should be on again
            norGate.InputB.value = false;
            Assert.IsTrue(norGate.Output.value);
        }

        [TestMethod]
        public void XNOR_InputChanged_OutputUpdatesCorrectly()
        {
            //When both inputs are off output should be on
            XNOR xnorGate = new XNOR();
            Assert.IsTrue(xnorGate.Output.value);

            //When InputA only is on output should be off
            xnorGate.InputA.value = true;
            Assert.IsFalse(xnorGate.Output.value);

            //When both inputs are on output should be on
            xnorGate.InputB.value = true;
            Assert.IsTrue(xnorGate.Output.value);

            //When InputB only is on output should be off
            xnorGate.InputA.value = false;
            Assert.IsFalse(xnorGate.Output.value);

            //When both inputs are off again output should be on
            xnorGate.InputB.value = false;
            Assert.IsTrue(xnorGate.Output.value);
        }
    }
}
