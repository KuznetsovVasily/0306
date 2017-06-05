using System.Collections.Generic;
using NatureSimulationGen2.Global;

namespace NatureSimulationGen2.Barrier
{
    public class Mountain : Entity, IBarrier
    {
        public Mountain(int x, int y)
            : base(x, y)
        {
        }
        public override Intention RequestIntention(World world)
        {
            return new Intention { DeltaX = 0, DeltaY = 0 };
        }
        public override List<SurfaceType> GetSurfaces()
        {
            return new List<SurfaceType> { Global.SurfaceType.Ground, Global.SurfaceType.Water };
        }
        public override bool GetBarrier()
        {
            return true;
        }
    }
}
