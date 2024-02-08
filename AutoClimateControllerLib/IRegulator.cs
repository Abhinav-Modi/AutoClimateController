using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClimateControllerLib
{
    public interface IRegulator
    {
        public void ChangeTemp(double newTemp);
        
    }
}
