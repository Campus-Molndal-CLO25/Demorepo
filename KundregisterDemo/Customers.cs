

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
        _customers.Add(new Person("Marcus Medina"));
        _customers.Add(new Person("hello@marcusmedina.pro"));
        _customers.Add(new Person(email: "kalle@anka.se"));

        Person kanin = new Person { Name = "Pelle Kanin", Email = "pelle@kanin.se" };
        _customers.Add(new Person(kanin));

    }

    public void ListCustomers(bool wait = true) // Helt genererad av Claude
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
        Console.WriteLine("Vem vill du editera?");
        int choice = InputHelper.GetMenuChoice(_customers.Count) - 1;

        // 2 - editera
        PrintCustomer(choice);
        Console.WriteLine("Skriv in dina ändringar:");
        int pos = Console.CursorTop;

        string name = InputHelper.AskString("Namn  : ", pos + 1);
        string email = InputHelper.AskEmail("Epost : ", pos + 2);

        // 3 - Fråga om ändringar är OK
        bool isOK = InputHelper.YesNoQuestion("Är du säker på detta?");

        // 4 - Spara
        if (isOK)
        {
            UpdateCustomer(choice, name, email);
        }


        ListCustomers();
    }

    private void UpdateCustomer(Index index, string name, string email)
    {
        Person customer = _customers[index]; // referenstyp
        customer.Name = name;
        customer.Email = email;
        // SaveChanges() för att spara i en databas
    }

    private void PrintCustomer(int index)
    {
        Person customer = _customers[index];
        Console.Clear();
        Console.WriteLine("Namn  : " + customer.Name);
        Console.WriteLine("Epost : " + customer.Email);
    }

    internal void DeleteCustomer()
    {
        // Select customer to delete
        ListCustomers(false);
        Console.WriteLine("Vem vill du radera?");
        int toDelete = InputHelper.GetMenuChoice(_customers.Count) - 1;

        // Ask to be sure
        bool isOK = InputHelper.YesNoQuestion("Är du säker på att du vill radera " + _customers[toDelete].Name);

        // Crush Kill Destroy! 
        if (isOK)
        {
            _customers.RemoveAt(toDelete);
            ListCustomers();
        }

    }
}