using AutoFixture.Xunit2;

namespace CoorporateHotelKata.Tests;

public class HotelServiceShould
{
    private IHotelRepository _hotelRepo;
    private HotelService _hotelService;

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
        Assert.Equal(hotel.HotelId, actualHotel.HotelId);
        Assert.Equal(hotel.Name, actualHotel.Name);
    }
    
    [Theory]
    [InlineAutoData]
    public void ThrowExceptionWhenAddingExistingHotel(Hotel hotel)
    {
        IHotelRepository hotelRepo = new InMemoryHotelRepository();
        var hotelService = new HotelService(hotelRepo);
        
        hotelRepo.AddHotel(hotel.HotelId, hotel.Name);

        Assert.Throws<HotelExistsException>(() => hotelService.AddHotel(hotel.HotelId, hotel.Name));
    }
    
    [Theory]
    [InlineAutoData]
    public void CreateAHotel(Hotel hotel)
    {
        IHotelRepository hotelRepo = new InMemoryHotelRepository();
        var hotelService = new HotelService(hotelRepo);
        
        hotelService.AddHotel(hotel.HotelId, hotel.Name);

        
        var actualHotel = hotelRepo.FindHotelBy(hotel.HotelId);

        Assert.NotNull(actualHotel);
        Assert.Equal(hotel.HotelId, actualHotel.HotelId);
        Assert.Equal(hotel.Name, actualHotel.Name);
    }
    
    [Theory]
    [InlineAutoData]
    public void ThrowExceptionWhenSettingRoomAndHotelDoesNotExist(int hotelId, Room room)
    {
        IHotelRepository hotelRepo = new InMemoryHotelRepository();
        var hotelService = new HotelService(hotelRepo);
        
        Assert.Throws<HotelNotExistsException>(() => hotelService.SetRoom(hotelId, room.Number, room.RoomType));
    }
    
    [Theory]
    [InlineAutoData]
    public void CreateARoom(Hotel hotel, Room room)
    {
        IHotelRepository hotelRepo = new InMemoryHotelRepository();
        var hotelService = new HotelService(hotelRepo);
        hotelRepo.AddHotel(hotel.HotelId, hotel.Name);

        hotelService.SetRoom(hotel.HotelId, room.Number, room.RoomType);

        var actualHotel = hotelRepo.FindHotelBy(hotel.HotelId);
        Assert.NotNull(actualHotel);
        var actualRoom = actualHotel!.FindRoomBy(room.Number);
        Assert.Equal(room, actualRoom);
    }
    
    [Theory]
    [InlineAutoData]
    public void UpdateARoom(Hotel hotel, int roomNumber)
    {
        IHotelRepository hotelRepo = new InMemoryHotelRepository();
        var hotelService = new HotelService(hotelRepo);
        hotelRepo.AddHotel(hotel.HotelId, hotel.Name);

        hotelService.SetRoom(hotel.HotelId, roomNumber, RoomType.StandardSingle);
        hotelService.SetRoom(hotel.HotelId, roomNumber, RoomType.StandardDouble);

        var actualHotel = hotelRepo.FindHotelBy(hotel.HotelId);
        Assert.NotNull(actualHotel);
        var actualRoom = actualHotel!.FindRoomBy(roomNumber);
        Assert.Equal(new Room(roomNumber, RoomType.StandardDouble), actualRoom);
    }
}