using System;
using System.Collections.Generic;
using NatureSimulationGen2.Animal;
using NatureSimulationGen2.Barrier;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using NatureSimulationGen2.AquaAnimal;
using NatureSimulationGen2.BuilderRecorder;
using NatureSimulationGen2.BuilderRecorder.Exception;
using NatureSimulationGen2.Plant;


namespace NatureSimulationGen2.Global
{
    public class World
    {
        public int XMax { get; set; }
        public int YMax { get; set; }
        private Builder.BuilderRecorder _builderRecorder;
        public World(int xMax, int yMax, Builder.BuilderRecorder builderRecorder)
        {
            XMax = xMax - 1;
            YMax = yMax - 1;
            _builderRecorder = builderRecorder;
        }
        public List<Entity> EntityList = new List<Entity>();
        private readonly Dictionary<Tuple<int, int>, SurfaceType> _groundTypes = new Dictionary<Tuple<int, int>, SurfaceType>();

        public bool GroundTypesContainsKey(int x, int y)
        {
            return _groundTypes.ContainsKey(Tuple.Create(x, y));
        }

        public int GetGroundTypesCount()
        {
            return _groundTypes.Count;
        }

        public SurfaceType GetSurfaceTypeAt(int x, int y)
        {
            if (_groundTypes.ContainsKey(Tuple.Create(x, y)))
            {
                return _groundTypes[Tuple.Create(x, y)];
            }
            return SurfaceType.Ground;
        }
        public void SetSurfaceType(SurfaceType surfaceType, int x, int y)
        {
            _groundTypes[Tuple.Create(x, y)] = surfaceType;
        }
        public void AddEntity(Entity entity)
        {
            if (entity.GetSurfaces().Contains(GetSurfaceTypeAt(entity.X, entity.Y)))
            {
                Console.WriteLine("Impossible action");   
            }
            else
            {
                EntityList.Add(entity);
            }

            //if (!entity.GetSurfaces().Contains(SurfaceType.Water) &&
            //    _groundTypes.ContainsKey(Tuple.Create(entity.X, entity.Y)) ||
            //    !entity.GetSurfaces().Contains(SurfaceType.Ground) &&
            //    !_groundTypes.ContainsKey(Tuple.Create(entity.X, entity.Y)))
            //{
            //    Console.WriteLine("Impossible action");
            //}
            //else
            //{
            //    EntityList.Add(entity);
            //}
        }
        public IEnumerable<Entity> GetObjectsAt(int x, int y)
        {
            return EntityList.Where(entity => entity.X == x && entity.Y == y);
        }

        public void PreTurn()
        {
            EntityList = (from element in EntityList
                          where (element is Animal.Animal) //review: OfType <Animal>
                          select element).ToList();
            EntityList.RemoveAll(x => (((Animal.Animal)x).Health) <= 1);
        }
        public void Turn()
        {
            {
                //review: почему не foreach?
                for (int i = 0; i < EntityList.Count; i++)
                {
                    var entityIntention = EntityList[i].RequestIntention(this);
                    var newXCoord = EntityList[i].X + entityIntention.DeltaX;
                    var newYCoord = EntityList[i].Y + entityIntention.DeltaY;
                    var objectsAtTheNewPoint = GetObjectsAt(newXCoord, newYCoord);

                    //review: зачем нам списки существ, которые могут двигаться определеным образом? надо работать с текущим существом (переменной цикла)
                    IEnumerable<Animal.Animal> canJustSwimAnimals =
                        EntityList.OfType<Animal.Animal>()
                            .Where(a => a.SurfaceType.Contains(SurfaceType.Water) &&
                                !a.SurfaceType.Contains(SurfaceType.Ground));
                    IEnumerable<Animal.Animal> canJustWalkAnimals =
                        EntityList.OfType<Animal.Animal>()
                            .Where(a => a.SurfaceType.Contains(SurfaceType.Ground) &&
                                       !a.SurfaceType.Contains(SurfaceType.Water));
                    IEnumerable<Animal.Animal> canWalkAndSwimAnimals =
                        EntityList.OfType<Animal.Animal>()
                            .Where(a => a.SurfaceType.Contains(SurfaceType.Water) &&
                                        a.SurfaceType.Contains(SurfaceType.Ground));
                    IEnumerable<Animal.Animal> canFlyAnimals =
                        EntityList.OfType<Animal.Animal>()
                            .Where(a => a.SurfaceType.Contains(SurfaceType.Ground) &&
                                        a.SurfaceType.Contains(SurfaceType.Water));

                    if (canJustWalkAnimals != null && (!objectsAtTheNewPoint.Any(e => e is IBarrier) && !_groundTypes.ContainsKey(Tuple.Create(newXCoord, newYCoord))))
                    {
                        if ((newXCoord > XMax) || newYCoord > (YMax) || (newXCoord < 1) || (newYCoord < 1))
                        {
                            EntityList[i].X = EntityList[i].X;
                            EntityList[i].Y = EntityList[i].Y;
                        }
                        else
                        {
                            EntityList[i].X += entityIntention.DeltaX;
                            EntityList[i].Y += entityIntention.DeltaY;

                        }
                    }
                    else if (canJustSwimAnimals != null && _groundTypes.ContainsKey(Tuple.Create(newXCoord, newYCoord)))
                    {
                        EntityList[i].X += entityIntention.DeltaX;
                        EntityList[i].Y += entityIntention.DeltaY;

                    }
                    else if (canFlyAnimals != null)
                    {
                        EntityList[i].X += entityIntention.DeltaX;
                        EntityList[i].Y += entityIntention.DeltaY;
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



