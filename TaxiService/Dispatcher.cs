using System;
using System.Collections.Generic;

public class Dispatcher
{
    private HashSet<Taxi> taxis;
    private HashSet<Driver> drivers;

    public Dispatcher(HashSet<Taxi> taxis, HashSet<Driver> drivers)
    {
        this.taxis = taxis;
        this.drivers = drivers;
    }

    public Dispatcher()
    {
        taxis = new HashSet<Taxi>();
        drivers = new HashSet<Driver>();
        
        for (int i = 0; i < 5; i++)
        {
            drivers.Add(new Driver(i));
        }
        
        for (int i = 0; i < 7; i++)
        {
            taxis.Add(new Taxi(i, i + 1));
        }
    }

    private Driver GetAvailableDriver(int startTime, int duration)
    {
        foreach (var driver in drivers)
        {
            if (driver.Calendar.IsFree(startTime, startTime + duration - 1))
            {
                return driver;
            }
        }
        return null;
    }

    private Taxi GetAvailableTaxi(int startTime, int duration, int capacity)
    {
        foreach (var taxi in taxis)
        {
            if (taxi.SeatCapacity >= capacity && taxi.Calendar.IsFree(startTime, startTime + duration - 1))
            {
                return taxi;
            }
        }
        return null;
    }

    public string Request(int capacity, int duration)
    {
        int requestedStartTime = 0;  // Assume the passenger wants a taxi immediately

        Driver availableDriver = GetAvailableDriver(requestedStartTime, duration);
        Taxi availableTaxi = GetAvailableTaxi(requestedStartTime, duration, capacity);

        if (availableDriver != null && availableTaxi != null)
        {
            availableDriver.Calendar.BookSlot(requestedStartTime, requestedStartTime + duration - 1);
            availableTaxi.Calendar.BookSlot(requestedStartTime, requestedStartTime + duration - 1);
            return $"Taxi with ID {availableTaxi.Id} is on its way with Driver ID {availableDriver.Id}";
        }

        // If no immediate solution, find the earliest possible future slot
        int nextAvailableTime = requestedStartTime;
        
        while (true)
        {
            availableDriver = GetAvailableDriver(nextAvailableTime, duration);
            availableTaxi = GetAvailableTaxi(nextAvailableTime, duration, capacity);

            // If both are available at the same future time, book and return confirmation with wait time
            if (availableDriver != null && availableTaxi != null)
            {
                availableDriver.Calendar.BookSlot(nextAvailableTime, nextAvailableTime + duration - 1);
                availableTaxi.Calendar.BookSlot(nextAvailableTime, nextAvailableTime + duration - 1);
                int waitTime = nextAvailableTime - requestedStartTime;
                return $"Wait {waitTime} minutes. Taxi with ID {availableTaxi.Id} and Driver ID {availableDriver.Id} will be scheduled.";
            }

            // Increment the time slot and retry if no suitable driver and taxi were available
            nextAvailableTime++;
        }
    }
}