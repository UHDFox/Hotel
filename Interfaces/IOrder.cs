using Hotel.Models;

namespace Hotel.Interfaces;

public interface IOrdersService
{
    public List<Order> ShowAllOrders();
    public Task<Order> MakeAnOrder(NewOrderRequest req);
}
