namespace REngine2.model;

public class Hotel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public ICollection<HotelRoom> HotelRooms { get; set; }
}