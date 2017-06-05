using System;
using System.Collections.Generic;
using NatureSimulationGen2.BuilderRecorder;
using NatureSimulationGen2.BuilderRecorder.Exception;

namespace NatureSimulationGen2.Builder
{
    public class BuilderRecorder
    {
        private readonly Dictionary<Type, IEntityBuilder> _builderRegistry = new Dictionary<Type, IEntityBuilder>();
        public BuilderRecorder Register(Type entityType, IEntityBuilder builder)
        {
            if (_builderRegistry.ContainsKey(entityType))
            {
                throw new BuilderAlreadyRegisteredException($"BuilderRecorder for class {entityType.Name} already registered");
            }
            else
            {
                _builderRegistry[entityType] = builder;
            }
            return this;
        }
        public IEntityBuilder GetBuilder(Type entityType)
        {
            if (_builderRegistry.ContainsKey(entityType))
            {
                return _builderRegistry[entityType];
            }
            throw new BuilderNotFoundException($"BuilderRecorder for class {entityType.Name} not found");
        }
    }
}


