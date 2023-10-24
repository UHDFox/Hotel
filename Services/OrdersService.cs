using Hotel.Interfaces;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Services;

internal sealed class OrdersService : IOrdersService
{
    private readonly DataContext context;

    public OrdersService(DataContext context)
    {
        this.context = context;
    }

    public async Task<Order> MakeAnOrder(NewOrderRequest req)
    {
        var newOrder = new Order
        {
            BookedRoom = context.Find<Room>(req.RoomId),
            Visitor = context.Find<Visitor>(req.VisitorId),
            CheckInDate = req.CheckInDate,
            LeavingDate = req.LeavingDate
        };

        newOrder.BookedRoom.IsOccupated = true;

        var tracking = await context.AddAsync(newOrder);
        await context.SaveChangesAsync();
        return tracking.Entity;
    }

    public List<Order> ShowAllOrders() =>
        context.Orders
            .Include(v => v.Visitor)
            .Include(r => r.BookedRoom)
            .ToList();
}
