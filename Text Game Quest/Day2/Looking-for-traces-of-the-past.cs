namespace Actions
{
    public static class LookingForTracesOfThePast
    {
        public static void Print()
        {

            if (State.Awareness >= 50)
            {
                string[] actions = {
                    "Копаться в «воспоминаниях» симуляции.",
                    "Попытаться вспомнить реальное имя.",
                };

                int choice = Vactions.GetNumberChoice(actions);
                Console.WriteLine($"Вы выбрали: {actions[choice]}");

                switch (choice)
                {
                    case 0:
                        LookingForTracesOfThePast.Memories();
                        break;
                    case 1:
                        ActiveMasking.DigitalTwin();
                        break;
                }
            }
            else
            {
                BadChange.Print("Сложно что-то найти, когда не знаешь что искать. Ск -5");
                State.Stealth -= 5;

                Observer.Listen.Do();
                LookingForTracesOfThePast.Print();
            }

            Observer.Listen.Do();
        }

        public static void Memories()
        {
            Console.WriteLine("");
            Console.WriteLine("Вы ищете места, которые должны иметь эмоциональный вес (старая школа, дом детства), но которых нет в симуляции или они выглядят фальшиво.");
            GoodChange.Print("Вы находите пустой участок, где должен быть ваш настоящий дом. На его месте — низкополигональная модель холма. Это доказывает, что ваше прошлое было подделано.*О +30, С -20 (экзистенциальный кризис), Ск -10.*");


            State.Stealth -= 10;
            State.Awareness += 30;
            State.Stability -= 20;

            State.Display();
            Observer.Listen.Do();
        }

        public static void RealName()
        {
            Console.WriteLine("");
            Console.WriteLine("Вы концентрируетесь на ощущении «я». Имя, данное вам в симуляции, кажется чужим.");
            GoodChange.Print("Вспышка боли... и вы слышите голос техника: «Держите стабильность субъекта Каин на уровне 70%».*О +40, С -10, Ск -15. Вы узнаете свое настоящее имя — Каин. Это дает скрытый бонус к дальнейшим проверкам.*");

            State.Awareness += 40;
            State.Stability -= 10;
            State.Stealth -= 15;

            State.Display();
            Observer.Listen.Do();
        }

    }
}