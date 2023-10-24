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
    private readonly IOrdersService context;
    public OrdersController(IOrdersService context)
    {
        this.context = context;

    }

    [HttpGet]
    public List<Order> ShowAllOrders()
    {
        var orders = context.ShowAllOrders();
        return orders;
    }
    [HttpPost]
    public async Task<Order> MakeAnOrder(NewOrderRequest req) => await context.MakeAnOrder(req);

}
