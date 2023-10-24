using Microsoft.AspNetCore.Mvc;
using Hotel.Interfaces;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Services;

public class OrdersService : IOrdersService
{
    private readonly DataContext _context;
    public OrdersService(DataContext context)
    {
        _context = context;
    }
    int id { get; set; }
    public async Task<Order> MakeAnOrder(NewOrderRequest req)
    {
        // Room ReqRoom = _context.Find<Room>(id);
        //Visitor newVisitor = _context.Find<Visitor>(id);


        Order newOrder = new Order()
        {
            BookedRoom = _context.Find<Room>(req.RoomId),
            Visitor = _context.Find<Visitor>(req.VisitorId),
            CheckInDate = req.CheckInDate,
            LeavingDate = req.LeavingDate
        };
        newOrder.BookedRoom.IsOccupated = true;
   
        var tracking = await _context.AddAsync(newOrder);
        await _context.SaveChangesAsync();
        return tracking.Entity;
    }
    public List<Order> ShowAllOrders()
    {
        return _context.Orders
            .Include(v => v.Visitor)
            .Include(r => r.BookedRoom)
            .ToList();
    }
}
/* public async Task<Order> MakeAnOrder(NewOrderRequest req)
        {
           // Room ReqRoom = _context.Find<Room>(id);
            //Visitor newVisitor = _context.Find<Visitor>(id);
            Order newOrder = new Order()
            {
                BookedRoom = _context.Find<Room>(req.RoomId),
                Visitor = _context.Find<Visitor>(req.VisitorId),
                CheckInDate = req.CheckInDate,
                LeavingDate = req.LeavingDate
            };
            var tracking = await _context.AddAsync(newOrder);
            await _context.SaveChangesAsync();
            return tracking.Entity;
        }*/


