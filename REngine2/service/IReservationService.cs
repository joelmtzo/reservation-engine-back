using REngine2.dto;
using REngine2.model;

namespace REngine2.service;

public interface IReservationService
{
    public List<ReservationResponse> GetAllReservations();
    
    public Reservation GetReservationById(int id);
    
    public Reservation CreateReservation(Reservation reservation);
    
    public Reservation UpdateReservation(int id, Reservation reservation);
}