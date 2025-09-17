using CustomerContactApp.Models;

namespace CustomerContactApp.Services;

/// <summary>
/// Implementation of contact management operations.
/// Follows Single Responsibility Principle - only responsible for managing contacts.
/// Uses in-memory List<Person> for simplicity (KISS principle).
/// </summary>
public class ContactService : IContactService
{
    private readonly List<Person> _contacts;
    private int _nextId;

    public ContactService()
    {
        _contacts = new List<Person>();
        _nextId = 1;
    }

    public void AddContact(Person person)
    {
        if (person == null)
            throw new ArgumentNullException(nameof(person));

        person.Id = _nextId++;
        _contacts.Add(person);
    }

    public bool UpdateContact(int id, Person updatedPerson)
    {
        if (updatedPerson == null)
            return false;

        var existingContact = GetContact(id);
        if (existingContact == null)
            return false;

        // Update properties while preserving the ID
        existingContact.FirstName = updatedPerson.FirstName;
        existingContact.LastName = updatedPerson.LastName;
        existingContact.Email = updatedPerson.Email;
        existingContact.PhoneNumber = updatedPerson.PhoneNumber;

        return true;
    }

    public bool DeleteContact(int id)
    {
        var contact = GetContact(id);
        if (contact == null)
            return false;

        return _contacts.Remove(contact);
    }

    public Person? GetContact(int id)
    {
        return _contacts.FirstOrDefault(c => c.Id == id);
    }

    public List<Person> GetAllContacts()
    {
        return new List<Person>(_contacts); // Return a copy to prevent external modification
    }

    public List<Person> SearchContacts(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return GetAllContacts();

        var lowerSearchTerm = searchTerm.ToLower();
        return _contacts.Where(c => 
            c.FirstName.ToLower().Contains(lowerSearchTerm) ||
            c.LastName.ToLower().Contains(lowerSearchTerm) ||
            c.Email.ToLower().Contains(lowerSearchTerm) ||
            c.PhoneNumber.Contains(searchTerm)
        ).ToList();
    }
}