using System.ComponentModel.DataAnnotations.Schema;

namespace REngine2.model;

public class HotelRoom
{
    public int Id { get; set; }
    [Column("hotel_id")]
    public int HotelId { get; set; }
    [Column("room_id")]
    public int RoomId { get; set; }
    [Column("room_number_seq")]
    public int RoomNumberSeq { get; set; }
    public string Status { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
}