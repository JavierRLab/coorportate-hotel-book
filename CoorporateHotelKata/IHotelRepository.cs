namespace CoorporateHotelKata;

public interface IHotelRepository
{
    void AddHotel(int hotelId, string hotelName);

    Hotel? GetHotel(int hotelId);
}

public class InMemoryHotelRepository : IHotelRepository
{
    private Dictionary<int, Hotel> hotels = new();

    public void AddHotel(int hotelId, string hotelName)
    {
        hotels.Add(hotelId, new Hotel(){hotelId = hotelId, name = hotelName});
    }

    public Hotel? GetHotel(int hotelId)
    {
        if (hotels.TryGetValue(hotelId, out var hotel))
            return hotel;
        return null;
    }
}