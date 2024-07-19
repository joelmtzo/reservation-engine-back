using Microsoft.AspNetCore.Mvc;
using REngine2.model;
using REngine2.service;

namespace REngine2.controller;

[Route("api/[controller]")]
[ApiController]
public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService;
    
    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }
    
    [HttpGet]
    public IActionResult GetRooms()
    {
        return Ok(_roomService.GetRooms());
    }
    
    [HttpGet("{id}")]
    public IActionResult GetRoom(int id)
    {
        return Ok(_roomService.GetRoom(id));
    }
    
    [HttpPost]
    public IActionResult AddRoom([FromBody] Room room)
    {
        return Ok(_roomService.AddRoom(room));
    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateRoom(int id, [FromBody] Room room)
    {
        return Ok(_roomService.UpdateRoom(id, room));
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteRoom(int id)
    {
        return NoContent();
    }
}