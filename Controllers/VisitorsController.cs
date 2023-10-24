using Hotel.Interfaces;
using Hotel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers;

[Authorize]
[Route("api/[controller]/[action]")]
[ApiController]
public class VisitorsController : Controller
{
    private readonly IVisitorsService context;

    public VisitorsController(IVisitorsService visitorsService)
    {
        context = visitorsService;
    }

    [HttpGet]
    public IActionResult ShowAllVisitors()
    {
        var visitors = context.ShowAllVisitors();
        return Ok(visitors);
    }

    [HttpPost]
    public async Task<Visitor> NewVisitor(NewVisitorRequest request) => await context.NewVisitor(request);

    [HttpDelete]
    public void DeleteVisitor(int id) => context.DeleteVisitor(id);
}
