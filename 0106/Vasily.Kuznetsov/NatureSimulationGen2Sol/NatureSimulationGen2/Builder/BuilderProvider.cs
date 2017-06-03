using NatureSimulationGen2;
using NatureSimulationGen2.Animal;
using NatureSimulationGen2.AquaAnimal;
using NatureSimulationGen2.Barrier;
using NatureSimulationGen2.Builder;
using NatureSimulationGen2.Builder.Exception;
using NatureSimulationGen2.Global;
using NatureSimulationGen2.Plant;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NatureSimulationGen2
{
    public class BuilderProvider
    {
        private Dictionary<Type, IEntityBuilder> builderRegistry = new Dictionary<Type, IEntityBuilder>();

        public BuilderProvider Register(Type entityType, IEntityBuilder builder)
        {
            if (builderRegistry.ContainsKey(entityType))
            {
                throw new BuilderAlreadyRegisteredException(string.Format("Builder for class {0} already registered ", entityType.Name));
            }
            else
            {
                builderRegistry[entityType] = builder;
            }
            return this;
        }

        internal void Register(Type type)
        {
            throw new NotImplementedException();
        }

        public IEntityBuilder GetBuilder(Type entityType)
        {
            if (builderRegistry.ContainsKey(entityType))
            {
                return builderRegistry[entityType];
            }
            throw new BuilderNotFoundException(string.Format("Builder for class {0} not found", entityType.Name));
        }
    }
}


