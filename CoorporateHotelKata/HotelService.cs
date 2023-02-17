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

    public void setRoom(int hotelId, int number, object roomType)
    {
        throw new NotImplementedException();
    }
}