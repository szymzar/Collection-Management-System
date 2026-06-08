using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Collection_Management_System.Models;
using Collection_Management_System.Services;

namespace Collection_Management_System.ViewModels
{
    public class CollectionViewModel : INotifyPropertyChanged
    {
        private readonly FileService _fileService;
        private UserCollection _collection;

        public string CollectionName => _collection.Name;
        public ObservableCollection<CollectibleItem> Items => _collection.Items;

        public CollectionViewModel(UserCollection collection)
        {
            _fileService = new FileService();
            _collection = collection;
        }

        public void AddItem(string name, string description)
        {
            var newItem = new CollectibleItem { Name = name, Description = description };
            _collection.Items.Add(newItem);
            _fileService.SaveCollection(_collection);
        }

        public void UpdateItem(CollectibleItem item, string name, string description)
        {
            item.Name = name;
            item.Description = description;
            _fileService.SaveCollection(_collection);
            OnPropertyChanged(nameof(Items));
        }

        public void DeleteItem(CollectibleItem item)
        {
            _collection.Items.Remove(item);
            _fileService.SaveCollection(_collection);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
