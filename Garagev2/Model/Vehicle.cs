using System;
using System.Collections.Generic;
using System.Text;

namespace Garagev2.Model
{
    public abstract record Vehicle(string RegNum, string Color, int NumWheels);

}