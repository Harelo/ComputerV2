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
        /// An indexer for a specific wire in the bus
        /// </summary>
        /// <param name="i">The wire's index</param>
        /// <returns></returns>
        public Wire this[int i]
        {
            get => wires[i];
            set
            {
                wires[i] = value;
                BusUpdateEvent?.Invoke(wires, i);
            }
        }

        public int Count
        {
            get => wires.Length;
        }

        /// <summary>
        /// Initalization of the boolean array
        /// </summary>
        /// <param name="bitAmount"></param>
        public Bus(int amount)
        {
            wires = new Wire[amount];
            for (int i = 0; i < amount; i++)
            {
                wires[i] = new Wire();
                wires[i].value = false;
            }
        }

        //Event for updating the bus value for listeners
        public delegate void BusUpdateHandler(Wire[] newValue, int indexChanged);
        public event BusUpdateHandler BusUpdateEvent;
    }
}
