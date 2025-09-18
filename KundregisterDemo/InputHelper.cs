
internal class InputHelper
{
    internal static int GetMenuChoice(int max)
    {
        while (true)
        {
            Console.Write("> ");
            string? input = Console.ReadLine();

            int.TryParse(input, out var value);
            if (value<1 || value>max)
                Console.WriteLine("Felaktigt val dummer!");
            else
                return value;
        }
    }
}