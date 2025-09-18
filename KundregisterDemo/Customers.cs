
internal class Customers
{
    private List<Person> _customers; // deklarerar
    public Customers()
    {
        _customers = new List<Person>(); // instansierar

        _customers.Add(new Person() { Name = "Kalle Johansson", Email = "kalle@johansson.se" });
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
}