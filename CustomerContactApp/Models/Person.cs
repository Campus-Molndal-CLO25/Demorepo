namespace CustomerContactApp.Models;

/// <summary>
/// Represents a person with contact information.
/// Follows Single Responsibility Principle - only responsible for holding person data.
/// </summary>
public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

    public string FullName => $"{FirstName} {LastName}";

    public override string ToString()
    {
        return $"[{Id}] {FullName} - Email: {Email}, Phone: {PhoneNumber}";
    }
}