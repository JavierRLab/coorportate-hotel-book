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

        var actualHotel = hotelService.FindHotelBy(hotelId);

        Assert.NotNull(actualHotel);
        Assert.Equal(hotelId, actualHotel.hotelId);
        Assert.Equal(hotelName, actualHotel.name);
    }
    
    [Fact]
    public void ThrowExceptionWhenAddingExistingHotel()
    {
        IHotelRepository hotelRepo = new InMemoryHotelRepository();
        var hotelService = new HotelService(hotelRepo);
        
        int hotelId = 0;
        string hotelName = "hotel";
        hotelRepo.AddHotel(hotelId, hotelName);

        Assert.Throws<HotelExistsException>(() => hotelService.AddHotel(hotelId, hotelName));
    }
    
    [Fact]
    public void CreateAHotel()
    {
        IHotelRepository hotelRepo = new InMemoryHotelRepository();
        var hotelService = new HotelService(hotelRepo);
        
        int hotelId = 0;
        string hotelName = "hotel";
        hotelService.AddHotel(hotelId, hotelName);

        
        var actualHotel = hotelRepo.FindHotelBy(hotelId);

        Assert.NotNull(actualHotel);
        Assert.Equal(hotelId, actualHotel.hotelId);
        Assert.Equal(hotelName, actualHotel.name);
    }
}