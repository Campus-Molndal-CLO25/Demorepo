using CustomerContactApp.Models;

namespace CustomerContactApp.Services;

/// <summary>
/// Interface for contact management operations.
/// Follows Interface Segregation Principle and Dependency Inversion Principle.
/// </summary>
public interface IContactService
{
    void AddContact(Person person);
    bool UpdateContact(int id, Person updatedPerson);
    bool DeleteContact(int id);
    Person? GetContact(int id);
    List<Person> GetAllContacts();
    List<Person> SearchContacts(string searchTerm);
}