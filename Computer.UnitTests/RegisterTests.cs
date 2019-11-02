using Computer.Components;
using Computer.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Computer.UnitTests
{
    [TestClass]
    public class RegisterTests
    {
        [TestMethod]
        public void RegisterTester()
        {
            Register a = new Register(8);
            a.Input[0].value = true;
            a.Input[1].value = true;
            a.Input[5].value = true;
            Bus expected = new Bus(8);
            expected[0].value = true;
            expected[1].value = true;
            expected[5].value = true;
            a.SetWire.value = true;
            a.EnableWire.value = true;
            Assert.IsTrue(a.Output[0].value);
            Assert.IsTrue(a.Output[1].value);
            Assert.IsTrue(a.Output[5].value);

            a.EnableWire.value = true;
        }
    }
}
