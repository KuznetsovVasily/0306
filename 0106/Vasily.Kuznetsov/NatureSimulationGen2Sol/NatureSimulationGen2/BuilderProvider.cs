using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureSimulationGen2
{
    public class BuilderProvider
    {
        private Dictionary<Type, IEntityBuilder> builderRegistry = new Dictionary<Type, IEntityBuilder>();
            


        public void Register(Type entityType, IEntityBuilder builder)
        {
            if (builderRegistry.ContainsKey(entityType))
            {
                throw new Exception();
            }
            else
            {

            }

        }
    }
}

public interface IEntityBuilder
{

}