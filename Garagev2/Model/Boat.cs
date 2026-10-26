using System;
using System.Collections.Generic;
using System.Text;

namespace Garagev2.Model
{
    internal record Boat : Vehicle
    {
        // Private fields: Length and speed of the boat
        private int _feet;
        private int _knots;

        // Properties
        public int Feet
        {
            get
            {
                return _feet;
            }
            set
            {
                _feet = value;
            }
        }

        public int Knots
        {
            get
            {
                return _knots;
            }
            set
            {
                _knots = value;
            }
        }

        // Constructor

        public Boat(string regNum, string color, int numWheels, int feet, int knots) : base(regNum, color, numWheels)
        {
            _feet = feet;
            _knots = knots;
        }

    }
}
