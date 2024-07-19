using Microsoft.AspNetCore.Mvc;
using REngine2.model;
using REngine2.service;

namespace REngine2.controller;

[Route("api/[controller]")]
[ApiController]
public class ReservationController : ControllerBase
{
    private readonly IReservationService _reservationService;
    
    public ReservationController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }
    
    [HttpGet]
    public IActionResult GetReservations()
    {
        return Ok(_reservationService.GetAllReservations());
    }
    
    [HttpGet("{id}")]
    public IActionResult GetReservation(int id)
    {
        return Ok(_reservationService.GetReservationById(id));
    }
    
    [HttpPost]
    public IActionResult AddReservation([FromBody] Reservation reservation)
    {
        return Ok(_reservationService.CreateReservation(reservation));
    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateReservation(int id, [FromBody] Reservation reservation)
    {
        return Ok(_reservationService.UpdateReservation(id, reservation));
    }
    
}