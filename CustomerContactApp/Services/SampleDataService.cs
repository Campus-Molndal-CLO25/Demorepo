using CustomerContactApp.Models;

namespace CustomerContactApp.Services;

/// <summary>
/// Service to initialize sample data for demonstration purposes.
/// Follows Single Responsibility Principle - only responsible for data initialization.
/// </summary>
public static class SampleDataService
{
    public static void InitializeSampleData(IContactService contactService)
    {
        var sampleContacts = new[]
        {
            new Person 
            { 
                FirstName = "Alice", 
                LastName = "Johnson", 
                Email = "alice.johnson@email.com", 
                PhoneNumber = "555-0101" 
            },
            new Person 
            { 
                FirstName = "Bob", 
                LastName = "Williams", 
                Email = "bob.williams@email.com", 
                PhoneNumber = "555-0102" 
            },
            new Person 
            { 
                FirstName = "Carol", 
                LastName = "Davis", 
                Email = "carol.davis@email.com", 
                PhoneNumber = "555-0103" 
            }
        };

        foreach (var contact in sampleContacts)
        {
            contactService.AddContact(contact);
        }
    }
}