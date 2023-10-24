namespace Hotel.Models;

public class NewOrderRequest
{
    public int RoomId { get; set; }
    public int VisitorId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime LeavingDate { get; set; }
}