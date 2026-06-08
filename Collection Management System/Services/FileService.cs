using System.Collections.ObjectModel;
using System.Diagnostics;
using Collection_Management_System.Models;

namespace Collection_Management_System.Services
{
    public class FileService
    {
        private readonly string _dataDirectory = Path.Combine(FileSystem.AppDataDirectory, "Collections");

        public FileService()
        {
            if (!Directory.Exists(_dataDirectory))
            {
                Directory.CreateDirectory(_dataDirectory);
            }
            
            Debug.WriteLine($"App Data Path: {_dataDirectory}");
        }

        public string GetDataDirectoryPath() => _dataDirectory;
        public ObservableCollection<UserCollection> LoadCollections()
        {
            var collections = new ObservableCollection<UserCollection>();
            var files = Directory.GetFiles(_dataDirectory, "*.txt");

            foreach (var file in files)
            {
                var collectionName = Path.GetFileNameWithoutExtension(file);
                var collection = new UserCollection(collectionName);

                var lines = File.ReadAllLines(file);
                foreach (var line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        collection.Items.Add(CollectibleItem.FromFileString(line));
                    }
                }
                collections.Add(collection);
            }

            return collections;
        }

        public void SaveCollection(UserCollection collection)
        {
            var filePath = Path.Combine(_dataDirectory, $"{collection.Name}.txt");
            var lines = new List<string>();

            foreach (var item in collection.Items)
            {
                lines.Add(item.ToFileString());
            }

            File.WriteAllLines(filePath, lines);
        }

        public void DeleteCollection(string collectionName)
        {
            var filePath = Path.Combine(_dataDirectory, $"{collectionName}.txt");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
