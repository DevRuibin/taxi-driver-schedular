import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;

public class MyCalendar {
    List<int[]> bookedSlots;

    public MyCalendar(){
        bookedSlots = new ArrayList<>();
    }

    public boolean isFree(int start, int end){
        // inside
        for (int[] slot : bookedSlots){
            if(slot[0] <= start && slot[1] >= end){
                return false;
            }
            if(slot[0] <= start && slot[1] >=start){
                return false;
            }
            if(slot[0] <= end && slot[1] >= end){
                return false;
            }
        }
        return true;
    }

    public boolean bookSlot(int start, int end){
        if(!isFree(start, end)){
            return false;
        }
        bookedSlots.add(new int[]{start, end});
        bookedSlots.sort(Comparator.comparingInt(it -> it[0]));
        return true;
    }
}
