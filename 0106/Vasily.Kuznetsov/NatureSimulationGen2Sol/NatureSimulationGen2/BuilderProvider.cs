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
                throw new BuilderAlreadyRegisteredException(string.Format("Builder for class {0} already registered ", entityType.Name));
            }
            else
            {
                builderRegistry[entityType] = builder;
            }
        }
    }
}

public interface IEntityBuilder
{

}

public class BuilderAlreadyRegisteredException : Exception
{
    public BuilderAlreadyRegisteredException(string message)
        :base(message)
    {
    }
}