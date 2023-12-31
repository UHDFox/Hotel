﻿using System.ComponentModel.DataAnnotations;

namespace Hotel.Models;

public sealed class Order
{
    [Key]
    public int Id { get; set; }

    public Room BookedRoom { get; set; }

    public int? RoomId { get; set; }

    public Visitor Visitor { get; set; }

    public int? VisitorId { get; set; }

    public DateTime CheckInDate { get; set; }

    public DateTime LeavingDate { get; set; }
}
