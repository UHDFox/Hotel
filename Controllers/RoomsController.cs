using Hotel.Interfaces;
using Hotel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers;

[Authorize]
[Route("api/[Controller]/[action]")]
[ApiController]
public class RoomsController : Controller
{
    private readonly IRoomsService context;

    public RoomsController(IRoomsService roomContext)
    {
        context = roomContext;
    }

    [HttpGet]
    public ActionResult ShowAllRooms()
    {
        var rooms = context.ShowAllRooms();
        return Ok(rooms);
    }

    [HttpPost]
    public async Task<Room> AddNewRoom(NewRoomRequest newRoomReq) => await context.AddNewRoom(newRoomReq);

    [HttpPut]
    public async Task<Room> BookARoom(int id) => await context.BookARoom(id);

    [HttpDelete]
    public void DeleteRoom(int id) => context.DeleteRoom(id);
}
