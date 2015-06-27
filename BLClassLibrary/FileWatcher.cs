using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLClassLibrary
{
    public static class FileWatcher
    {
        private static readonly FileSystemWatcher Watcher = new FileSystemWatcher();

        private static string GetConnectionString(string name)
        {
            var settings = ConfigurationManager.ConnectionStrings[name];
            return settings.ConnectionString;
        }

        public static void Start()
        {
            Watcher.Path = GetConnectionString("FolderPath");
            Watcher.NotifyFilter = NotifyFilters.FileName;
            Watcher.Filter = "*.csv";
            Watcher.EnableRaisingEvents = true;
            Watcher.Created += WatcherOnCreated;
        }

        public static void Stop()
        {
            Watcher.Created -= WatcherOnCreated;
            Watcher.EnableRaisingEvents = false;
        }

        private async static void WatcherOnCreated(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            Console.WriteLine("Start file: {0}",fileSystemEventArgs.FullPath);
            var fileAnalyser = new FileAnalyser();
            await fileAnalyser.ParseFile(fileSystemEventArgs.FullPath, fileSystemEventArgs.Name);
            Console.WriteLine("Finish file: {0}", fileSystemEventArgs.FullPath);
        }
    }
}
