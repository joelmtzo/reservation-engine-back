namespace REngine2.dto;

public class CreateReservationRequest
{
    public int CustomerId { get; set; }
    public DateTime CheckinDate { get; set; }
    public DateTime CheckoutDate { get; set; }
    public int HotelId { get; set; }
    public string RoomType { get; set; }
}