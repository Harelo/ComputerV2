using Computer.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Computer.Interfaces
{
    public interface IWired
    {
        public Wire input { get; set; }
        public Wire output { get; set;  }
    }
}
