namespace CoorporateHotelKata.Tests;

public class AcceptanceTests
{
    [Fact(DisplayName = "Hotel Manager: Set all the different types of rooms and respective quantities for her hotel.")]
    public void Test1()
    {
        HotelService hotelService = new HotelService(new InMemoryHotelRepository());
        
        int hotelId = 0;
        string hotelName = "hotel";
        hotelService.addHotel(hotelId, hotelName);
        
        int number = 0;
        object roomType = null;
        hotelService.setRoom(hotelId, number, roomType);
        
        Room expectedRoom = null;
        Assert.Equal(expectedRoom, hotelService.findHotelBy(hotelId).rooms.First());
    }
}