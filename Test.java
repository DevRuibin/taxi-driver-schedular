public class Test {
    public static void main(String[] args) {
        Dispatcher dispatcher = new Dispatcher();
        String res;
        res = dispatcher.request(7,2);
        System.out.println(res);
        res = dispatcher.request(7,2);
        System.out.println(res);
        res = dispatcher.request(7,2);
        System.out.println(res);
        res = dispatcher.request(6,2);
        System.out.println(res);

    }
}
