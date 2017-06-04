using NatureSimulationGen2.Animal;
using NatureSimulationGen2.AquaAnimal;
using NatureSimulationGen2.Barrier;
using NatureSimulationGen2.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureSimulationGen2.Global.Initialize
{
    class TestWorldInitializer : ManualInitializer
    {
        public World InitializeWorldz(World world, BuilderProvider builderProvider)
        {
            Rock rock = new Rock(1, 1);
            world.AddEntity(rock);
            Rabbit rabbizt = new Rabbit(2, 2, Gender.Male);
            world.AddEntity(rabbizt);
            Dolphin dolpz = new Dolphin(3, 3, Gender.Male);
            world.AddEntity(dolpz);
            var owlBuilder = ((LikeOwlBuilder)builderProvider.GetBuilder(typeof(Owl)))
                .SetCoordinates(RandomHolder.GetInstance().Random.Next(1, world.XWorldMax), RandomHolder.GetInstance().Random.Next(1, world.YWorldMax))
                .SetGender(Gender.Female);
            var owl = owlBuilder
                .Build();

            world.AddEntity(owl);
            return world;
        }
    }
}
