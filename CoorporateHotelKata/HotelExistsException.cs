namespace CoorporateHotelKata;

public class HotelExistsException : Exception
{
    public HotelExistsException(string? message) : base(message)
    {
    }
}