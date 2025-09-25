public class Wactions
{
    public static int GetNumberChoice(string[] options, string prompt = "Выберите действие:")
    {
        while (true)
        {
            Console.WriteLine(prompt);
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            Console.Write("Введите номер: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= options.Length)
            {
                return choice - 1;
            }

            Console.WriteLine($"Ошибка! Введите число от 1 до {options.Length}");
            Console.WriteLine();
        }
    }
}
