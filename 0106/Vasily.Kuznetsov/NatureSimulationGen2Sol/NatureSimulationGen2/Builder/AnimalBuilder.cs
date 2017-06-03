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
        public int x;
        public int y;
        public Gender gender;
        public bool isEatable;
        public bool isVegan;
        public int pregnantTimer = 0;
        private int speed = 1;
        public int health = 3;

        public abstract Entity Build();
        
        public AnimalBuilder SetCoordinates(int x, int y, World world)
        {
            this.x = x;
            this.x = RandomHolder.GetInstance().Random.Next(1, world.XWorldMax - 1);
            this.y = y;
            this.y = RandomHolder.GetInstance().Random.Next(1, world.XWorldMax - 1);
            return this;
        }
        public AnimalBuilder SetGender(Gender gender)
        {
            this.gender = gender;
            return this;
        }
        public AnimalBuilder SetHealth(int health)
        {
            this.health = health;
            return this;
        }
    }
}