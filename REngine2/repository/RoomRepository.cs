using REngine2.config;
using REngine2.model;

namespace REngine2.repository;

public class RoomRepository
{
    private readonly REngineDbContext _context;
    
    public RoomRepository(REngineDbContext context)
    {
        _context = context;
    }
    
    public List<Room> GetRooms()
    {
        return _context.Rooms.ToList();
    }
    
    public Room GetRoom(int id)
    {
        return _context.Rooms.Find(id);
    }
    
    public Room AddRoom(Room room)
    {
        _context.Rooms.Add(room);
        _context.SaveChanges();
        return room;
    }
    
    public Room UpdateRoom(int id, Room room)
    {
        _context.Rooms.Update(room);
        _context.SaveChanges();
        return room;
    }
    
    public void DeleteRoom(int id)
    {
        var room = _context.Rooms.Find(id);
        _context.Rooms.Remove(room);
        _context.SaveChanges();
    }
}