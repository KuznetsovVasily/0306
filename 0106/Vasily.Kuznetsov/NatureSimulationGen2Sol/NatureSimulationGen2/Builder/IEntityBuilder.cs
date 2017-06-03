using NatureSimulationGen2.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureSimulationGen2.Builder
{
    public interface IEntityBuilder
    {
        Entity Build();
    }
}
