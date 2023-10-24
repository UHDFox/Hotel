using Hotel.Models;
using Hotel.Services;

namespace Hotel.Interfaces;

public interface IRoomsService
{
    public List<Room> ShowAllRooms();
    public Task<Room> AddNewRoom(NewRoomRequest newRoomReq);
    public Task<Room> BookARoom(int id);
    public void DeleteRoom(int id);
}