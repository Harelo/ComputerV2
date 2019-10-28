namespace Computer.Helpers
{
    /// <summary>
    /// A class that represents a bus - a group of wires
    /// </summary>
    public class Bus
    {
        /// <summary>
        /// The value of the bus
        /// </summary>
        private Wire[] wires;

        /// <summary>
        /// An indexer for a specific bit in the bus
        /// </summary>
        /// <param name="i">The bit's index</param>
        /// <returns></returns>
        public bool this[int i]
        {
            get => wires[i].value;
            set
            {
                wires[i].value = value;
                BusUpdateEvent?.Invoke(wires);
            }
        }

        /// <summary>
        /// Initalization of the boolean array
        /// </summary>
        /// <param name="bitAmount"></param>
        public Bus(int amount)
        {
            wires = new Wire[amount];
            for (int i = 0; i < amount; i++)
                wires[i].value = false;
        }

        //Event for updating the bus value for listeners
        public delegate void BusUpdateHandler(Wire[] newValue);
        public event BusUpdateHandler BusUpdateEvent;
    }
}
