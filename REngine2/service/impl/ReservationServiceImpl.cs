using REngine2.dto;
using REngine2.model;
using REngine2.repository;

namespace REngine2.service.impl;

public class ReservationServiceImpl : IReservationService
{
    private readonly ReservationRepository _reservationRepository;
    
    public ReservationServiceImpl(ReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }
    
    public List<ReservationResponse> GetAllReservations()
    {
        return _reservationRepository.GetAllReservations();
    }

    public Reservation GetReservationById(int id)
    {
        return _reservationRepository.GetReservationById(id);
    }

    public Reservation CreateReservation(Reservation reservation)
    {
        return _reservationRepository.CreateReservation(reservation);
    }

    public Reservation UpdateReservation(int id, Reservation reservation)
    {
        return _reservationRepository.UpdateReservation(reservation);
    }
}