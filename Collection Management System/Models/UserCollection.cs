using System.Collections.ObjectModel;

namespace Collection_Management_System.Models
{
    public class UserCollection
    {
        public string Name { get; set; } = string.Empty;
        public ObservableCollection<CollectibleItem> Items { get; set; } = new();

        public UserCollection(string name)
        {
            Name = name;
        }
    }
}
