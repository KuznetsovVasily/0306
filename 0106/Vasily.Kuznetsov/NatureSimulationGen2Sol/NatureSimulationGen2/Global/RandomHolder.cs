using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NatureSimulationGen2.Global
{
    public class RandomHolder
    {
        private static RandomHolder _instance;
        public Random Random { get; set; }
        public RandomHolder()
        {
            Random = new Random((int) DateTime.Now.Ticks);
            Thread.Sleep(100);
        }

        public static RandomHolder GetInstance()
        {
            return _instance ?? (_instance = new RandomHolder());
        }
    }
}