using System.ComponentModel.DataAnnotations;

namespace Hotel.Models;

public sealed class Room
{
    [Key]
    public int Id { get; set; }

    public string? Number { get; set; }

    public bool HaveConditioner { get; set; }

    public bool HaveKitchen { get; set; }

    public bool IsOccupated { get; set; }
}
