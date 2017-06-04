using NatureSimulationGen2.Animal;
using NatureSimulationGen2.AquaAnimal;
using NatureSimulationGen2.Barrier;
using NatureSimulationGen2.Builder;
using NatureSimulationGen2.Plant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureSimulationGen2.Global.Initialize
{
    public class ManualInitializer : IWorldInitializer
    {
        public World InitializeWorld(World world, BuilderProvider builderProvider)
        {
            CreateWater(world, 9);
            var waterPerc = (world.XWorldMax * world.YWorldMax * 45 / 100);
            while (world.groundTypes.Count < waterPerc)
            {
                CreateWater(world);
            }

            for (int i = 0; i < 5; i++)
            {
                int randXOwl = RandomHolder.GetInstance().Random.Next(1, world.XWorldMax);
                int randYOwl = RandomHolder.GetInstance().Random.Next(1, world.YWorldMax);
                if (RandomHolder.GetInstance().Random.Next(0, 2) == 1)
                {
                    var owlBuilder = ((LikeOwlBuilder)builderProvider.GetBuilder(typeof(Owl)))
                                    .SetCoordinates(randXOwl, randYOwl)
                                    .SetGender(Gender.Male);
                    var owl = owlBuilder.Build();
                    world.AddEntity(owl);
                }
                else
                {
                    var owlBuilder = ((LikeOwlBuilder)builderProvider.GetBuilder(typeof(Owl)))
                                    .SetCoordinates(randXOwl, randYOwl)
                                    .SetGender(Gender.Female);
                    var owl = owlBuilder.Build();
                    world.AddEntity(owl);
                }
            
            }

            for (int i = 0; i < 5; i++)
            {
                int randXRabbit = RandomHolder.GetInstance().Random.Next(1, world.XWorldMax);
                int randYRabbit = RandomHolder.GetInstance().Random.Next(1, world.YWorldMax);
                if (RandomHolder.GetInstance().Random.Next(0, 2) == 1)
                {
                    var rabbitBuilder = ((RabbitBuilder)builderProvider.GetBuilder(typeof(Rabbit)))
                                    .SetCoordinates(randXRabbit, randYRabbit)
                                    .SetGender(Gender.Male);
                    var rabbit = rabbitBuilder.Build();
                    world.AddEntity(rabbit);
                }
                else
                {
                    var rabbitBuilder = ((RabbitBuilder)builderProvider.GetBuilder(typeof(Rabbit)))
                                    .SetCoordinates(randXRabbit, randYRabbit)
                                    .SetGender(Gender.Female);
                    var rabbit = rabbitBuilder.Build();
                    world.AddEntity(rabbit);
                }

            }
            
            for (int i = 0; i < RandomHolder.GetInstance().Random.Next(world.XWorldMax * world.YWorldMax * 70 / 100); i++)
            {
                int randXDolphin = RandomHolder.GetInstance().Random.Next(1, 15);
                int randYDolphin = RandomHolder.GetInstance().Random.Next(1, 15);

                if (RandomHolder.GetInstance().Random.Next(0, 2) == 1)
                {
                    var dolphinBuilder = ((RabbitBuilder)builderProvider.GetBuilder(typeof(Rabbit)))
                                    .SetCoordinates(randXDolphin, randYDolphin)
                                    .SetGender(Gender.Male);
                    var dolphin = dolphinBuilder.Build();
                    world.AddEntity(dolphin);
                }
                else
                {
                    var dolphinBuilder = ((RabbitBuilder)builderProvider.GetBuilder(typeof(Rabbit)))
                                    .SetCoordinates(randXDolphin, randYDolphin)
                                    .SetGender(Gender.Female);
                    var dolphin = dolphinBuilder.Build();
                    world.AddEntity(dolphin);
                }
            }

            for (int i = 0; i < RandomHolder.GetInstance().Random.Next(world.XWorldMax * world.YWorldMax * 4); i++)
            {
                int randXTree = RandomHolder.GetInstance().Random.Next(1, 15);
                int randYTree = RandomHolder.GetInstance().Random.Next(1, 15);

                if (!world.groundTypes.ContainsKey(Tuple.Create(randXTree, randYTree)) && world.EntityList.Any(e => e.GetType() == typeof(Mountain)))
                {
                    Tree tree = new Tree(randXTree, randYTree);
                    world.AddEntity(tree);
                }
            }
            return world;
        }

        public void CreateWater(World world, int range = 5)
        {
            int randXWaterStart = RandomHolder.GetInstance().Random.Next(1, 15);
            int randYWaterStart = RandomHolder.GetInstance().Random.Next(1, 15);
            var perimetr = RandomHolder.GetInstance().Random.Next(range);

            for (int i = (randXWaterStart - perimetr / 2); i < (randXWaterStart + perimetr / 2) && i > 0 && i < world.XWorldMax; i++)
            {
                for (int j = (randYWaterStart - perimetr / 2); j < (randYWaterStart + perimetr / 2) && j > 0 && j < world.YWorldMax; j++)
                {
                    world.SetSurfaceType(SurfaceType.Water, i, j);
                    world.GetSurfaceTypeAt(i, j);
                }
            }
        }
    }
}


