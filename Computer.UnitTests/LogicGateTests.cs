using Microsoft.VisualStudio.TestTools.UnitTesting;
using Computer.LogicGates;

namespace Computer.UnitTests
{
    [TestClass]
    public class LogicGateTests
    {
        //Testing the NOT gate class
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
    }
}
