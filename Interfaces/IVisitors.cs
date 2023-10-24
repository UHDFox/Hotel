using Hotel.Models;

namespace Hotel.Interfaces;

public interface IVisitorsService
{
    List<Visitor> ShowAllVisitors();
    Task<Visitor> NewVisitor(NewVisitorRequest request);
    void DeleteVisitor(int id);
}