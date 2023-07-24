using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel.Controllers.Services;
using Hotel.Models;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Hotel.Controllers
{
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
    }
    
}