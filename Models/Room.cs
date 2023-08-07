using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Room
    {
        [Key]
        public int ID { get; set; }

        public string? Number { get; set; }
        public bool HaveConditioner { get; set; }
        public bool HaveKitchen { get; set; }
        public bool IsOccupated { get; set; }
    }
}
