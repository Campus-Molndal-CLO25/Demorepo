
internal class Customers
{
    private List<Person> _customers; // deklarerar
    public Customers()
    {
        _customers = new List<Person>(); // instansierar

        // Namnlista genererad av Claude
        _customers.Add(new Person() { Name = "Kalle Johansson", Email = "kalle@johansson.se" });
        _customers.Add(new Person() { Name = "Anna Svensson", Email = "anna.svensson@email.se" });
        _customers.Add(new Person() { Name = "Erik Lundberg", Email = "erik.lundberg@gmail.com" });
        _customers.Add(new Person() { Name = "Maria Andersson", Email = "maria.andersson@outlook.se" });
        _customers.Add(new Person() { Name = "Lars Nilsson", Email = "lars.nilsson@hotmail.com" });
        _customers.Add(new Person() { Name = "Sofia Karlsson", Email = "sofia@karlsson.net" });
        _customers.Add(new Person() { Name = "Johan Petersson", Email = "johan.petersson@company.se" });
        _customers.Add(new Person() { Name = "Emma Lindqvist", Email = "emma.lindqvist@student.se" });
        _customers.Add(new Person() { Name = "Magnus Olsson", Email = "magnus@olsson.org" });
        _customers.Add(new Person() { Name = "Lena Gustafsson", Email = "lena.gustafsson@work.com" });
        _customers.Add(new Person() { Name = "David Ström", Email = "david.strom@mail.se" });
    }

    public void ListCustomers(bool wait=true) // Helt genererad av Claude
    {
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                         KUNDLISTA                            ║");
        Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
        Console.WriteLine();

        if (_customers.Count == 0) // Kollar antal kunder
        {
            Console.WriteLine("Inga kunder registrerade än.");
            Console.WriteLine();
            Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine($"Antal kunder: {_customers.Count}");
        Console.WriteLine();
        Console.WriteLine("┌─────┬─────────────────────────┬──────────────────────────────────┐");
        Console.WriteLine("│ Nr  │ Namn                    │ E-post                           │");
        Console.WriteLine("├─────┼─────────────────────────┼──────────────────────────────────┤");

        for (int i = 0; i < _customers.Count; i++)
        {
            string name = TruncateString(_customers[i].Name, 23);
            string email = TruncateString(_customers[i].Email, 32);
            Console.WriteLine($"│ {i + 1,3} │ {name,-23} │ {email,-32} │");
            Thread.Sleep(10);
        }

        Console.WriteLine("└─────┴─────────────────────────┴──────────────────────────────────┘");
        Console.WriteLine();

        if (wait)
        {
            Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }
    }

    private string TruncateString(string input, int maxLength)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        return input.Length <= maxLength ? input : input.Substring(0, maxLength - 3) + "...";
    }

    internal void AddCustomer()
    {
        Console.Clear();
        Console.SetCursorPosition(0, 0);

        Console.WriteLine("Mata in kunddata");
        Console.WriteLine("Namn :");
        Console.WriteLine("Epost :");

        string name = InputHelper.AskString("Name : ", 1);
        string email = InputHelper.AskEmail("Epost : ", 2);

        Person newPerson = new Person();
        newPerson.Name = name;
        newPerson.Email = email;
        _customers.Add(newPerson);

        ListCustomers();
    }

    public void EditCustomer()
    {
        // 1 - Ta reda på vem man vill editera
        ListCustomers(false);
        Console.WriteLine("Vem vill du editera");
        // 2 - editera
        // 3 - Fråga om ändringar är OK
        // 4 - Spara
        Console.ReadKey();
    }
}