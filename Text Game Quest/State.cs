public static class State
{
    public static int Awareness { get; set; } = 0;
    public static int Stability { get; set; } = 100;
    public static int Stealth { get; set; } = 50;
    public static int Energy { get; set; } = 30;

    public static void Display()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("=== ТЕКУЩЕЕ СОСТОЯНИЕ ===");
        Console.ForegroundColor = ConsoleColor.White;

        WriteWithColor("Осознание: ", Awareness, ConsoleColor.Cyan);
        WriteWithColor("Стабильность: ", Stability, GetStabilityColor(Stability));
        WriteWithColor("Скрытность: ", Stealth, ConsoleColor.Magenta);
        WriteWithColor("Энергия: ", Energy, GetEnergyColor(Energy));

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("=========================");
        Console.ForegroundColor = ConsoleColor.White;
}

private static void WriteWithColor(string label, int value, ConsoleColor color)
{
    Console.Write(label);
    Console.ForegroundColor = color;
    Console.Write(value);
    Console.ResetColor();
    Console.WriteLine();
}

private static ConsoleColor GetStabilityColor(int stability)
{
    return stability switch
    {
        > 80 => ConsoleColor.Green,
        > 50 => ConsoleColor.Yellow,
        > 30 => ConsoleColor.Red,
        _ => ConsoleColor.DarkRed
    };
}

private static ConsoleColor GetEnergyColor(int energy)
{
    return energy switch
    {
        > 70 => ConsoleColor.Green,
        > 40 => ConsoleColor.Yellow,
        > 20 => ConsoleColor.Red,
        _ => ConsoleColor.DarkRed
    };
}
}