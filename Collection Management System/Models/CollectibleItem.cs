namespace Collection_Management_System.Models
{
    public class CollectibleItem
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

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
    }
}
