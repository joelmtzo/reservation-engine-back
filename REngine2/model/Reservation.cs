using System.ComponentModel.DataAnnotations.Schema;

namespace REngine2.model;

public class Reservation
{
    public int Id { get; set; }
    [Column("customer_id")]
    public int CustomerId { get; set; }
    [Column("hotel_room_id")]
    public int HotelRoomId { get; set; }
    [Column("checkin_date")]
    public DateTime CheckinDate { get; set; }
    [Column("checkout_date")]
    public DateTime CheckoutDate { get; set; }
    public string Status { get; set; }
    [Column("payment_method")]
    public string PaymentMethod { get; set; }
    [Column("total_payment")]
    public decimal TotalPayment { get; set; }
}