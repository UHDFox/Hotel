using Microsoft.AspNetCore.Mvc;
using Hotel.Models;
using Microsoft.Identity.Client;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;
using Hotel.Interfaces;
namespace Hotel.Services;

public class RoomsService : IRoomsService
{
    private readonly DataContext _context;
    public RoomsService(DataContext context)
    {
        _context = context;
    }
    public List<Room> ShowAllRooms()
    {
        return _context.Rooms.ToList();
            
    }
    public async Task<Room> AddNewRoom(NewRoomRequest newRoomReq)
    {

        Room room = new Room()
        {
            Number = newRoomReq.Number,
            HaveConditioner = newRoomReq.HaveConditioner,
            HaveKitchen = newRoomReq.HaveKitchen,
            IsOccupated = newRoomReq.IsOccupated
        };
        var tracking = await _context.AddAsync(room);
        await _context.SaveChangesAsync();
        return room;
    }

    public async Task<Room> BookARoom(int id)
    {
        var wantedRoom = _context.Find<Room>(id);
        if (wantedRoom.IsOccupated == true)
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

    public void DeleteRoom(int id)
    {
        _context.Rooms.Remove(_context.Find<Room>(id));
        _context.SaveChanges();

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
