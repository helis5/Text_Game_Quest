namespace Actions
{
    public static class InteractWithTheSystem
    {
        public static void Print()
        {
            string[] actions = {
                "Взломать интерфейс (доступно при О >= 15)",
                "Использовать глитч (доступно при О >= 40)",
            };

            int choice = Vactions.GetNumberChoice(actions);
            Console.WriteLine($"Вы выбрали: {actions[choice]}");

            switch (choice)
            {
                case 0:
                    InteractWithTheSystem.Hacking_the_interface();
                    break;
                case 1:
                    InteractWithTheSystem.Use_glitch();
                    break;
            }
        }

        public static void Hacking_the_interface()
        {
            Console.WriteLine("Вы пытаетесь силой мысли вызвать меню настройки или командную строку. Это требует огромной концентрации.");

            var rand = new Random();
            Random random = new Random();
            bool randomBool = random.Next(2) == 1;

            if (randomBool)
            {
                GoodChange.Print(@"""Успех! Перед глазами возникает мерцающее окно с текстом: «Уровень доступа: Гость». Вы успеваете прочитать строку лога: «Аномальная активность нейронов субъекта 734»."" *О +25, Ск -10, Э -20.*");
                State.Awareness += 25;
                State.Stealth -= 10;
                State.Energy -= 20;

                State.Display();
                Observer.Listen.Do();
            }
            else
            {
                BadChange.Print(@"""Резкая головная боль. В ушах звучит нарастающий гул. Вы чувствуете, что привлекли внимание."" *Ск -15, Э -10.*");
                State.Stealth -= 15;
                State.Energy -= 10;

                State.Display();
                Observer.Listen.Do();
            }

        }

        public static void Use_glitch()
        {
            Console.WriteLine("Вы вспоминаете место, где видели сбой (например, парящий в воздухе объект). Вы пытаетесь взаимодействовать с ним, чтобы вызвать цепную реакцию.");

            if (State.Awareness >= 40)
            {
                var rand = new Random();
                Random random = new Random();
                bool randomBool = random.Next(2) == 1;

                if (randomBool)
                {
                    GoodChange.Print(@"Успех! ""Камень, неподвижно висящий в метре от земли, начинает вибрировать. Пространство вокруг него искажается, и на секунду вы видите серверную комнату вашего настоящего тела."" *О +35, Ск -20, С -15, Э -25.*");
                    State.Awareness += 35;
                    State.Stealth -= 20;
                    State.Stability -= 15;
                    State.Energy -= 25;

                    State.Display();
                    Observer.Listen.Do();
                }
                else
                {
                    BadChange.Print(@"""Глитч исчезает с резким звуком. Рядом материализуется два «Горожанина» с пустыми глазами — это Наблюдатели."" *Ск -30, С -20.*");
                    State.Stealth -= 30;
                    State.Stability -= 20;
                }
            }
            else
            {
                BadChange.Print("Вам пока рано влиять на материальный мир, вы недостаточно осознали сущность происходящего. Вы не смогли вызвать глитч, но привлекли внимание. Ск - 5");
                State.Stealth -= 5;

                State.Display();
                Observer.Listen.Do();

                InteractWithTheSystem.Print();
            }

        }
    }
}