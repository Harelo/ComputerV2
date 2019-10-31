using System;
using System.Collections.Generic;
using System.Text;

namespace Computer.Helpers
{
    /// <summary>
    /// A class that represents a single wire
    /// </summary>
    public class Wire
    {
        /// <summary>
        /// The value of the wire - on or off
        /// </summary>
        private bool _value;

        /// <summary>
        /// A public getter and setter for the value of the wire
        /// </summary>
        public bool value
        {
            get => _value;
            set
            {
                if (value != _value)
                {
                    _value = value;
                    //Invoke the event for listeners if it isn't empty (null)
                    WireUpdateEvent?.Invoke(value);
                }
            }
        }

        /// <summary>
        /// Lazy instantiation for the value of the wire
        /// </summary>
        public Wire()
        {
            value = false;
        }

        //Event for updating the wire value for listeners
        public delegate void WireUpdateHandler(bool newValue);
        public event WireUpdateHandler WireUpdateEvent;
    }
}
