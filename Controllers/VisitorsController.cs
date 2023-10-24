using Microsoft.AspNetCore.Mvc;
using Hotel.Models;
using Hotel.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Hotel.Controllers;

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