using System;
using System.Collections.Concurrent;
using System.Configuration;
using System.IO;

namespace BLClassLibrary
{
    public class FileWatcher
    {
        private readonly FileSystemWatcher _watcher = new FileSystemWatcher();
        private readonly BlockingCollection<string> _repositoryFiles = new BlockingCollection<string>();
        
        private string GetSetting(string name)
        {
            var settings = ConfigurationManager.AppSettings;
            return settings[name];
        }

        public void Start()
        {
            var path = GetSetting("FolderPath");
            if (path == null) return;
            _watcher.Path = path;
            _watcher.NotifyFilter = NotifyFilters.FileName;
            _watcher.Filter = "*.csv";
            _watcher.EnableRaisingEvents = true;
            _watcher.Created += WatcherOnCreated;            
        }
        
        public void Stop()
        {
            _watcher.Created -= WatcherOnCreated;
            _watcher.EnableRaisingEvents = false;
            _watcher.Dispose();
        }

        private void WatcherOnCreated(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            _repositoryFiles.Add(fileSystemEventArgs.FullPath);            
        }

        public async void FilesHandleAsync()
        {
            while (!_repositoryFiles.IsCompleted)
            {
                string fileName = null;
                try
                {
                    fileName = _repositoryFiles.Take();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
                if (fileName == null) continue;
                Console.WriteLine("Start file: {0}", fileName);
                var fileAnalyser = new FileAnalyser();
                await fileAnalyser.ParseFile(fileName, fileName.Replace(GetSetting("FolderPath"),""));
                Console.WriteLine("Finish file: {0}", fileName);
            }
        }
    }
}
