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
            notGate.Input.value = true;

            // Assert
            Assert.IsFalse(notGate.Output.value);
        }
    }
}
