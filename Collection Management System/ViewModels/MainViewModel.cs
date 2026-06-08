using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Collection_Management_System.Models;
using Collection_Management_System.Services;

namespace Collection_Management_System.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly FileService _fileService;
        public ObservableCollection<UserCollection> Collections { get; set; }

        public ICommand AddCollectionCommand { get; }

        public MainViewModel()
        {
            _fileService = new FileService();
            Collections = _fileService.LoadCollections();

            AddCollectionCommand = new Command<string>(AddCollection);
        }

        private void AddCollection(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return;

            var newCollection = new UserCollection(name);
            Collections.Add(newCollection);
            _fileService.SaveCollection(newCollection);
        }

        public void RefreshCollections()
        {
            var updated = _fileService.LoadCollections();
            Collections.Clear();
            foreach (var coll in updated)
            {
                Collections.Add(coll);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
