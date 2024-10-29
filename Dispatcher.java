import java.util.HashSet;
import java.util.Set;

public class Dispatcher {

    Set<Taxi> taxis;
    Set<Driver> drivers;

    public Dispatcher(Set<Taxi> taxis, Set<Driver> drivers) {
        this.taxis = taxis;
        this.drivers = drivers;
    }

    public Dispatcher() {
        taxis = new HashSet<>();
        drivers = new HashSet<>();
        for (int i = 0; i < 5; i++) {
            drivers.add(new Driver(i));
        }
        for (int i = 0; i < 7; i++) {
            taxis.add(new Taxi(i, i + 1));
        }
    }

    private Driver getAvailableDriver(int startTime, int duration){
        for (Driver driver : drivers) {
            if (driver.calendar.isFree(startTime, startTime + duration - 1)) {
                return driver;
            }
        }
        return null;
    }

    private Taxi getAvailableTaxi(int startTime, int duration, int capacity){
        for (Taxi taxi : taxis) {
            if (taxi.seatCapacity >= capacity && taxi.calendar.isFree(startTime, startTime + duration-1)) {
                return taxi;
            }
        }
        return null;
    }

    public String request(int capacity, int duration) {
        int requestedStartTime = 0;  // Assume the passenger wants a taxi immediately

        Driver availableDriver = getAvailableDriver(requestedStartTime, duration);
        Taxi availableTaxi = getAvailableTaxi(requestedStartTime,duration, capacity);



        if (availableDriver != null && availableTaxi != null) {
            availableDriver.calendar.bookSlot(requestedStartTime, requestedStartTime + duration-1);
            availableTaxi.calendar.bookSlot(requestedStartTime, requestedStartTime + duration-1);
            return "Taxi with ID " + availableTaxi.id + " is on its way with Driver ID " + availableDriver.id;
        }

        // If no immediate solution, find the earliest possible future slot
        int nextAvailableTime = requestedStartTime;
        while (true) {
            availableDriver = getAvailableDriver(nextAvailableTime, duration);
            availableTaxi = getAvailableTaxi(nextAvailableTime, duration, capacity);



            // If both are available at the same future time, book and return confirmation with wait time
            if (availableDriver != null && availableTaxi != null) {
                availableDriver.calendar.bookSlot(nextAvailableTime, nextAvailableTime + duration-1);
                availableTaxi.calendar.bookSlot(nextAvailableTime, nextAvailableTime + duration-1);
                int waitTime = nextAvailableTime - requestedStartTime;
                return "Wait " + waitTime + " minutes. Taxi with ID " + availableTaxi.id +
                        " and Driver ID " + availableDriver.id + " will be scheduled.";
            }

            // Increment the time slot and retry if no suitable driver and taxi were available
            nextAvailableTime++;
        }
    }
}