namespace Actions
{
    public static class RestAndMeditation
    {
        public static void Print()
        {
            Console.WriteLine("");
            MidChange.Print("Вы проводите день в бездействии, пытаясь восстановить силы и упорядочить мысли.");
            NightChanges.change();

            State.Display();
            Observer.Listen.Do();
        }

    }
}