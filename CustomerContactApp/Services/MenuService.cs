using CustomerContactApp.Models;

namespace CustomerContactApp.Services;

/// <summary>
/// Handles user interface and menu operations.
/// Follows Single Responsibility Principle - only responsible for UI interactions.
/// Separation of Concerns - separated from business logic.
/// </summary>
public class MenuService
{
    private readonly IContactService _contactService;

    public MenuService(IContactService contactService)
    {
        _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
    }

    public void ShowMainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Customer Contact Management ===");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. View All Contacts");
            Console.WriteLine("3. Search Contacts");
            Console.WriteLine("4. Update Contact");
            Console.WriteLine("5. Delete Contact");
            Console.WriteLine("0. Exit");
            Console.WriteLine("====================================");
            Console.Write("Choose an option: ");

            var choice = Console.ReadLine();
            HandleMenuChoice(choice);
        }
    }

    private void HandleMenuChoice(string? choice)
    {
        switch (choice)
        {
            case "1":
                AddContact();
                break;
            case "2":
                ViewAllContacts();
                break;
            case "3":
                SearchContacts();
                break;
            case "4":
                UpdateContact();
                break;
            case "5":
                DeleteContact();
                break;
            case "0":
                Console.WriteLine("Goodbye!");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                PauseForUser();
                break;
        }
    }

    private void AddContact()
    {
        Console.Clear();
        Console.WriteLine("=== Add New Contact ===");

        var person = new Person();

        Console.Write("First Name: ");
        person.FirstName = Console.ReadLine() ?? string.Empty;

        Console.Write("Last Name: ");
        person.LastName = Console.ReadLine() ?? string.Empty;

        Console.Write("Email: ");
        person.Email = Console.ReadLine() ?? string.Empty;

        Console.Write("Phone Number: ");
        person.PhoneNumber = Console.ReadLine() ?? string.Empty;

        try
        {
            _contactService.AddContact(person);
            Console.WriteLine($"Contact '{person.FullName}' added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding contact: {ex.Message}");
        }

        PauseForUser();
    }

    private void ViewAllContacts()
    {
        Console.Clear();
        Console.WriteLine("=== All Contacts ===");

        var contacts = _contactService.GetAllContacts();
        DisplayContacts(contacts);

        PauseForUser();
    }

    private void SearchContacts()
    {
        Console.Clear();
        Console.WriteLine("=== Search Contacts ===");
        Console.Write("Enter search term: ");

        var searchTerm = Console.ReadLine() ?? string.Empty;
        var contacts = _contactService.SearchContacts(searchTerm);

        Console.WriteLine($"\nSearch results for '{searchTerm}':");
        DisplayContacts(contacts);

        PauseForUser();
    }

    private void UpdateContact()
    {
        Console.Clear();
        Console.WriteLine("=== Update Contact ===");

        var contacts = _contactService.GetAllContacts();
        if (!contacts.Any())
        {
            Console.WriteLine("No contacts available to update.");
            PauseForUser();
            return;
        }

        DisplayContacts(contacts);
        Console.Write("\nEnter the ID of the contact to update: ");

        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var existingContact = _contactService.GetContact(id);
            if (existingContact == null)
            {
                Console.WriteLine("Contact not found.");
                PauseForUser();
                return;
            }

            Console.WriteLine($"\nUpdating contact: {existingContact.FullName}");
            Console.WriteLine("(Press Enter to keep current value)");

            var updatedPerson = new Person();

            Console.Write($"First Name [{existingContact.FirstName}]: ");
            var firstName = Console.ReadLine();
            updatedPerson.FirstName = string.IsNullOrWhiteSpace(firstName) ? existingContact.FirstName : firstName;

            Console.Write($"Last Name [{existingContact.LastName}]: ");
            var lastName = Console.ReadLine();
            updatedPerson.LastName = string.IsNullOrWhiteSpace(lastName) ? existingContact.LastName : lastName;

            Console.Write($"Email [{existingContact.Email}]: ");
            var email = Console.ReadLine();
            updatedPerson.Email = string.IsNullOrWhiteSpace(email) ? existingContact.Email : email;

            Console.Write($"Phone Number [{existingContact.PhoneNumber}]: ");
            var phone = Console.ReadLine();
            updatedPerson.PhoneNumber = string.IsNullOrWhiteSpace(phone) ? existingContact.PhoneNumber : phone;

            if (_contactService.UpdateContact(id, updatedPerson))
            {
                Console.WriteLine("Contact updated successfully!");
            }
            else
            {
                Console.WriteLine("Failed to update contact.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }

        PauseForUser();
    }

    private void DeleteContact()
    {
        Console.Clear();
        Console.WriteLine("=== Delete Contact ===");

        var contacts = _contactService.GetAllContacts();
        if (!contacts.Any())
        {
            Console.WriteLine("No contacts available to delete.");
            PauseForUser();
            return;
        }

        DisplayContacts(contacts);
        Console.Write("\nEnter the ID of the contact to delete: ");

        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var contact = _contactService.GetContact(id);
            if (contact == null)
            {
                Console.WriteLine("Contact not found.");
                PauseForUser();
                return;
            }

            Console.Write($"Are you sure you want to delete '{contact.FullName}'? (y/N): ");
            var confirmation = Console.ReadLine()?.ToLower();

            if (confirmation == "y" || confirmation == "yes")
            {
                if (_contactService.DeleteContact(id))
                {
                    Console.WriteLine("Contact deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Failed to delete contact.");
                }
            }
            else
            {
                Console.WriteLine("Deletion cancelled.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }

        PauseForUser();
    }

    private void DisplayContacts(List<Person> contacts)
    {
        if (!contacts.Any())
        {
            Console.WriteLine("No contacts found.");
            return;
        }

        Console.WriteLine();
        foreach (var contact in contacts)
        {
            Console.WriteLine(contact.ToString());
        }
    }

    private void PauseForUser()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}