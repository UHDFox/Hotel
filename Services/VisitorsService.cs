using Hotel.Models;
using Hotel.Interfaces;
namespace Hotel.Services;

public class VisitorsService : IVisitorsService
{
    private readonly DataContext _context;
    public VisitorsService(DataContext context)
    {
        _context = context;
    }
    public List<Visitor> ShowAllVisitors()
    {
        return _context.Visitors.ToList();
    }
    public async Task<Visitor> NewVisitor(NewVisitorRequest request)
    {
        Visitor newVisitor = new Visitor()
        {

            Name = request.Name,
            Surname = request.Surname,
            Sex = request.Sex,
            PhoneNumber = request.PhoneNumber,
        };
        var tracking = await _context.Visitors.AddAsync(newVisitor);
        await _context.SaveChangesAsync();
        return tracking.Entity;
    }
    public void DeleteVisitor(int id)
    {
        _context.Visitors.Remove(_context.Find<Visitor>(id));
        _context.SaveChanges();
    }
}