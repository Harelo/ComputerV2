using System;
using System.Collections.Generic;
using System.Text;

namespace Computer.Helpers
{
    public abstract class Wired
    {
        protected Wire input, output;

        public Wired()
        {
            input = new Wire();
            output = new Wire();
        }
    }
}
