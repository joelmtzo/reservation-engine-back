using REngine2.model;

namespace REngine2.service;

public interface IRoomService
{
    List<Room> GetRooms();
    Room GetRoom(int id);
    Room AddRoom(Room room);
    Room UpdateRoom(int id, Room room);
    void DeleteRoom(int id);
}