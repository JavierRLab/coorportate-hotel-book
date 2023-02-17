namespace CoorporateHotelKata.Tests;

public class HotelService
{
    private IHotelRepository hotelRepo;

    public HotelService(IHotelRepository hotelRepo)
    {
        this.hotelRepo = hotelRepo;
    }

    public Hotel findHotelBy(int hotelId)
    {
        throw new NotImplementedException();
    }

    public void addHotel(int hotelId, string hotelName)
    {
        throw new NotImplementedException();
    }

    public void setRoom(int hotelId, int number, object roomType)
    {
        throw new NotImplementedException();
    }
}

public class Hotel
{
    private int hotelId;
    private string name;
    public List<Room> rooms { get; }
    
}

public record Room
{
    
}