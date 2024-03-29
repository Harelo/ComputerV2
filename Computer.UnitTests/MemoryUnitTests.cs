﻿using Computer.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Computer.UnitTests
{
    [TestClass]
    public class MemoryUnitTests
    {
        [TestMethod]
        public void MemoryUnitTester()
        {
            MemoryUnit m = new MemoryUnit();
            m.InputA.value = true;
            m.EnableWire.value = true;
            Assert.IsFalse(m.Output.value);
            m.SetWire.value = true;
            Assert.IsTrue(m.Output.value);
            m.SetWire.value = false;
            m.InputA.value = false;
            Assert.IsTrue(m.Output.value);
            m.SetWire.value = true;
            Assert.IsFalse(m.Output.value);
            m.SetWire.value = false;
            m.InputA.value = true;
            Assert.IsFalse(m.Output.value);
            m.SetWire.value = true;
            Assert.IsTrue(m.Output.value);
        }
    }
}
