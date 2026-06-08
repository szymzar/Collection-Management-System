using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Collection_Management_System.Models
{
    public class CollectibleItem : INotifyPropertyChanged
    {
        private string _name = string.Empty;
        private string _description = string.Empty;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public string ToFileString()
        {
            return $"{Name};{Description}";
        }

        public static CollectibleItem FromFileString(string line)
        {
            var parts = line.Split(';');
            if (parts.Length >= 2)
            {
                return new CollectibleItem
                {
                    Name = parts[0],
                    Description = parts[1]
                };
            }
            return new CollectibleItem { Name = line };
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
