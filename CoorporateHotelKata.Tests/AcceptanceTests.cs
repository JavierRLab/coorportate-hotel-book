namespace CoorporateHotelKata.Tests;

public class AcceptanceTests
{
    [Fact(DisplayName = "Hotel Manager: Set all the different types of rooms and respective quantities for her hotel.")]
    public void Test1()
    {
        HotelService hotelService = new HotelService(new InMemoryHotelRepository());
        int hotelId = 0;
        string hotelName = "hotel";
        hotelService.AddHotel(hotelId, hotelName);
        int roomNumber = 123;
        RoomType roomType = RoomType.JuniorSuite;
        
        hotelService.SetRoom(hotelId, roomNumber, roomType);
        
        var actualHotel = hotelService.FindHotelBy(hotelId);
        Assert.NotNull(actualHotel);
        var actualRoom = actualHotel!.FindRoomBy(roomNumber);
        Assert.NotNull(actualRoom);
        Assert.Equal(roomNumber, actualRoom.Number);
        Assert.Equal(roomType, actualRoom.RoomType);
    }
}