namespace REngine2.dto;
    
public class ReservationResponse
{
    public string CustomerFirstName { get; set; }
    public string CustomerLastName { get; set; }
    public string HotelName { get; set; }
    public string RoomType { get; set; }
    public int HotelRoomId { get; set; }
    public DateTime CheckinDate { get; set; }
    public DateTime CheckoutDate { get; set; }
    public string Status { get; set; }
    public decimal TotalPayment { get; set; }
}