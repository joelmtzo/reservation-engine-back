using REngine2.config;
using REngine2.model;

namespace REngine2.repository;

public class HotelRepository
{
    private readonly REngineDbContext _dbContext;

    public HotelRepository(REngineDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public List<Hotel> GetHotels()
    {
        return _dbContext.Hotels.ToList();
    }
    
    public Hotel GetHotel(int id)
    {
        return _dbContext.Hotels.Find(id);
    }
    
    public Hotel AddHotel(Hotel hotel)
    {
        _dbContext.Hotels.Add(hotel);
        _dbContext.SaveChanges();
        return hotel;
    }
    
    public Hotel UpdateHotel(int id, Hotel hotel)
    {
        var existingHotel = _dbContext.Hotels.Find(id);
        
        if (existingHotel == null) return existingHotel;
        
        existingHotel.Name = hotel.Name;
        existingHotel.Address = hotel.Address;
        existingHotel.City = hotel.City;
        existingHotel.State = hotel.State;
        _dbContext.Hotels.Update(existingHotel);
        _dbContext.SaveChanges();
        
        return existingHotel;
    }
    
    public void DeleteHotel(int id)
    {
        var hotel = _dbContext.Hotels.Find(id);
        
        if (hotel == null) return;
        
        _dbContext.Hotels.Remove(hotel);
        _dbContext.SaveChanges();
    }
}