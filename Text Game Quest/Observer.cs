
namespace Observer
{
    public static class Listen
    {
        public static void Do()
        {
            if (State.Stealth <= 0)
            {
                Console.WriteLine("");
                BadChange.Print("Специальное событие - Критический кризис скрытности");
                BadChange.Print("Вы потеряли бдительность и Смотрители смогли вас схватить. Вы пытаетесь вырваться, но процесс зачистки кода уже запущен. Вы стёрты.");
                GameOver.Print();
            }
            else if (State.Stealth < 15)
            {
                BadChange.Print("Специальное событие - Кризис скрытности (Ск < 15)");
                BadChange.Print(@"""Внезапно улицы пустеют. Небо темнеет. Из-за угла появляются несколько человек в одинаковой одежде — это Смотрители. Их глаза горят холодным синим светом. Они идут к вам. Нужно срочно действовать!");
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
                        MidChange.Print("Вам удалось завернуть за угол и скрыться, но вы потеряли почти всю скрытность. Теперь Наблюдатели знают вас в лицо. Вам осталось недолго.");
                        State.Stealth += 5;
                        State.Display();
                        Observer.Listen.Do();
                    }
                    else
                    {
                        BadChange.Print("Вы потеряли бдительность и Смотрители смогли вас схватить. Вы пытаетесь вырваться, но процесс зачистки кода уже запущен. Вы стёрты.");
                        GameOver.Print();
                    }

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
                        State.Display();
                        Observer.Listen.Do();
                    }
                    else GameOver.Print();
                }
            }

            if (State.Stability <= 5)
            {
                Console.WriteLine("");
                BadChange.Print("Специальное событие. Стабильность нарушена.");
                BadChange.Print("Вы видите, как из-за горизонта на вас несётся чёрная стена, стирая всё на своём пути. Через секунду она достигает вас и стирает из этого мира");
                GameOver.Print();
            }

            if (State.Awareness >= 80)
            {
                Console.WriteLine("");
                GoodChange.Print("Специальное событие - Прорыв");
                GoodChange.Print("Мир вокруг начинает мерцать. Вы видите код, составляющий реальность. Перед вами возникает «Разрыв» — искажение в пространстве, ведущее к свободе. Но Хранители бросают на вас все силы!");
                Console.WriteLine("");
                GoodChange.Print("Вы делаете шаг в Разрыв. Боль сменяется ощущением холодной жидкости и звуком отключаемых датчиков. Вы снова в своем теле. Победа");
                GoodChange.Print("===============================");
                
                Environment.Exit(0);
            }

            if (State.Energy <= 5)
            {
                Console.WriteLine("");
                BadChange.Print("Специальное событие - Усталость");
                BadChange.Print("Из-за недостатка энергии вы теряете сознание посреди улицы. Ск -5 Э +10");
                State.Energy += 10;
                State.Stealth -= 5;

                State.Display();
                Observer.Listen.Do();
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