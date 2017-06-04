using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using NatureSimulationGen2.Global;

namespace NatureSimulationGen2.AquaAnimal
{
    public class Dolphin : Animal.Animal
    {
        protected static int RandomDelta { get; set; }
        protected int Timer { get; set; }
        public Dolphin(int x, int y, Gender gender)
            : base(x, y, gender)
        {
        }

        public override List<SurfaceType> GetSurface()
        {
            return new List<SurfaceType>() { Global.SurfaceType.Water };
        }

        protected override int GetSpeed()
        {
            return 1;
        }

        protected override int GetHealth()
        {
            return 5;
        }

        protected override bool GetEdibility()
        {
            return false;
        }

        protected override int GetPregnantTimer()
        {
            return 0;
        }

        protected override bool GetIsVegan()
        {
            return true;
        }

        protected override Gender GetGender()
        {
            return this.Gender;
        }

        public void SetHealth(int health)
        {
            this.Health = health;
        }

        public void SetGender(Gender gender)
        {
            this.Gender = gender;
        }

        public override Intention RequestIntention(World world)
        {
            Health--;

            var partner = world.EntityList.OfType<Animal.Animal>().FirstOrDefault(x => x.GetType().Equals(this.GetType()) && x.Gender != Gender);
            var objectsAtTheSamePoint = world.GetObjectsAt(X, Y).Where(e => !e.Equals(this));
            if (Timer % 2 == 0)
            {
                if (objectsAtTheSamePoint.Any(e => e.GetType() == typeof(Dolphin) && (Gender != ((Dolphin)e).Gender)))
                {
                    Timer++;
                    if (Gender == Gender.Female && PregnantTimer > 0)
                    {
                        PregnantTimer++;
                        if (PregnantTimer == 4)
                        {
                            Random randomForGender = new Random();
                            if (randomForGender.Next(2) == 1)
                            {
                                Dolphin dolphinMale = new Dolphin(X, Y, Gender.Female);
                                world.AddEntity(dolphinMale);
                            }
                            Dolphin dolphinFemale = new Dolphin(X, Y, Gender.Male);
                            world.AddEntity(dolphinFemale);
                            PregnantTimer = 0;
                        }
                    }
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