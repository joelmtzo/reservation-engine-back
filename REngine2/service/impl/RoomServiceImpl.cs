using REngine2.model;
using REngine2.repository;

namespace REngine2.service.impl;

public class RoomServiceImpl : IRoomService
{
    private RoomRepository _roomRepository;

    public RoomServiceImpl(RoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public List<Room> GetRooms()
    {
        return _roomRepository.GetRooms();
    }

    public Room GetRoom(int id)
    
    {
        return _roomRepository.GetRoom(id);
    }

    public Room AddRoom(Room room)
    {
        return _roomRepository.AddRoom(room);
    }

    public Room UpdateRoom(int id, Room room)
    {
        return _roomRepository.UpdateRoom(id, room);
    }

    public void DeleteRoom(int id)
    {
        _roomRepository.DeleteRoom(id);
    }
}