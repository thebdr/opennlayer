using System.Threading.Tasks;

namespace OpennLayer.Runtime.Abstraction
{
    public interface ITiaRuntime
    {
        ITiaSession Session { get; }
    }

    public interface ITiaSession
    {
        Task AttachAsync();
        void Detach();
        object Project { get; }
    }
}