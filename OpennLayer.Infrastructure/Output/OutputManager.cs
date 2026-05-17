using System;
using System.IO;

namespace OpennLayer.Infrastructure.Output
{
    public static class OutputManager
    {
        private static readonly string BasePath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "OpennLayer");

        public static string Projects => Create("Projects");

        private static string Create(string name)
        {
            string path = Path.Combine(BasePath, name);
            Directory.CreateDirectory(path);
            return path;
        }
    }
}