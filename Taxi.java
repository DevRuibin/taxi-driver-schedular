public class Taxi {
    int id;
    int seatCapacity;
    MyCalendar calendar;

    public Taxi(int id,int seatCapacity) {
        this.id = id;
        this.seatCapacity = seatCapacity;
        this.calendar = new MyCalendar();
    }
}
