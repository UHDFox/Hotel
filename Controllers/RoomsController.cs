using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel.Models;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Hotel.Services;
using Hotel.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Hotel.Controllers;

[Authorize]
[Route("api/[Controller]/[action]")]
[ApiController]

public class RoomsController : Controller
{
    IRoomsService _context;
    public RoomsController(IRoomsService roomContext)
    {
        _context = roomContext;
    }

    [HttpGet]
    public ActionResult ShowAllRooms()
    {
        var rooms = _context.ShowAllRooms();
        return Ok(rooms);
    }

    [HttpPost]
    public async Task<Room> AddNewRoom(NewRoomRequest newRoomReq) => await _context.AddNewRoom(newRoomReq);
    [HttpPut]
    public async Task<Room> BookARoom(int id) => await _context.BookARoom(id);
    [HttpDelete]
    public  void DeleteRoom(int id) =>  _context.DeleteRoom(id);
}