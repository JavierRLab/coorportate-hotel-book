using AutoFixture.Xunit2;

namespace CoorporateHotelKata.Tests;

public class HotelServiceShould
{
    private readonly IHotelRepository _hotelRepo;
    private readonly HotelService _hotelService;

    public HotelServiceShould()
    {
        _hotelRepo = new InMemoryHotelRepository();
        _hotelService = new HotelService(_hotelRepo);
    }

    [Theory]
    [InlineAutoData]
    public void FindAHotel(Hotel hotel)
    {
        _hotelRepo.AddHotel(hotel.HotelId, hotel.Name);

        var actualHotel = _hotelService.FindHotelBy(hotel.HotelId);

        Assert.NotNull(actualHotel);
        Assert.Equal(hotel.HotelId, actualHotel!.HotelId);
        Assert.Equal(hotel.Name, actualHotel.Name);
    }
    
    [Theory]
    [InlineAutoData]
    public void ThrowExceptionWhenAddingExistingHotel(Hotel hotel)
    {
        _hotelRepo.AddHotel(hotel.HotelId, hotel.Name);

        Assert.Throws<HotelExistsException>(() => _hotelService.AddHotel(hotel.HotelId, hotel.Name));
    }
    
    [Theory]
    [InlineAutoData]
    public void CreateAHotel(Hotel hotel)
    {
        
        _hotelService.AddHotel(hotel.HotelId, hotel.Name);

        
        var actualHotel = _hotelRepo.FindHotelBy(hotel.HotelId);

        Assert.NotNull(actualHotel);
        Assert.Equal(hotel.HotelId, actualHotel!.HotelId);
        Assert.Equal(hotel.Name, actualHotel.Name);
    }
    
    [Theory]
    [InlineAutoData]
    public void ThrowExceptionWhenSettingRoomAndHotelDoesNotExist(int hotelId, Room room)
    {
        Assert.Throws<HotelNotExistsException>(() => _hotelService.SetRoom(hotelId, room.Number, room.RoomType));
    }
    
    [Theory]
    [InlineAutoData]
    public void CreateARoom(Hotel hotel, Room room)
    {
        _hotelRepo.AddHotel(hotel.HotelId, hotel.Name);

        _hotelService.SetRoom(hotel.HotelId, room.Number, room.RoomType);

        var actualHotel = _hotelRepo.FindHotelBy(hotel.HotelId);
        Assert.NotNull(actualHotel);
        var actualRoom = actualHotel!.FindRoomBy(room.Number);
        Assert.Equal(room, actualRoom);
    }
    
    [Theory]
    [InlineAutoData]
    public void UpdateARoom(Hotel hotel, int roomNumber)
    {
        _hotelRepo.AddHotel(hotel.HotelId, hotel.Name);

        _hotelService.SetRoom(hotel.HotelId, roomNumber, RoomType.StandardSingle);
        _hotelService.SetRoom(hotel.HotelId, roomNumber, RoomType.StandardDouble);

        var actualHotel = _hotelRepo.FindHotelBy(hotel.HotelId);
        Assert.NotNull(actualHotel);
        var actualRoom = actualHotel!.FindRoomBy(roomNumber);
        Assert.Equal(new Room(roomNumber, RoomType.StandardDouble), actualRoom);
    }
}