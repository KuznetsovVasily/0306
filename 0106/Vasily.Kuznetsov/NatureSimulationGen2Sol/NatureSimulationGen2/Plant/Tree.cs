using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NatureSimulationGen2.Animal;
using NatureSimulationGen2.Global;

namespace NatureSimulationGen2.Plant
{
    public class Tree : Plant
    {
        protected static int RandomDelta { get; set; }
        

        public Tree(int x, int y, bool isFoodForVegan = true, int health = 5)
            : base(x, y, health, isFoodForVegan)
        {
            IsFoodForVegan = true;
        }

        public override Intention RequestIntention(World world)
        {
            Health++;

            var objectsAtTheSamePoint = world.GetObjectsAt(X, Y).Where(e => !e.Equals(this));
            if ((objectsAtTheSamePoint as Animal.Animal).IsVegan)
            {
                Health -= 2;
                return new Intention { DeltaX = 0, DeltaY = 0 };
            }
            return new Intention {DeltaX = 0, DeltaY = 0};
        }

        public override List<SurfaceType> GetSurface()
        {
            return new List<SurfaceType> { Global.SurfaceType.Ground, Global.SurfaceType.Water };
        }

        public override bool GetBarrier()
        {
            return true;
        }
    }
}