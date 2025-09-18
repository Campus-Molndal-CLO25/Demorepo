internal class Menu
{
    public Menu()
    {

    }

    public void ShowMenu()
    {
        Customers _customers = new Customers();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Hello, Kundregister 🐐!");

            // CRUD = Create, Read, Update, Delete
            Console.WriteLine("1 - List customers"); // Read
            Console.WriteLine("2 - Add customer");   // Create
            Console.WriteLine("3 - Edit customer");  // Update
            Console.WriteLine("4 - Delete Customer");// Delete
            Console.WriteLine("5 - quit");

            int input = InputHelper.GetMenuChoice(5);

            if (input == 5)
            {
                return;
            }
            else if (input == 1)
            {
                _customers.ListCustomers();
            }
            else if (input == 2)
            {
                _customers.AddCustomer();
            }

        }
    }
}