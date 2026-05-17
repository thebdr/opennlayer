using System;
using OpennLayer.Runtime.Abstraction;
using OpennLayer.Runtime.V18;
using OpennLayer.Runtime.V19;

namespace OpennLayer.Application
{
    public static class RuntimeFactory
    {
        public static ITiaRuntime Create(string version)
        {
            return version switch
            {
                "18" => new TiaRuntimeV18(),
                "19" => new TiaRuntimeV19(),
                _ => throw new Exception($"Unsupported TIA version: {version}")
            };
        }
    }
}