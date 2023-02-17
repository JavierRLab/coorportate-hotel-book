namespace CoorporateHotelKata;

public class HotelService
{
    private IHotelRepository hotelRepo;

    public HotelService(IHotelRepository hotelRepo)
    {
        this.hotelRepo = hotelRepo;
    }

    public Hotel? findHotelBy(int hotelId)
    {
        return hotelRepo.GetHotel(hotelId);
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