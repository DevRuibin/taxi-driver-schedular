# Dispatcher System

This project is a basic dispatcher system for scheduling taxis and drivers.

## Features

1. Immediate Booking: Assigns an available driver and taxi instantly if available.
2. If no immediate match is available, calculates the minimum wait time and books the earliest available time slot.
3. Only assigns taxis with sufficient seating capacity as requested by the passenger.

## Output examples

```
Taxi with ID 6 is on its way with Driver ID 0
Wait 2 minutes. Taxi with ID 6 and Driver ID 0 will be scheduled.
Wait 4 minutes. Taxi with ID 6 and Driver ID 0 will be scheduled.
Taxi with ID 5 is on its way with Driver ID 2
```