using Hotel.Interfaces;
using Hotel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers;

[Authorize]
[Route("api/[Controller]/[action]")]
[ApiController]
public sealed class OrdersController : Controller
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
