using System.Collections.ObjectModel;
using Collection_Management_System.Models;
using Collection_Management_System.Services;

namespace Collection_Management_System.ViewModels
{
    public class MainViewModel
    {
        private readonly FileService _fileService;
        public ObservableCollection<UserCollection> Collections { get; set; }

        public MainViewModel()
        {
            _fileService = new FileService();
            Collections = _fileService.LoadCollections();
        }

        public void AddCollection(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return;

            var newCollection = new UserCollection(name);
            Collections.Add(newCollection);
            _fileService.SaveCollection(newCollection);
        }
    }
}
