using NatureSimulationGen2.AquaAnimal;
using NatureSimulationGen2.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureSimulationGen2.Builder
{
    public class DolphinBuilder : AnimalBuilder, IEntityBuilder
    {
        public override Entity Build()
        {
            var dolphin = new Dolphin(this.x, this.y, this.gender);
            dolphin.SetHealth(this.health);
            dolphin.SetGender(this.gender);
            return dolphin;
        }
    }
}
