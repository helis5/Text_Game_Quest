using System;

public class History
{
    public static void Day1()
    {
        Console.WriteLine("Вы просыпаетесь в своей комнате. Всё как всегда, но сегодня утром свет от солнца за окном на секунду показался вам пиксельным. Что будете делать?");

        while (true)
        {
            string[] actions = {
                "Проигнорировать и пойти на работу",
                "Внимательньно изучить комнату",
            };

            int choice = Wactions.GetNumberChoice(actions);
            Console.WriteLine($"Вы выбрали: {actions[choice]}");

            switch (choice)
            {
                case 0:
                    HandleQuit();
                    break;

            }
            ;

            static void HandleQuit()
            {
                Console.WriteLine("Вы подавляете подозрения, система вас не замечает");
            }

            Console.WriteLine("\nНажмите любую клавишу чтобы продолжить...");
            Console.ReadKey();
        }
    }
}
