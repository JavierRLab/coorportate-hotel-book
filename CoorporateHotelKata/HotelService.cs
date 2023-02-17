namespace CoorporateHotelKata;

public class HotelService
{
    private IHotelRepository hotelRepo;

    public HotelService(IHotelRepository hotelRepo)
    {
        this.hotelRepo = hotelRepo;
    }

    public Hotel? FindHotelBy(int hotelId)
    {
        return hotelRepo.FindHotelBy(hotelId);
    }

    public void AddHotel(int hotelId, string hotelName)
    {
        if (hotelRepo.FindHotelBy(hotelId) is not null)
        {
            throw new HotelExistsException($"A hotel with ID: {hotelId} already exists.");
        }
        hotelRepo.AddHotel(hotelId, hotelName);
    }

    public void SetRoom(int hotelId, int number, RoomType roomType)
    {
        var hotel = hotelRepo.FindHotelBy(hotelId);
        if (hotel is null)
        {
            throw new HotelNotExistsException($"A hotel with ID: {hotelId} does not exist.");
        }

        hotel.SetRoom(number, roomType);
    }
}

public enum RoomType
{
    StandardSingle,
    StandardDouble,
    StandardSuite,
    JuniorSuite
}