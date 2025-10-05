namespace Actions
{
    public static class ActiveMasking
    {
        public static void Print()
        {
            string[] actions = {
                "Вести себя гипернормально",
                "Создать цифрового двойника (доступно при О >= 30)",
            };

            int choice = Vactions.GetNumberChoice(actions);
            Console.WriteLine($"Вы выбрали: {actions[choice]}");

            switch (choice)
            {
                case 0:
                    ActiveMasking.Hypernormality();
                    break;
                case 1:
                    ActiveMasking.DigitalTwin();
                    break;
            }
            Observer.Listen.Do();
        }

        public static void Hypernormality()
        {
            Console.WriteLine("");
            Console.WriteLine("Вы подавляете любые сомнения, улыбаетесь и активно участвуете в бессмысленных беседах. Вы пытаетесь «обмануть» систему, демонстрируя полную лояльность.");
            MidChange.Print("День проходит без происшествий. Вы чувствуете себя опустошенным, но невидимым. *Ск +20, О -5 (вы подавляете свои мысли).*");

            State.Stealth += 20;
            State.Awareness -= 5;
        }

        public static void DigitalTwin()
        {
            if (State.Awareness >= 30)
            {
                Console.WriteLine("");
                Console.WriteLine("Вы используете часть своего сознания, чтобы создать иллюзию своей рутинной деятельности, пока ваше настоящее «я» исследует.");
                GoodChange.Print("Ваш двойник идет на работу, а вы получаете несколько часов относительной свободы. *Ск +30, Э -15 (поддержание двойника требует энергии).*");
                State.Stealth += 20;
                State.Energy -= 15;

                State.Display();
                Observer.Listen.Do();
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Вы напрягли сознание, но ничего не вышло Ск -5, Э -5");
                State.Stealth -= 5;
                State.Energy -= 5;

                State.Display();
                Observer.Listen.Do();

                ActiveMasking.Print();
            }
        }
    }
}