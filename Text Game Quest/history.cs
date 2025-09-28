using System;
using System.ComponentModel;

namespace History
{

    public static class Background
    {
        public static void Print() {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("== ПОБЕГ ИЗ СИМУЛЯЦИИ ==");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Сюжет: Игрок — это сознание, которое начало осознавать, что его реальность является компьютерной симуляцией. Цель — повысить уровень Осознания, чтобы найти уязвимость (\"Дверь\") и сбежать, при этом не позволив системе \"зачистить\" вас (опустить Стабильность до нуля) и не вызвать подозрений \"Смотрителей\" (опустить Скрытность).");
            Console.WriteLine("----------------");
            Console.WriteLine(@"Параметры персонажа
            Осознание (О) = 0 (Понимание истинной природы мира. Цель: поднять до 100 для победы)

            Стабильность (С) = 100 (Ваша ""целостность"" в системе. Падает до 0 — game over)

            Скрытность (Ск) = 50 (Насколько вы незаметны для защитных алгоритмов. Падает до 0 — система вас обнаруживает и ""зачищает"")

            Энергия (Э) = 30 (Внутренний ресурс для активных действий. Тратится на исследование аномалий)");
        }


    }
    public static class Day1
    {
        public static void Print()
        {
            Console.WriteLine("Вы просыпаетесь в своей комнате. Всё как всегда, но сегодня утром свет от солнца за окном на секунду показался вам пиксельным. Что будете делать?");
            State.Display();


            string[] actions = {
                "Проигнорировать и пойти на работу (Ск +10, Э +5)",
                "Внимательньно изучить комнату (О +10, Ск -5, Э -10)",
            };


            int choice = Vactions.GetNumberChoice(actions);
            
            Console.WriteLine($"Вы выбрали: {actions[choice]}");

            switch (choice)
            {
                case 0:
                    HandleQuit();
                    break;
                case 1:
                    HandleInterest();
                    break;
            }
        ;

            static void HandleQuit()
            {
                MidChange.Print("Вы подавляете странное ощущение. День проходит предсказуемо. Коллеги улыбаются одинаковыми улыбками. Система вас не замечает");
                State.Stealth += 10;
                State.Energy += 5;
                State.Day += 1;
                History.Day2.Print();
            }
            static void HandleInterest()
            {
                GoodChange.Print("Вы замечаете, что тени от предметов не подчиняются законам физики. Подойдя ближе, всё приходит в норму.");
                State.Awareness += 10;
                State.Stealth -= 5;
                State.Energy -= 10;
                State.Day += 1;
                History.Day2.Print();
            }
        }

    }
    public static class Day2
    {
        public static void Print() {
            NightChanges.change();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("!Действия становятся доступны по мере роста Осознания");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Наступил следующий день. Сегодня можно расслабиться, ведь у вас выходной. Вас не покидает мысль о том, что было вчера. Вас преследует странное ощущение нереалистичности происходящего вокруг, но вы пока этого не осознаёте");
            State.Display();

            string[] actions = {
                "Анализировать окружение",
                "Взаимодействовать с системой",
                "Активная маскировка",
                "Отдых и медитация",
            };


            int choice = Vactions.GetNumberChoice(actions);
            Console.WriteLine($"Вы выбрали: {actions[choice]}");


            switch (choice)
            {
                case 0:
                    Actions.AnalyzeTheEnvironment.Print();
                    break;
                case 1:

                    break;
            }
        }
        
    }
}
