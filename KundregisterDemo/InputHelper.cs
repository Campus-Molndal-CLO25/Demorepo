



internal class InputHelper
{
    internal static string AskEmail(string prompt, int position)
    {
        while (true)
        {
            Console.CursorTop = position;
            Console.WriteLine("                                       ");
            Console.CursorTop = position;
            Console.Write(prompt);
            string? input = Console.ReadLine();

            string result = input.Trim(); // Tar bort mellanslag i början och slutet

            // Emailcheck
            // Inga mellanslag alls
            // ska innehålla @
            // efter @ ska innehålla minst en punkt

            result = result.Replace(" ", "");
            result = result.Replace(",", ".");
            if (!result.Contains("@")) continue;
            if (!result.Contains(".")) continue;
            result = result.ToLower();

            int atPosition = result.IndexOf("@"); // letar efter första
            int dotPosition = result.LastIndexOf("."); // letar efter sista
            if (atPosition > dotPosition) continue;

            if (result != "")
            {
                return result;
            }
        }
    }

    internal static string AskString(string prompt, int position)
    {
        while (true)
        {
            Console.CursorTop = position;
            Console.Write(prompt);
            string? input = Console.ReadLine();

            string result = input.Trim(); // Tar bort mellanslag i början och slutet
            if (result != "")
            {
                return result;
            }
        }
    }

    internal static int GetMenuChoice(int max)
    {
        while (true)
        {
            Console.Write("> ");
            string? input = Console.ReadLine();

            int.TryParse(input, out var value);
            if (value < 1 || value > max)
                Console.WriteLine("Felaktigt val dummer!");
            else
                return value;
        }
    }

    internal static bool YesNoQuestion(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            string result = input.Trim(); // Tar bort mellanslag i början och slutet
            if (result == "")
            {
                continue;
            }

            string firstLetter = result.Substring(0, 1).ToLower();
            if (firstLetter == "j" || firstLetter == "y")
            {
                return true;
            }
            else if (firstLetter == "n")
            {
                return false;
            }
        }
    }
}