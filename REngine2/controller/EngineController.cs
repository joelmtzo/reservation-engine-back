using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using REngine2.dto;
using REngine2.repository;

namespace REngine2.controller;

[Route("api/[controller]")]
[ApiController]
public class EngineController(EngineRepository engineRepository) : ControllerBase
{
    [HttpGet]
    public IActionResult Search(DateTime checkinDate, DateTime checkoutDate, int desiredHotelId)
    {
        var available = engineRepository.Search(checkinDate, checkoutDate, desiredHotelId);
        
        if (!available.Any())
        {
            return StatusCode(204);            
        }
        
        return Ok(available);  
    }
    
    [HttpPost]
    public IActionResult CreateReservation([FromBody] CreateReservationRequest request)
    {
        return Ok(engineRepository.CreateReservation(request));
    }
}