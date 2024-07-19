using REngine2.config;
using REngine2.dto;
using REngine2.model;

namespace REngine2.repository;

public class ReservationRepository
{
    private readonly REngineDbContext _context;
    
    public ReservationRepository(REngineDbContext context)
    {
        _context = context;
    }
    
    public List<ReservationResponse> GetAllReservations()
    {
        var query = from res in _context.Reservations
            join c in _context.Customers on res.CustomerId equals c.Id
            join hr in _context.HotelRooms on res.HotelRoomId equals hr.Id
            join h in _context.Hotels on hr.HotelId equals h.Id
            join r in _context.Rooms on hr.RoomId equals r.Id
            select new ReservationResponse()
            {
                CustomerFirstName = c.FirstName,
                CustomerLastName = c.LastName,
                HotelName = h.Name,
                RoomType = r.RoomType,
                HotelRoomId = res.HotelRoomId,
                CheckinDate = res.CheckinDate,
                CheckoutDate = res.CheckoutDate,
                Status = res.Status,
                TotalPayment = res.TotalPayment
            };
        
        return query.ToList();
    }
    
    public Reservation GetReservationById(int id)
    {
        return _context.Reservations.Find(id);
    }
    
    public Reservation CreateReservation(Reservation reservation)
    {
        _context.Reservations.Add(reservation);
        _context.SaveChanges();
        return reservation;
    }
    
    public Reservation UpdateReservation(Reservation reservation)
    {
        _context.Reservations.Update(reservation);
        _context.SaveChanges();
        return reservation;
    }

}