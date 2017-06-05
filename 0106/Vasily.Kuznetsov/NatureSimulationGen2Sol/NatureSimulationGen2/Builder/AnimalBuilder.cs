using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NatureSimulationGen2.Builder;
using NatureSimulationGen2.Global;


namespace NatureSimulationGen2.BuilderRecorder
{
    public abstract class AnimalBuilder : IEntityBuilder
    {
        protected int X;
        protected int Y;
        protected Gender Gender;
        protected bool IsEatable;
        protected bool IsVegan;
        protected int PregnantTimer = 0;
        protected int Speed = 1;
        protected int Health = 3;
        public abstract Entity Build();
        public virtual AnimalBuilder SetCoordinates(int x, int y)
        {
            X = x;
            Y = y;
            return this;
        }
        //review: зачем virtual? И можно сделать это свойством
        public virtual AnimalBuilder SetGender(Gender gender)
        {
            Gender = gender;
            return this;
        }
        public virtual AnimalBuilder SetHealth(int health)
        {
            Health = health;
            return this;
        }
    }
}