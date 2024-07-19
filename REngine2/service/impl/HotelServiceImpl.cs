using REngine2.model;
using REngine2.repository;

namespace REngine2.service.impl;

public class HotelServiceImpl : IHotelService
{
    private readonly HotelRepository _hotelRepository;

    public HotelServiceImpl(HotelRepository hotelRepository)
    {
        this._hotelRepository = hotelRepository;
    }

    public List<Hotel> GetHotels()
    {
        return _hotelRepository.GetHotels();
    }

    public Hotel GetHotel(int id)
    {
        return _hotelRepository.GetHotel(id);
    }

    public Hotel AddHotel(Hotel hotel)
    {
        return _hotelRepository.AddHotel(hotel);
    }

    public Hotel UpdateHotel(int id, Hotel hotel)
    {
        return _hotelRepository.UpdateHotel(id, hotel);
    }

    public void DeleteHotel(int id)
    {
        _hotelRepository.DeleteHotel(id);
    }
}
