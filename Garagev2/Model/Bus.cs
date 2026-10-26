using System;
using System.Collections.Generic;
using System.Text;

namespace Garagev2.Model
{
    internal record Bus : Vehicle
    {
        // Private fields
        private int _numSeats;
        private decimal _length;

        // Properties (getters & setters)
        public int NumSeats
        {
            get
            {
                return _numSeats;
            }
            set
            {
                _numSeats = value;
            }
        }

        public decimal Length
        {
            get
            {
                return _length;
            }
            set
            {
                _length = value;
            }
        }

        // Constructor
        public Bus(string regNum, string color, int numWheels, int numSeats, decimal length) : base(regNum, color, numWheels)
        {
            _numSeats = numSeats;
            _length = length;
        }
    }
}
