using Microsoft.AspNetCore.Mvc;
using Hotel.Models;
using Hotel.Controllers.Services;
using Microsoft.Identity.Client;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Controllers.Services
{

    public interface IRoomsService
    {
        public List<Room> ShowAllRooms();
        public Task<Room> AddNewRoom(NewRoomRequest newRoomReq);
        public Task<Room> BookARoom(int id);
    }
    public class RoomsService : IRoomsService
    {
        private readonly DataContext _context;
        public RoomsService(DataContext context)
        {
            _context = context;
        }
        public List<Room> ShowAllRooms()
        {
            return (_context.Rooms.ToList());
        }
        public async Task<Room> AddNewRoom(NewRoomRequest newRoomReq)
        {

            Room room = new Room()
            {
                Numb = newRoomReq.Numb,
                HaveConditioner = newRoomReq.HaveConditioner,
                HaveKitchen = newRoomReq.HaveKitchen,
                IsOccupated = newRoomReq.IsOccupated
            };
           await _context.AddAsync(room);
            _context.SaveChangesAsync();
            return room;
        }

        public async Task<Room> BookARoom(int id)
        {
            var wantedRoom = _context.Find<Room>(id);
            if(wantedRoom.IsOccupated == true)
            {
                
                throw new ArgumentException("We're sorry, but the room is already occupied. Please, choose another one");
            }
            else
            {
                wantedRoom.IsOccupated = true;
            }
            await _context.SaveChangesAsync();
            return wantedRoom;
        }


    }
}


/*public int ID { get; set; }
        public enum RoomType
        {
            Standart,
            Superior,
            Studio,
            Suite,
            Duplex
        };
        public bool HaveConditioner { get; set; }
        public bool HaveKitchen { get; set; }
        public bool IsOccupated { get; set; }*/
