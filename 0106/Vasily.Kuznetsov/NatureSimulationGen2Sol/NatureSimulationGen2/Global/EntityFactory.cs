using NatureSimulationGen2.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureSimulationGen2.Global
{
    public class EntityFactory
    {
        public Dictionary<int, Func<Tuple<int, int>, Entity>> RandomEntity = new Dictionary<int, Func<Tuple<int, int>, Entity>>
        {
            {1, new Owl(RandomHolder.GetInstance().GetRandomX, RandomHolder.GetInstance().GetRandomY },
            
        };

        

    }
}
