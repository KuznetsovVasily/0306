using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureSimulationGen2.BuilderRecorder.Exception
{
    public class BuilderAlreadyRegisteredException : System.Exception
    {
        public BuilderAlreadyRegisteredException(string message)
            : base(message)
        {
        }
    }
}