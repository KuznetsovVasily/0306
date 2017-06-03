using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureSimulationGen2.Builder.Exception
{
    public class BuilderNotFoundException : System.Exception
    {
        public BuilderNotFoundException(string message)
            : base(message)
        {
        }
    }
}