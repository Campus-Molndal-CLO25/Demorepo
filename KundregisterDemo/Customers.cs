
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

    public void ListCustomers()
    {
        Console.Clear();
        Console.WriteLine("Här är kunderna");
        foreach(Person customer in _customers)
        {
            Console.WriteLine(customer.Name + " " + customer.Email);
        }
        Console.ReadKey();
    }

    internal void AddCustomer()
    {
        Console.Clear();
        Console.WriteLine("Mata in kunddata");
        Console.WriteLine("Namn :");
        Console.WriteLine("Epost :");

        string name = InputHelper.AskString("Name : ",1);
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
        // 2 - editera
        // 3 - Fråga om ändringar är OK
        // 4 - Spara
    }
}