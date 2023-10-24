using Microsoft.AspNetCore.Mvc;
using Hotel.Models;
using Hotel.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Hotel.Controllers;

[Authorize]
[Route("api/[Controller]/[action]")]
[ApiController]
public class OrdersController : Controller
{
    IOrdersService _context;
    public OrdersController(IOrdersService context)
    {
        _context = context;
            
    }
        
    [HttpGet]
    public List<Order> ShowAllOrders()
    {
        var orders = _context.ShowAllOrders();
        return orders;
    }
    [HttpPost]
    public async Task<Order> MakeAnOrder(NewOrderRequest req) => await _context.MakeAnOrder(req);

}