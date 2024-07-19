using REngine2.model;

namespace REngine2.service;

public interface IHotelService
{
    public List<Hotel> GetHotels();
    public Hotel GetHotel(int id);
    public Hotel AddHotel(Hotel hotel);
    public Hotel UpdateHotel(int id, Hotel hotel);
    public void DeleteHotel(int id);
}