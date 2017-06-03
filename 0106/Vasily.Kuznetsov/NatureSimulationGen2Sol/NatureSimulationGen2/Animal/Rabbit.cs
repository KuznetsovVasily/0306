using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NatureSimulationGen2.Global;
using NatureSimulationGen2.Plant;

namespace NatureSimulationGen2.Animal
{
    public class Rabbit : Animal, IGroundCreature
    {
        protected static int RandomDelta { get; set; }
        protected int Timer { get; set; }
        public Rabbit(int x, int y, Gender gender)
            :base(x, y, gender)
        {
        }
       
        public override List<SurfaceType> GetSurface()
        {
            return new List<SurfaceType> { Global.SurfaceType.Ground };
        }

        protected override int GetSpeed()
        {
            return 1;
        }

        protected override int GetHealth()
        {
            return 3;
        }

        protected override bool GetEdibility()
        {
            return true;
        }

        protected override int GetPregnantTimer()
        {
            return 0;
        }

        protected override bool GetIsVegan()
        {
            return true;
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public override Intention RequestIntention(World world)
        {
            Health--;

            var objectsAtTheSamePoint = world.GetObjectsAt(X, Y).Where(e => !e.Equals(this));
            if (Timer % 3 == 0 && objectsAtTheSamePoint is Plant.Plant)
            {
                if (objectsAtTheSamePoint.Any(e => ((Plant.Plant)e).IsFoodForVegan = true))
                {
                    Timer++;
                    Health++;
                    return new Intention { DeltaX = 0, DeltaY = 0 };
                }
            }
            RandomDelta = RandomHolder.GetInstance().Random.Next(-1, 2);
            while (RandomDelta == 0)
            {
                RandomDelta = RandomHolder.GetInstance().Random.Next(-1, 2);
            }

            var rand = RandomHolder.GetInstance().Random.Next(2);
            if (rand == 0)
            {
                return new Intention { DeltaX = 0, DeltaY = (RandomDelta * Speed) };
            }
            return new Intention { DeltaX = (RandomDelta * Speed), DeltaY = 0 };
        }
    }
}