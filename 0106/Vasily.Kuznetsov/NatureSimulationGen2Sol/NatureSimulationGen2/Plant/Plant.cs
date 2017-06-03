using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NatureSimulationGen2.Global;

namespace NatureSimulationGen2.Plant
{
    public abstract class Plant : Entity
    {
        public int Health { get; set; }
        public bool IsFoodForVegan { get; set; }
        protected Plant(int x, int y, int health, bool isFoodForVegan = true)
            : base(x, y)
        {
            IsFoodForVegan = isFoodForVegan;
            Health = health;
            IsBarrier = true;
        }
    }
}
