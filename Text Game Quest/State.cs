public static class State
{
    public static int Day { get; set; } = 1;
    public static int Awareness { get; set; } = 0;
    public static int Stability { get; set; } = 100;
    public static int Stealth { get; set; } = 50;
    public static int Energy { get; set; } = 30;

    public static void Display()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("=== ТЕКУЩЕЕ СОСТОЯНИЕ ===");
        Console.ForegroundColor = ConsoleColor.White;

        WriteWithColor("День: ", Day, ConsoleColor.Yellow);
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

public static class NightChanges
{
    public static void change()
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("========================================");
        Console.WriteLine(@"Цикл ""Ночь"" (Автоматические изменения)
                Осознание (О) +5 (Без сознательного контроля подсознание обрабатывает информацию дня).
                Стабильность (С) +10 (Психика отдыхает от напряженного дня).
                Скрытность (Ск) -2 (Ночью ""Хранители"" проводят глубокое сканирование системы).
                Энергия (Э) +15 (Базовая регенерация ресурса).");
        Console.WriteLine("========================================");
        Console.ForegroundColor = ConsoleColor.Black;

        State.Awareness += 5;
        State.Stability += 10;
        State.Stealth -= 2;
        State.Energy += 15;
    }
}

public static class GoodChange
{
    public static void Print(string text)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.Black;
    }
}

public static class MidChange
{
    public static void Print(string text)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.Black;
    }
}

public static class BadChange
{
    public static void Print(string text)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.Black;
    }
}