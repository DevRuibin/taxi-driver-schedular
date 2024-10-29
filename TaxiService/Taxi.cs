using System;

public class Taxi
{
    public int Id { get; set; }
    public int SeatCapacity { get; set; }
    public MyCalendar Calendar { get; set; }

    public Taxi(int id, int seatCapacity)
    {
        Id = id;
        SeatCapacity = seatCapacity;
        Calendar = new MyCalendar();
    }
}