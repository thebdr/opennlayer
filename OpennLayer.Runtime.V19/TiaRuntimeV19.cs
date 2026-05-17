using OpennLayer.Runtime.Abstraction;

namespace OpennLayer.Runtime.V19
{
    public class TiaRuntimeV19 : ITiaRuntime
    {
        public ITiaSession Session { get; }

        public TiaRuntimeV19()
        {
            Session = new TiaSessionV19();
        }
    }
}