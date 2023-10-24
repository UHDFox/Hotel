using Hotel.Interfaces;
using Hotel.Models;

namespace Hotel.Services;

public class VisitorsService : IVisitorsService
{
    private readonly DataContext context;

    public VisitorsService(DataContext context)
    {
        this.context = context;
    }

    public List<Visitor> ShowAllVisitors() => context.Visitors.ToList();

    public async Task<Visitor> NewVisitor(NewVisitorRequest request)
    {
        var newVisitor = new Visitor
        {
            Name = request.Name,
            Surname = request.Surname,
            Sex = request.Sex,
            PhoneNumber = request.PhoneNumber
        };
        var tracking = await context.Visitors.AddAsync(newVisitor);
        await context.SaveChangesAsync();
        return tracking.Entity;
    }

    public void DeleteVisitor(int id)
    {
        context.Visitors.Remove(context.Find<Visitor>(id));
        context.SaveChanges();
    }
}
