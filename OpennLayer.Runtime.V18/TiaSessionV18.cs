using Siemens.Engineering;
using System;
using System.IO;
using System.Threading.Tasks;
using OpennLayer.Infrastructure.Output;
using OpennLayer.Runtime.Abstraction;

namespace OpennLayer.Runtime.V18
{
    public class TiaSessionV18 : ITiaSession
    {
        private TiaPortal _portal;
        private Project _project;

        public object Project => _project;

        public async Task AttachAsync()
        {
            await Task.Run(() =>
            {
                _portal = new TiaPortal(TiaPortalMode.WithUserInterface);

                var dir = new DirectoryInfo(OutputManager.Projects);

                string name = $"Project_{DateTime.Now:yyyyMMdd_HHmmss}";

                _project = _portal.Projects.Create(dir, name);
            });
        }

        public void Detach()
        {
            _portal?.Dispose();
        }
    }
}
