using System;
using System.Collections.Generic;
using System.Text;

namespace Garagev2.Model
{
    internal record Airplane : Vehicle
    {

        private int _numEngines;

        public int NumEngines
        {
            get
            {
                return _numEngines;
            }
            set
            {
                _numEngines = value;
            }
        }

        
        public Airplane(string regNum, string color, int numWheels, int numEngines) : base(regNum, color, numWheels)
        {
            _numEngines = numEngines;
        }
    }
}
