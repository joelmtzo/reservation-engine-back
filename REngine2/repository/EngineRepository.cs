using Microsoft.EntityFrameworkCore;
using REngine2.config;
using REngine2.dto;
using REngine2.model;

namespace REngine2.repository;

public class EngineRepository(REngineDbContext context)
{
    public Reservation CreateReservation(CreateReservationRequest request)
    {
        if (request.CheckoutDate < request.CheckinDate)
        {
            throw new Exception("Checkout date must be after checkin date");
        }
        
        if(request.CheckinDate.CompareTo(DateTime.Now.Date) < 0)
        {
            throw new Exception("Checkin date must be in the future");
        }
        
        var result = FindAvailableRoom(request.CheckinDate, request.CheckoutDate, request.HotelId, request.RoomType).Result;
        
        if (result == null)
        {
            throw new Exception("No available rooms found");
        }
        
        var reservation = new Reservation
        {
            CustomerId = request.CustomerId,
            CheckinDate = request.CheckinDate,
            CheckoutDate = request.CheckoutDate,
            HotelRoomId = result.HotelRoomId,
            Status = "PENDING",
            PaymentMethod = "CASH",
            TotalPayment = ((request.CheckoutDate - request.CheckinDate).Days - 1) * result.PricePerNight,
        };
        
        context.Reservations.Add(reservation);
        context.SaveChanges();

        return reservation;
    }

    public dynamic FindAvailableRoom(DateTime checkinDate, DateTime checkoutDate, int desiredHotelId, string roomType)
    {
        var query = from h in context.Hotels
            join hr in context.HotelRooms on h.Id equals hr.HotelId
            join rm in context.Rooms on hr.RoomId equals rm.Id
            join r in context.Reservations on hr.Id equals r.HotelRoomId into reservations
            from r in reservations
                 .Where(res => (res.CheckinDate <= checkinDate && res.CheckoutDate > checkinDate) ||
                               (res.CheckinDate < checkoutDate && res.CheckoutDate >= checkoutDate) ||
                               (res.CheckinDate >= checkinDate && res.CheckoutDate <= checkoutDate))
                 .DefaultIfEmpty()
            where r == null && h.Id == desiredHotelId && rm.RoomType == roomType
            select new
            {
                HotelRoomId = hr.Id,
                RoomType = rm.RoomType,
                Capacity = rm.Capacity,
                PricePerNight = rm.PricePerNight
            };
        
        return query.FirstAsync();
    }
    public IEnumerable<dynamic> Search(DateTime checkinDate, DateTime checkoutDate, int desiredHotelId)
    {   
        if (checkoutDate < checkinDate)
        {
            throw new Exception("Checkout date must be after checkin date");
        }
        
        if(checkinDate.CompareTo(DateTime.Now.Date) < 0)
        {
            throw new Exception("Checkin date must be in the future");
        }
        
        var query = from h in context.Hotels
            join hr in context.HotelRooms on h.Id equals hr.HotelId
            join rm in context.Rooms on hr.RoomId equals rm.Id
            join r in context.Reservations on hr.Id equals r.HotelRoomId into reservations
            from r in reservations
                 .Where(res => (res.CheckinDate <= checkinDate && res.CheckoutDate > checkinDate) ||
                               (res.CheckinDate < checkoutDate && res.CheckoutDate >= checkoutDate) ||
                               (res.CheckinDate >= checkinDate && res.CheckoutDate <= checkoutDate))
                 .DefaultIfEmpty()
            where r == null && h.Id == desiredHotelId
            group new { h.City, rm.RoomType, rm.Capacity, rm.PricePerNight } by h.Name into hotelGroup
            select new
            {
                HotelName = hotelGroup.Key,
                City = hotelGroup.Select(hotel => hotel.City).First(),
                TotalDays = (checkoutDate - checkinDate).Days - 1,
                Rooms = hotelGroup.Select(room => new
                {
                    RoomType = room.RoomType,
                    Capacity = room.Capacity,
                    PricePerNight = room.PricePerNight
                }).Distinct()
            };        

        var result = query.ToList();

        return result;
    }
}