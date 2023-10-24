using Hotel.Interfaces;
using Hotel.Models;

namespace Hotel.Services;

public class RoomsService : IRoomsService
{
    private readonly DataContext context;

    public RoomsService(DataContext context)
    {
        this.context = context;
    }

    public List<Room> ShowAllRooms() => context.Rooms.ToList();

    public async Task<Room> AddNewRoom(NewRoomRequest newRoomReq)
    {
        var room = new Room
        {
            Number = newRoomReq.Number,
            HaveConditioner = newRoomReq.HaveConditioner,
            HaveKitchen = newRoomReq.HaveKitchen,
            IsOccupated = newRoomReq.IsOccupated
        };
        await context.AddAsync(room);
        await context.SaveChangesAsync();
        return room;
    }

    public async Task<Room> BookARoom(int id)
    {
        var wantedRoom = context.Find<Room>(id);
        if (wantedRoom.IsOccupated)
        {
            throw new ArgumentException("We're sorry, but the room is already occupied. Please, choose another one");
        }

        wantedRoom.IsOccupated = true;
        await context.SaveChangesAsync();
        return wantedRoom;
    }

    public void DeleteRoom(int id)
    {
        context.Rooms.Remove(context.Find<Room>(id));
        context.SaveChanges();
    }
}
