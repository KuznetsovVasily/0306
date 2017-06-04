using NatureSimulationGen2.Animal;
using NatureSimulationGen2.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureSimulationGen2.Builder
{
    public class RabbitBuilder : AnimalBuilder, IEntityBuilder
    {
        private int x;
        private int y;

        private bool predator = true;


        public override Entity Build()
        {
            var rabbit = new Rabbit(this.x, this.y, this.gender);
            rabbit.SetHealth(this.health);
            rabbit.SetGender(this.gender);
            return rabbit;
        }

        //public RabbitBuilder SetCoordinates(int x, int y)
        //{
        //    this.x = x;
        //    this.y = y;

        //    return this;
        //}


    }
}
