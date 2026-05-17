using OpennLayer.Runtime.Abstraction;

namespace OpennLayer.Runtime.V18
{
    public class TiaRuntimeV18 : ITiaRuntime
    {
        public ITiaSession Session { get; }

        public TiaRuntimeV18()
        {
            Session = new TiaSessionV18();
        }
    }
}
