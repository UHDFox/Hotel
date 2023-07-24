using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel.Models;

namespace Hotel.Controllers.Services
{

    public interface IVisitorsService
    {
        List<Visitor> ShowAllVisitors();
        Task<Visitor> NewVisitor(NewVisitorRequest request);
    }
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
            await _context.Visitors.AddAsync(newVisitor);
            _context.SaveChangesAsync();
            return newVisitor;
        }
    }
}
