using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel.Models;
using Hotel.Services;
using Hotel.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Hotel.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VisitorsController : Controller
    {
        public VisitorsController(IVisitorsService visitorsService)
        {
            _context = visitorsService;
        }
        IVisitorsService _context;
        

        [HttpGet]
        public IActionResult ShowAllVisitors()
        {
            List<Visitor> visitors = _context.ShowAllVisitors();
            return Ok(visitors);
        }
        [HttpPost]
        public async Task<Visitor> NewVisitor(NewVisitorRequest request) => await _context.NewVisitor(request);

        [HttpDelete]
        public void DeleteVisitor(int id) => _context.DeleteVisitor(id);
        
    }
    
}








/*namespace WebApplication2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VisitorsController : Controller
    {
        private readonly DataContext _context;
        public VisitorsController(DataContext context) { _context = context; }
            

        [HttpGet]
        public IActionResult ShowAllVisitors()
        {
            return Ok(_context.Visitors.ToList());
        }
        [HttpPost]  
        public async Task<ActionResult<Visitor>> NewVisitor(NewVisitorRequest request)
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
            return Ok(newVisitor);
        }
    }
    
}*/