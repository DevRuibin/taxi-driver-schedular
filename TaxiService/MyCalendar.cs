using System;
using System.Collections.Generic;

public class MyCalendar
{
    private List<int[]> bookedSlots;

    public MyCalendar()
    {
        bookedSlots = new List<int[]>();
    }

    public bool IsFree(int start, int end)
    {
        foreach (var slot in bookedSlots)
        {
            // Check if there's an overlap
            if (slot[0] <= start && slot[1] >= end)
            {
                return false;
            }
            if (slot[0] <= start && slot[1] >= start)
            {
                return false;
            }
            if (slot[0] <= end && slot[1] >= end)
            {
                return false;
            }
        }
        return true;
    }

    public bool BookSlot(int start, int end)
    {
        if (!IsFree(start, end))
        {
            return false;
        }
        bookedSlots.Add(new int[] { start, end });
        bookedSlots.Sort((a, b) => a[0].CompareTo(b[0]));
        return true;
    }
}