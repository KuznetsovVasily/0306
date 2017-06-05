using NatureSimulationGen2.Animal;
using NatureSimulationGen2.AquaAnimal;
using NatureSimulationGen2.Barrier;
using NatureSimulationGen2.BuilderRecorder;
using NatureSimulationGen2.Plant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NatureSimulationGen2.Builder;

namespace NatureSimulationGen2.Global.Initialize
{
    public class ManualInitializer : IWorldInitializer
    {
        //review: почему world не сделать полем класса&
        public World InitializeWorld(World world, Builder.BuilderRecorder builderRecorder)
        {
            BorderInitialize(world);
            CreateWater(world, 9);
            var waterPerc = (world.XMax * world.YMax * 45 / 100);
            while (world._groundTypes.Count < waterPerc)
            {
                CreateWater(world);
            }
            //review: зачем тут повторяющиеся куски кода? 
            for (int i = 1; i < RandomHolder.GetInstance().Random.Next(world.XMax); i++)
            {
                int randXOwl = RandomHolder.GetInstance().Random.Next(1, world.XMax - 1);
                int randYOwl = RandomHolder.GetInstance().Random.Next(1, world.YMax- 1 );
                if (RandomHolder.GetInstance().Random.Next(0, 2) == 1)
                {
                    var owlBuilder = ((OwlBuilder)builderRecorder.GetBuilder(typeof(Owl)))
                                    .SetCoordinates(randXOwl, randYOwl)
                                    .SetGender(Gender.Male);
                    var owl = owlBuilder.Build();
                    world.AddEntity(owl);
                }
                else
                {
                    var owlBuilder = ((OwlBuilder)builderRecorder.GetBuilder(typeof(Owl)))
                                    .SetCoordinates(randXOwl, randYOwl)
                                    .SetGender(Gender.Female);
                    var owl = owlBuilder.Build();
                    world.AddEntity(owl);
                }
            }
            for (int i = 1; i < RandomHolder.GetInstance().Random.Next(world.XMax); i++)
            {
                int randXRabbit = RandomHolder.GetInstance().Random.Next(1, world.XMax - 1);
                int randYRabbit = RandomHolder.GetInstance().Random.Next(1, world.YMax - 1);
                if (RandomHolder.GetInstance().Random.Next(0, 2) == 1)
                {
                    var rabbitBuilder = ((RabbitBuilder)builderRecorder.GetBuilder(typeof(Rabbit)))
                                    .SetCoordinates(randXRabbit, randYRabbit)
                                    .SetGender(Gender.Male);
                    var rabbit = rabbitBuilder.Build();
                    world.AddEntity(rabbit);
                }
                else
                {
                    var rabbitBuilder = ((RabbitBuilder)builderRecorder.GetBuilder(typeof(Rabbit)))
                                    .SetCoordinates(randXRabbit, randYRabbit)
                                    .SetGender(Gender.Female);
                    var rabbit = rabbitBuilder.Build();
                    world.AddEntity(rabbit);
                }
            }
            for (int i = 1; i < RandomHolder.GetInstance().Random.Next(world.XMax * world.YMax * 70 / 100); i++)
            {
                int randXDolphin = RandomHolder.GetInstance().Random.Next(1, 15);
                int randYDolphin = RandomHolder.GetInstance().Random.Next(1, 15);

                if (RandomHolder.GetInstance().Random.Next(0, 2) == 1)
                {
                    var dolphinBuilder = ((DolphinBuilder)builderRecorder.GetBuilder(typeof(Dolphin)))
                                    .SetCoordinates(randXDolphin, randYDolphin)
                                    .SetGender(Gender.Male);
                    var dolphin = dolphinBuilder.Build();
                    world.AddEntity(dolphin);
                }
                else
                {
                    var dolphinBuilder = ((DolphinBuilder)builderRecorder.GetBuilder(typeof(Dolphin)))
                                    .SetCoordinates(randXDolphin, randYDolphin)
                                    .SetGender(Gender.Female);
                    var dolphin = dolphinBuilder.Build();
                    world.AddEntity(dolphin);
                }
            }
            for (int i = 0; i < RandomHolder.GetInstance().Random.Next(world.XMax * world.YMax * 4); i++)
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
            int randXWaterStart = RandomHolder.GetInstance().Random.Next(1, world.XMax - 1);
            int randYWaterStart = RandomHolder.GetInstance().Random.Next(1, world.YMax - 1);
            var perimetr = RandomHolder.GetInstance().Random.Next(range);

            for (int i = (randXWaterStart - perimetr / 2); i < (randXWaterStart + perimetr / 2) && i > 0 && i < world.XMax; i++)
            {
                for (int j = (randYWaterStart - perimetr / 2); j < (randYWaterStart + perimetr / 2) && j > 0 && j < world.YMax; j++)
                {
                    world.SetSurfaceType(SurfaceType.Water, i, j);
                    world.GetSurfaceTypeAt(i, j);
                }
            }
        }
        public void BorderInitialize(World world)
        {
            for (int i = 0; i < world.XMax; i++)
            {
                for (int j = 0; j < world.YMax; j++)
                {
                    if (i == 0 || i == world.XMax || j == 0 || j == world.YMax)
                    {
                        world.AddEntity(new Mountain(i, j));
                    }
                }
            }
        }
    }
}


