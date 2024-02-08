using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClimateControllerLib
{
    public class TempSensor : ISensor
    {
        public int GetValue()
        {
            // Logic to get the outside temperature
            return 22; // Example value
        }
    }
}
