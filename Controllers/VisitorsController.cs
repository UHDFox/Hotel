using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel.Controllers.Services;
using Hotel.Models;

namespace Hotel.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VisitorsController : Controller
    {
        public VisitorsController(IVisitorsService visitorsService)
        {
            _visitorsService = visitorsService;
        }
        IVisitorsService _visitorsService;
        

        [HttpGet]
        public IActionResult ShowAllVisitors()
        {
            List<Visitor> visitors = _visitorsService.ShowAllVisitors();
            return Ok(visitors);
        }
        [HttpPost]
        public async Task<Visitor> NewVisitor(NewVisitorRequest request) => await _visitorsService.NewVisitor(request);
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