namespace Hotel.Models;

public class NewRoomRequest
{
       
    public string? Number { get;set; }
    public bool HaveConditioner { get; set; }
    public bool HaveKitchen { get; set; }
    public bool IsOccupated { get; set; }
}