using NatureSimulationGen2.Animal;
using NatureSimulationGen2.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureSimulationGen2.Global.Initialize
{
    public class OwlBuilder : IEntityBuilder
    {
        private int x;
        private int y;
        private Gender gender;
        private int health = 5;
        private bool predator = true;

        public Entity Build()
        {
            var owl = new Owl(this.x, this.y, Gender.Male, predator);
            owl.SetHealth(this.health);
            return owl;
        }
        public OwlBuilder SetCoordinates(int x, int y)
        {
            this.x = x;
            this.y = y;

            return this;
        }
        public OwlBuilder SetGender(Gender gender)
        {
            this.gender = gender;
            return this;
        }
        public OwlBuilder SetHealth(int health)
        {
            this.health = health;
            return this;
        }
    }
}