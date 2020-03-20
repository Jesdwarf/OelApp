using System;

namespace OelApp
{
    [Serializable]
    public class Session
    {
        public double NumberOfUnits { get; set; }

        public DateTime StartTime { get; set; }
        public Person Person { get; set; }
    }
}