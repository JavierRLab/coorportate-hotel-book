namespace CoorporateHotelKata;

public class Hotel
{
    public int HotelId { get; set; }
    public string Name { get; set; }
    public Dictionary<int, Room> Rooms { get; } = new();

    public Room? FindRoomBy(int roomNumber)
    {
        return Rooms.TryGetValue(roomNumber, out var hotel) ? hotel : null;
    }

    public void SetRoom(int number, RoomType roomType)
    {
        var room = FindRoomBy(number);
        if (room is null)
        {
            Rooms.Add(number, new Room(number, roomType));    
        }
        else
        {
            Rooms[number] = new Room(number, roomType);
        }
    }
}