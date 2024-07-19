using Microsoft.AspNetCore.Mvc;
using REngine2.model;
using REngine2.service;

namespace REngine2.controller;

[Route("api/[controller]")]
[ApiController]
public class HotelController : ControllerBase
{
    private readonly IHotelService _hotelService;

    public HotelController(IHotelService hotelService)
    {
        this._hotelService = hotelService;
    }
    
    [HttpGet]
    public IActionResult GetHotels()
    {
        return Ok(_hotelService.GetHotels());
    }
    
    [HttpGet("{id}")]
    public IActionResult GetHotel(int id)
    {
        return Ok(_hotelService.GetHotel(id));
    }
    
    [HttpPost]
    public IActionResult AddHotel([FromBody] Hotel hotel)
    {
        return Ok(_hotelService.AddHotel(hotel));
    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateHotel(int id, [FromBody] Hotel hotel)
    {
        return Ok(_hotelService.UpdateHotel(id, hotel));
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteHotel(int id)
    {
        return NoContent();
    }
}