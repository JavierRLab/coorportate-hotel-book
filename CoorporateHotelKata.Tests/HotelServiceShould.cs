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
        Assert.Equal(hotelId, actualHotel.HotelId);
        Assert.Equal(hotelName, actualHotel.Name);
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
        Assert.Equal(hotelId, actualHotel.HotelId);
        Assert.Equal(hotelName, actualHotel.Name);
    }
    
    [Fact]
    public void ThrowExceptionWhenSettingRoomAndHotelDoesNotExist()
    {
        IHotelRepository hotelRepo = new InMemoryHotelRepository();
        var hotelService = new HotelService(hotelRepo);
        
        int hotelId = 0;
        int roomNumber = 123;
        RoomType roomType = RoomType.StandardSingle;
        
        Assert.Throws<HotelNotExistsException>(() => hotelService.SetRoom(hotelId, roomNumber, roomType));
    }
    
    [Fact]
    public void CreateARoom()
    {
        IHotelRepository hotelRepo = new InMemoryHotelRepository();
        var hotelService = new HotelService(hotelRepo);
        int hotelId = 0;
        string hotelName = "hotel";
        hotelRepo.AddHotel(hotelId, hotelName);
        int roomNumber = 123;
        RoomType roomType = RoomType.StandardSingle;

        hotelService.SetRoom(hotelId, roomNumber, roomType);

        var actualHotel = hotelRepo.FindHotelBy(hotelId);
        Assert.NotNull(actualHotel);
        var actualRoom = actualHotel!.FindRoomBy(roomNumber);
        Assert.NotNull(actualRoom);
        Assert.Equal(roomNumber, actualRoom!.Number);
        Assert.Equal(roomType, actualRoom.RoomType);
    }
    
    [Fact]
    public void UpdateARoom()
    {
        IHotelRepository hotelRepo = new InMemoryHotelRepository();
        var hotelService = new HotelService(hotelRepo);
        int hotelId = 0;
        string hotelName = "hotel";
        hotelRepo.AddHotel(hotelId, hotelName);
        int roomNumber = 123;

        hotelService.SetRoom(hotelId, roomNumber, RoomType.StandardSingle);
        hotelService.SetRoom(hotelId, roomNumber, RoomType.StandardDouble);

        var actualHotel = hotelRepo.FindHotelBy(hotelId);
        Assert.NotNull(actualHotel);
        var actualRoom = actualHotel!.FindRoomBy(roomNumber);
        Assert.NotNull(actualRoom);
        Assert.Equal(roomNumber, actualRoom!.Number);
        Assert.Equal(RoomType.StandardDouble, actualRoom.RoomType);
    }
}