namespace CoorporateHotelKata.Tests;

public class HotelServiceShould
{
    [Fact]
    public void FindAHotel()
    {
        IHotelRepository hotelRepo = new InMemoryHotelRepository();
        var hotelService = new HotelService(hotelRepo);
        
        int hotelId = 0;
        string hotelName = "hotel";
        hotelRepo.AddHotel(hotelId, hotelName);

        var actualHotel = hotelService.findHotelBy(hotelId);

        Assert.NotNull(actualHotel);
        Assert.Equal(hotelId, actualHotel.hotelId);
        Assert.Equal(hotelName, actualHotel.name);
    }
    // [Fact]
    // public void AddAHotel()
    // {
    //     var hotelService = new HotelService();
    //     hotelService.addHotel();
    //     
    //     Assert.Equal(expec);
    // }
}