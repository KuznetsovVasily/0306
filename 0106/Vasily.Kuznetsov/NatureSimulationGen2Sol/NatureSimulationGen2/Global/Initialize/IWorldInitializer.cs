using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureSimulationGen2.Global.Initialize
{
    public interface IWorldInitializer
    {
        World InitializeWorld(World world, BuilderProvider builderProvider);
    }
}