using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NatureSimulationGen2.Global;


namespace NatureSimulationGen2.Builder
{
    public abstract class AnimalBuilder : IEntityBuilder
    {
        protected int x;
        protected int y;
        protected Gender gender;
        protected bool isEatable;
        protected bool isVegan;
        protected int pregnantTimer = 0;
        protected int speed = 1;
        protected int health = 3;
        public abstract Entity Build();
        public virtual AnimalBuilder SetCoordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
            return this;
        }
        public virtual AnimalBuilder SetGender(Gender gender)
        {
            this.gender = gender;
            return this;
        }
        public virtual AnimalBuilder SetHealth(int health)
        {
            this.health = health;
            return this;
        }
    }
}