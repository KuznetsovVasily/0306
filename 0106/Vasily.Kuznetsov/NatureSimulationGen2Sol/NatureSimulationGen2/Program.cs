using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using NatureSimulationGen2.Animal;
using NatureSimulationGen2.AquaAnimal;
using NatureSimulationGen2.Barrier;
using NatureSimulationGen2.Builder;
using NatureSimulationGen2.Global;
using NatureSimulationGen2.Plant;
using NatureSimulationGen2.Global.Initialize;
using NatureSimulationGen2.BuilderRecorder;

namespace NatureSimulationGen2
{
    class Program
    {
        static void Main(string[] args)
        {
            Builder.BuilderRecorder builder = new Builder.BuilderRecorder();
            builder
           .Register(typeof(Rabbit), new RabbitBuilder())
           .Register(typeof(Dolphin), new DolphinBuilder())
           .Register(typeof(Owl), new OwlBuilder());

            World world = new World(15, 15, builder);
            world = new ManualInitializer().InitializeWorld(world, builder);

            for (int i = 0; i < 99; i++)
            {
                world.PreTurn();
                world.Turn();
            }
            Console.ReadLine();


            //            //I can get type on world with coord 2.2
            //            var cellTypeAt2X2 = world.GetSurfaceTypeAt(2, 2);
            //            if (cellTypeAt2X2 != (SurfaceType.Ground))
            //            {
            //                Console.WriteLine("We expect surface type at point 2x2 equal ground");
            //            }

            //            //I can create water on world with coord 4.4

            //            world.SetSurfaceType(SurfaceType.Water, 4, 4);
            //            var cellTypeAt4X4 = world.GetSurfaceTypeAt(4, 4);
            //            if (cellTypeAt4X4 != SurfaceType.Water)
            //            {
            //                Console.WriteLine("We except surface type at point 4x4 equal water");
            //            }

            //            //I can create a mountain and add it
            //            Mountain mountain = new Mountain(7, 6);
            //            world.AddEntity(mountain);

            //            //I can check the total number Entity increased
            //            if (world.NumberOfEntity != 1)
            //            {
            //                Console.WriteLine("Number of mountain in the world is not equal 1");
            //            }

            //            //I can create duck
            //            var owl = new Owl(7, 4, 2, Gender.Male);

            //            //I can add duck
            //            world.AddEntity(owl);
            //            world.PrintEntityListExcludeMountain();
            //            Console.WriteLine();

            //            //I can check number of ducks 
            //            if (world.NumberOfEntity != 2)
            //            {
            //                Console.WriteLine("Number of entities in the world is not equal 2");
            //            }
            //            world.UpkeepTurn();
            //            world.Turn();



            //            //Owl will move in a random Direction
            //            if (owl.X == 7 && owl.Y == 4)
            //            {
            //                Console.WriteLine("Owl is excepted to randomly move, current x = {0}, y = {1}", owl.X, owl.Y);
            //            }

            //            //I can add borders on map
            //            world.BorderInitialize(world);

            //            //I can add owl on world with coord 10.10
            //            Owl owlInPrison = new Owl(10, 10, 1, Gender.Female, health: 5);
            //            world.AddEntity(owlInPrison);
            //            world.PrintEntityListExcludeMountain();

            //            //I can add prison for owl
            //            for (int i = 9; i < 12; i++)
            //            {
            //                for (int j = 9; j < 12; j++)
            //                {
            //                    if (i != 10 || j != 10)
            //                    {
            //                        Mountain prison = new Mountain(i, j);
            //                        world.AddEntity(prison);
            //                    }
            //                }
            //            }
            //            world.UpkeepTurn();
            //            world.Turn();
            //            Console.WriteLine();
            //            //I can check that the duck is in prison
            //            if (owlInPrison.X != 10 || owlInPrison.Y != 10)
            //            {
            //                Console.WriteLine("The owl must be in prison");
            //            }
            //            Console.WriteLine();

            //            //I create Tree at the same Coord
            //            Tree tree = new Tree(5, 5);
            //            world.AddEntity(tree);
            //            //I create Owl and add it to the world with 5.5 Coord
            //            Owl owlTwo = new Owl(5, 5, 1, Gender.Female);
            //            world.AddEntity(owlTwo);

            //            //The owl must eat tree until 2 turn. Owl at point 5.5
            //            if (owlTwo.X != tree.X || owlTwo.Y != tree.Y)
            //            {
            //                Console.WriteLine("The owl must eat a tree for 2 turn, current ducks position: (x={0}, y={1}))", owlTwo.X, owlTwo.Y);
            //            }

            //            world.Turn();
            //            world.UpkeepTurn();
            //            world.PrintEntityListExcludeMountain();

            //            //I can check number of owls 
            //            var owlNumber = world.NumberOfOwl;
            //            if (world.NumberOfOwl != 1)
            //            {
            //                Console.WriteLine("We except that only one owl is alive now");
            //                Console.WriteLine(owlNumber);
            //            }

            //            //I can create some water on world with 
            //            for (int i = 1; i < 5; i++)
            //            {
            //                for (int j = 1; j < 5; j++)
            //                {
            //                    world.SetSurfaceType(SurfaceType.Water, i, j);
            //                }
            //            }

            //            //I can try create dolphin on ground with coord 14.14 and add it 
            //            Dolphin dolphin = new Dolphin(14, 14, 1, Gender.Male);
            //            world.AddEntity(dolphin);

            //            //I can check number of dolphins
            //            if (world.NumberOfDolphin == 1)
            //            {
            //                Console.WriteLine("Dolphin can't be create on ground - message from test");
            //            }

            //            //Try create new dolphin on water with 2.2 coord
            //            Dolphin correctDolphin = new Dolphin(2, 2, 1, Gender.Female, health: 1);
            //            world.AddEntity(correctDolphin);

            //            //I can check number on dolphin again
            //            if (world.NumberOfDolphin != 1)
            //            {
            //                Console.WriteLine("Number of dolphin in the world is not equal 1");
            //            }

            //            //Dolphin maleDolphinOn2X2 = new Dolphin(2, 2, 1, Gender.Male, health: 200);
            //            //world.AddDolphin(maleDolphinOn2X2);

            //            //I wanna see two dolphins 
            //            world.UpkeepTurn();
            //            world.Turn();
            //            world.PrintEntityListExcludeMountain();
            //            Console.WriteLine();

            //            //I can add owl and rabbit. 10.10
            //            Owl owlz = new Owl(10, 10, 0, Gender.Male, health: 10);
            //            world.AddEntity(owlz);
            //            Rabbit rabbit = new Rabbit(10, 10, 0, Gender.Female, health: 1);
            //            world.AddEntity(rabbit);
            //            Rabbit rabbitz = new Rabbit(14, 14, 1, Gender.Female, health: 100);
            //            world.AddEntity(rabbitz);

            //            world.UpkeepTurn();
            //            world.Turn();
            //            world.PrintEntityListExcludeMountain();
            //            Console.WriteLine();

            //            //The owl is hungry
            //            if (world.NumberOfRabbit != 1)
            //            {
            //                Console.WriteLine("The rabbit must die");
            //            }

            //            //Rabbit is out test
            //            for (int i = 0; i < 99; i++)
            //            {
            //                world.UpkeepTurn();
            //                world.Turn();

            //                if (rabbit.X > world.XMax || rabbit.X < 1 || rabbit.Y > world.YMax || rabbit.Y < 1)
            //                {
            //                    Console.WriteLine("Rabbit out");
            //                }
            //            }
            //            world.PrintEntityListExcludeMountain();
            //            Console.WriteLine();

            //            //Dolphin swiming test 
            //            //for (int i = 0; i < 99; i++)
            //            //{
            //            //    world.UpkeepTurn();
            //            //    world.Turn();

            //            //    if (maleDolphinOn2X2.X > 4 && maleDolphinOn2X2.Y > 4 && maleDolphinOn2X2.X < 1 &&
            //            //        maleDolphinOn2X2.Y < 1)
            //            //    {
            //            //        Console.WriteLine("Dolphin can only swim");
            //            //    }
            //            //}
            //            world.PrintEntityListExcludeMountain();
            //            Console.WriteLine("Test is finished");
            Console.ReadLine();


        }
    }
}