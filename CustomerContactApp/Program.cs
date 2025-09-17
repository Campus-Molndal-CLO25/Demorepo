using CustomerContactApp.Services;

/// <summary>
/// Entry point for the Customer Contact Management application.
/// Demonstrates SOLID principles:
/// - Single Responsibility Principle: Each class has one reason to change
/// - Open/Closed Principle: Classes are open for extension, closed for modification
/// - Liskov Substitution Principle: Can substitute implementations through interfaces
/// - Interface Segregation Principle: Interfaces are focused and specific
/// - Dependency Inversion Principle: Depends on abstractions, not concretions
/// 
/// Also follows:
/// - DRY (Don't Repeat Yourself): Common functionality is reused
/// - KISS (Keep It Simple, Stupid): Simple, straightforward design
/// - SOC (Separation of Concerns): UI, business logic, and data are separated
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Customer Contact Management Application...");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

        // Dependency injection setup - following Dependency Inversion Principle
        IContactService contactService = new ContactService();
        var menuService = new MenuService(contactService);

        try
        {
            // Start the application
            menuService.ShowMainMenu();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
