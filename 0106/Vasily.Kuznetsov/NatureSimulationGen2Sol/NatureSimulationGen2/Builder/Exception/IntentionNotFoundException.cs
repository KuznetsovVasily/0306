using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureSimulationGen2.BuilderRecorder.Exception
{
    public class IntentionNotFoundException : System.Exception
    {
        public IntentionNotFoundException(string message)
            : base(message)
        {
        }
    }
}