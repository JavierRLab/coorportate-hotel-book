namespace CoorporateHotelKata;

public class HotelExistsException : Exception
{
    public HotelExistsException(string? message) : base(message)
    {
    }
}

public class HotelNotExistsException : Exception
{
    public HotelNotExistsException(string? message) : base(message)
    {
    }
}