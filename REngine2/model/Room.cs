using System.ComponentModel.DataAnnotations.Schema;

namespace REngine2.model;

public class Room
{
    public int Id { get; set; }
    
    [Column("room_type")]
    public string RoomType { get; set; }
    public int Capacity { get; set; }
    
    [Column("price_per_night")]
    public decimal PricePerNight { get; set; }
}