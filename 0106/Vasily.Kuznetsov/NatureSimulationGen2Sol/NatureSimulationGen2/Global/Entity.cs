using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using NatureSimulationGen2.Animal;

namespace NatureSimulationGen2.Global
{
    public abstract class Entity : ICoord, IProduceBehavior
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsBarrier { get; set; }
        public List<SurfaceType> SurfaceType { get; set; }
        protected Entity(int x, int y)
        {
            X = x;
            Y = y;
            IsBarrier = GetBarrier();
        }
        public abstract Intention RequestIntention(World world);
        public abstract List<SurfaceType> GetSurface();
        public abstract bool GetBarrier();
    }
}
