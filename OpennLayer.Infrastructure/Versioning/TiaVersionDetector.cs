using System.Collections.Generic;
using System.IO;

namespace OpennLayer.Infrastructure.Versioning
{
    public static class TiaVersionDetector
    {
        public static List<string> GetInstalledVersions()
        {
            var versions = new List<string>();

            string basePath = @"C:\Program Files\Siemens\Automation";

            if (!Directory.Exists(basePath))
                return versions;

            foreach (var dir in Directory.GetDirectories(basePath))
            {
                var name = Path.GetFileName(dir);

                if (name == "Portal V18")
                    versions.Add("18");

                if (name == "Portal V19")
                    versions.Add("19");
            }

            return versions;
        }
    }
}