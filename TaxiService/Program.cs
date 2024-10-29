using System;
public class Test
{
    public static void Main(string[] args)
    {
        Dispatcher dispatcher = new Dispatcher();
        string res;
        
        res = dispatcher.Request(7, 2);
        Console.WriteLine(res);
        
        res = dispatcher.Request(7, 2);
        Console.WriteLine(res);
        
        res = dispatcher.Request(7, 2);
        Console.WriteLine(res);
        
        res = dispatcher.Request(6, 2);
        Console.WriteLine(res);
    }
}