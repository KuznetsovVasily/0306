using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NatureSimulationGen2.Global;

namespace NatureSimulationGen2.Barrier
{
    public class Rock : Mountain, IBarrier
    {
        public Rock(int x, int y)
            : base(x, y)
        {
        }
        public override List<SurfaceType> GetSurfaces()
        {
            return new List<SurfaceType> { Global.SurfaceType.Ground, Global.SurfaceType.Water };
        }
    }
}
