

namespace Actions
{
    public static class AnalyzeTheEnvironment
    {
        public static void Print()
        {
            string[] actions = {
                "Наблюдать за людьми",
                "Искать геометрические аномалии (доступно при О >= 25)",
            };

            int choice = Vactions.GetNumberChoice(actions);
            Console.WriteLine($"Вы выбрали: {actions[choice]}");


            switch (choice)
            {
                case 0:
                    AnalyzeTheEnvironment.Watching_people();
                    break;
                case 1:
                    AnalyzeTheEnvironment.Look_for_geometric_anomalies();
                    break;
            }
        }
        public static void Watching_people()
        {
            Console.WriteLine("Вы сидите в парке и внимательно следите за прохожими. Их движения плавные, но слишком цикличные.");
            if (State.Awareness < 20)
            {
                GoodChange.Print("Вы замечаете, что один и тот же человек с собакой проходит по одной и той же траектории каждые 12 минут.");
                State.Awareness += 5;
                State.Stealth -= 2;
                MidChange.Print("Вам не хватает осознанности чтобы заметить другие странности.");
            }
            else
            {
                GoodChange.Print("Вы видите, как у женщины, смеющейся над шуткой ребенка, на лице на долю секунды застывает стандартная маска «радость v3.1», не успевая за изменением интонации.");
                State.Awareness += 15;
                State.Stealth -= 5;
                State.Energy -= 15;
            }
            Observer.Listen.Do();
        }

        public static void Look_for_geometric_anomalies()
        {
            if (State.Awareness >= 25)
            {
                Console.WriteLine("Вы всматриваетесь в архитектуру города. Здания слишком идеальны. Вы ищите ошибки в перспективе или текстурах.");
                Console.WriteLine(@"Эффект: ""Войдя в узкий переулок, вы видите, что стены двух зданий не сходятся, образуя едва заметный «шов», за которым пустота и мерцание кода."" *О +20, С -10 (шокирующее зрелище), Э -15.*");

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Вам пока рано сюда, вы недостаточно осознали сущность происходящего. Вы ничего не нашли, но привлеки внимание. Ск - 5");
                State.Stealth -= 5;
                Console.ForegroundColor = ConsoleColor.White;
                Observer.Listen.Do();
                AnalyzeTheEnvironment.Print();
                
            }
            Observer.Listen.Do();
        }
    }
}
