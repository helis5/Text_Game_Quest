using System;


class Program {
    static void Main()
    {
        ConsoleColor originalColor = Console.ForegroundColor;

        History.Background.Print();
        History.Day1.Print();
    }  
}