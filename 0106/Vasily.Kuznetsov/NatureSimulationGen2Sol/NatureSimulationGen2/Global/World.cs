using System;
using System.Collections.Generic;
using NatureSimulationGen2.Animal;
using NatureSimulationGen2.Barrier;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using NatureSimulationGen2.AquaAnimal;
using NatureSimulationGen2.Plant;


namespace NatureSimulationGen2.Global
{
    public class World
    {
        public int XWorldMax { get; set; }
        public int YWorldMax { get; set; }
        public World(int xWorldMax, int yWorldMax)
        {
            XWorldMax = xWorldMax - 1;
            YWorldMax = yWorldMax - 1;
        }
        public List<Entity> EntityList = new List<Entity>();
        public Dictionary<Tuple<int, int>, SurfaceType> groundTypes = new Dictionary<Tuple<int, int>, SurfaceType>();
        public SurfaceType GetSurfaceTypeAt(int x, int y)
        {
            if (groundTypes.ContainsKey(Tuple.Create(x, y)))
            {
               return groundTypes[Tuple.Create(x, y)];
            }
            return SurfaceType.Ground;
        }

        public void SetSurfaceType(SurfaceType surfaceType, int x, int y)
        {
            groundTypes[Tuple.Create(x, y)] = surfaceType;
        }

        public void AddEntity(Entity entity)
        {
            if (!entity.GetSurface().Contains(SurfaceType.Water) &&
                groundTypes.ContainsKey(Tuple.Create(entity.X, entity.Y)) ||
                !entity.GetSurface().Contains(SurfaceType.Ground) &&
                !groundTypes.ContainsKey(Tuple.Create(entity.X, entity.Y)))
            {
                //TODO: FOR LOG
                Console.WriteLine("Impossible action");
            }
            else
            {
                EntityList.Add(entity);
            }
        }

        public void BorderInitialize(World world)
        {
            for (int i = 0; i < world.XWorldMax; i++)
            {
                for (int j = 0; j < world.YWorldMax; j++)
                {
                    if (i == 0 || i == world.XWorldMax || j == 0 || j == world.YWorldMax)
                    {
                        world.AddEntity(new Mountain(i, j));
                    }
                }
            }
        }
      
        public IEnumerable<Entity> GetObjectsAt(int x, int y)
        {
            return EntityList.Where(entity => entity.X == x && entity.Y == y);
        }

        public void RenderingMap()
        {
            CreateWater(9);
            var waterPerc = (XWorldMax * YWorldMax * 45 / 100);
            while (groundTypes.Count < waterPerc)
            {
                CreateWater();
            }

            for (int i = 0; i < RandomHolder.GetInstance().Random.Next(XWorldMax * YWorldMax); i++)
            {
                int randXOwl = RandomHolder.GetInstance().Random.Next(1, 15);
                int randYOwl = RandomHolder.GetInstance().Random.Next(1, 15);
                Owl owl;
                if (RandomHolder.GetInstance().Random.Next(0, 1) == 1)
                {
                    owl = new Owl(randXOwl, randYOwl, Gender.Male);
                    AddEntity(owl);
                }
                owl = new Owl(randXOwl, randYOwl, Gender.Female);
                AddEntity(owl);
            }

            for (int i = 0; i < RandomHolder.GetInstance().Random.Next(XWorldMax * YWorldMax / 3); i++)
            {
                int randXRabbit = RandomHolder.GetInstance().Random.Next(1, 15);
                int randYRabbit = RandomHolder.GetInstance().Random.Next(1, 15);
                Rabbit rabbit;
                if (RandomHolder.GetInstance().Random.Next(0, 1) == 1)
                {
                    rabbit = new Rabbit(randXRabbit, randYRabbit, Gender.Male);
                    AddEntity(rabbit);
                }
                rabbit = new Rabbit(randXRabbit, randYRabbit, Gender.Female);
                AddEntity(rabbit);
            }

            for (int i = 0; i < RandomHolder.GetInstance().Random.Next(XWorldMax * YWorldMax * 70 / 100); i++)
            {
                int randXDolphin = RandomHolder.GetInstance().Random.Next(1, 15);
                int randYDolphin = RandomHolder.GetInstance().Random.Next(1, 15);
                Dolphin dolphin;
                if (RandomHolder.GetInstance().Random.Next(0, 1) == 1)
                {
                    dolphin = new Dolphin(randXDolphin, randYDolphin, Gender.Male);
                    AddEntity(dolphin);
                }
                dolphin = new Dolphin(randXDolphin, randYDolphin, Gender.Female);
                AddEntity(dolphin);
            }

            for (int i = 0; i < RandomHolder.GetInstance().Random.Next(8); i++)
            {
                int randXRock = RandomHolder.GetInstance().Random.Next(1, 15);
                int randYRock = RandomHolder.GetInstance().Random.Next(1, 15);
                Rock rock = new Rock(randXRock, randYRock);
                AddEntity(rock);
            }

            for (int i = 0; i < RandomHolder.GetInstance().Random.Next(XWorldMax * YWorldMax * 4); i++)
            {
                int randXTree = RandomHolder.GetInstance().Random.Next(1, 15);
                int randYTree = RandomHolder.GetInstance().Random.Next(1, 15);

                if (!groundTypes.ContainsKey(Tuple.Create(randXTree, randYTree)) && EntityList.Any(e => e.GetType() == typeof(Mountain))) 
                {
                    Tree tree = new Tree(randXTree, randYTree);
                    AddEntity(tree);
                }
            }
        }
        public void CreateWater(int range = 5)
        {
            int randXWaterStart = RandomHolder.GetInstance().Random.Next(1, 15);
            int randYWaterStart = RandomHolder.GetInstance().Random.Next(1, 15);
            var perimetr = RandomHolder.GetInstance().Random.Next(range);

            for (int i = (randXWaterStart - perimetr / 2); i < (randXWaterStart + perimetr / 2) && i > 0 && i < XWorldMax; i++)
            {
                for (int j = (randYWaterStart - perimetr / 2); j < (randYWaterStart + perimetr / 2) && j > 0 && j < YWorldMax; j++)
                {
                    SetSurfaceType(SurfaceType.Water, i, j);
                    GetSurfaceTypeAt(i, j);
                }
            }
        }

        public void UpkeepTurn()
        {
            EntityList = (from element in EntityList
                          where (element is Animal.Animal)
                          select element).ToList();
            EntityList.RemoveAll(x => (((Animal.Animal) x).Health) <= 1);
        }

        public void Turn()
        {
            {
                for (int i = 0; i < EntityList.Count; i++)
                {
                    var entityIntention = EntityList[i].RequestIntention(this);
                    var newXCoord = EntityList[i].X + entityIntention.DeltaX;
                    var newYCoord = EntityList[i].Y + entityIntention.DeltaY;
                    var objectsAtTheNewPoint = GetObjectsAt(newXCoord, newYCoord);

                    if (EntityList[i].GetType() == typeof(Rabbit) && objectsAtTheNewPoint.Any(e => GetType() != typeof(Rock) 
                    && !groundTypes.ContainsKey(Tuple.Create(newXCoord, newYCoord))))
                    {
                        if ((newXCoord > XWorldMax) || newYCoord > (YWorldMax) || (newXCoord < 1) || (newYCoord < 1))
                        {
                            EntityList[i].X = EntityList[i].X;
                            EntityList[i].Y = EntityList[i].Y;
                        }
                        else
                        {
                            EntityList[i].X += entityIntention.DeltaX;
                            EntityList[i].Y += entityIntention.DeltaY;
                            Thread.Sleep(100);
                        }
                    }
                    
                    else if (EntityList[i].GetType() == typeof(Dolphin) && groundTypes.ContainsKey(Tuple.Create(newXCoord, newYCoord)))
                    {
                        EntityList[i].X += entityIntention.DeltaX;
                        EntityList[i].Y += entityIntention.DeltaY;
                        Thread.Sleep(100);
                    }
                    
                    
                    else if (EntityList[i].GetType() == typeof(Owl) && objectsAtTheNewPoint.Any(e => e.GetType() != typeof(Mountain)))
                    {
                        EntityList[i].X += entityIntention.DeltaX;
                        EntityList[i].Y += entityIntention.DeltaY;
                        Thread.Sleep(100);
                    }
                }
            }
        }

        //Test
        public int NumberOfEntity
        {
            get { return EntityList.Count(); }
        }
        public int NumberOfEntityExcludeMountain
        {
            get { return EntityList.Count(e => e.GetType() != typeof(Mountain)); }
        }
        public int NumberOfMountain
        {
            get { return EntityList.Count(e => e.GetType() == typeof(Mountain)); }
        }
        public int NumberOfOwl
        {
            get { return EntityList.Count(e => e.GetType() == typeof(Owl)); }
        }
        public int NumberOfDolphin
        {
            get { return EntityList.Count(e => e.GetType() == typeof(Dolphin)); }
        }

        public int NumberOfRabbit
        {
            get { return EntityList.Count(e => e.GetType() == typeof(Rabbit)); }
        }

        public void PrintEntityList()
        {
            foreach (var element in EntityList)
            {
                Console.WriteLine("Type = {0}, x= {1}, y={2}", element.GetType(), element.X, element.Y);
            }
        }

        public void PrintEntityListExcludeMountain()
        {
            foreach (var entity in EntityList)
            {
                if (entity.GetType() != typeof(Mountain))
                {
                    Console.WriteLine("Object type: {0}, x= {1}, y={2}", entity.GetType(), entity.X, entity.Y);
                }
            }
        }
    }
}



