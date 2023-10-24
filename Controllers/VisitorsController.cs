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
        context = visitorsService;
    }

    private readonly IVisitorsService context;


    [HttpGet]
    public IActionResult ShowAllVisitors()
    {
        List<Visitor> visitors = context.ShowAllVisitors();
        return Ok(visitors);
    }
    [HttpPost]
    public async Task<Visitor> NewVisitor(NewVisitorRequest request) => await context.NewVisitor(request);

    [HttpDelete]
    public void DeleteVisitor(int id) => context.DeleteVisitor(id);
}
