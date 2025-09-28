
namespace Observer
{
    public static class Listen
    {
        public static void Do()
        {
            if (State.Stealth <= 0)
            {
                BadChange.Print("Вы потеряли бдительность и Смотрители смогли вас схватить. Вы пытаетесь вырваться, но процесс зачистки кода уже запущен. Вы стёрты.");
                GameOver.Print();
            }
            else

            if (State.Stealth < 15)
            {
                BadChange.Print(@"Кризис Скрытности (Ск < 15): ""Внезапно улицы пустеют. Небо темнеет. Из-за угла появляются несколько человек в одинаковой одежде — это Смотрители. Их глаза горят холодным синим светом. Они идут к вам. Нужно срочно действовать!");
                string[] actions = {
                    "Попытаться убежать",
                    "Сымитировать сбой: При успехе — Хранители принимают вас за обычный глитч, Ск восстанавливается до 25. При провале — С падает на 30.",
                };

                int choice = Vactions.GetNumberChoice(actions);
                Console.WriteLine($"Вы выбрали: {actions[choice]}");

                switch (choice)
                {
                    case 0:
                        Run();
                        break;
                    case 1:
                        Imitation();
                        break;
                }


                static void Run()
                {
                    var rand = new Random();
                    Random random = new Random();
                    bool randomBool = random.Next(2) == 1;

                    if (randomBool)
                    {
                        MidChange.Print("Вам удалось завернуть за угол и скрыться, но вы потеряли почти всю скрытность. Теперь наблюдатели знают вас в лицо. Вам осталось недолго.");
                        State.Stealth += 5;
                        Observer.Listen.Do();
                    }
                    else GameOver.Print();
                }

                static void Imitation()
                {
                    var rand = new Random();
                    Random random = new Random();
                    bool randomBool = random.Next(2) == 1;
                    
                    if (randomBool)
                    {
                        MidChange.Print("Хранители принимают вас за обычный глитч, Ск восстанавливается до 25");
                        State.Stealth += 25;
                        Observer.Listen.Do();
                    }
                    else GameOver.Print();
                }
            }
        }
    }

    public static class GameOver {
        public static void Print()
        {
            for (int i = 1; i < 5; i++)
            {
                BadChange.Print("Game Over!!!");
            }
            Environment.Exit(0);
        }
    }
}