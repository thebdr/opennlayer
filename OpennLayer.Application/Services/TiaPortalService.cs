using System.Threading.Tasks;
using OpennLayer.Runtime.Abstraction;

namespace OpennLayer.Application.Services
{
    public class TiaPortalService
    {
        public async Task AttachAsync(string version)
        {
            var runtime = RuntimeFactory.Create(version);

            await runtime.Session.AttachAsync();
        }
    }
}