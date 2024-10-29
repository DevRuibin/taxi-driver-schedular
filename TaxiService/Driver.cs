using System;

public class Driver
{
    public int Id { get; set; }
    public MyCalendar Calendar { get; set; }

    public Driver(int id)
    {
        Id = id;
        Calendar = new MyCalendar();
    }
}
