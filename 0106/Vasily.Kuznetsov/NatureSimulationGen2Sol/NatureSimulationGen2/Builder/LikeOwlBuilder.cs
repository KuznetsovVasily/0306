using NatureSimulationGen2.Animal;
using NatureSimulationGen2.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureSimulationGen2.Builder
{
    public class LikeOwlBuilder : AnimalBuilder, IEntityBuilder
    {
        private bool predator = true;
       

        public override Entity Build()
        {
            var owl = new Owl(this.x, this. y, Gender.Male, predator);
            owl.SetHealth(this.health);
            return owl;
        }
    }
}
