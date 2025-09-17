# Customer Contact Management Console Application

A simple console application for managing customer contacts, built following SOLID principles and software engineering best practices.

## Features

- **Complete CRUD Operations**: Create, Read, Update, and Delete customer contacts
- **Search Functionality**: Find contacts by name, email, or phone number
- **Interactive Menu**: User-friendly console interface
- **Sample Data**: Pre-loaded with sample contacts for demonstration

## Architecture

The application demonstrates SOLID principles:

### Single Responsibility Principle (SRP)
- `Person`: Only responsible for holding person data
- `ContactService`: Only manages contact operations
- `MenuService`: Only handles user interface
- `SampleDataService`: Only initializes sample data

### Open/Closed Principle (OCP)
- Services can be extended through interfaces without modifying existing code

### Liskov Substitution Principle (LSP)
- Interface implementations are fully substitutable

### Interface Segregation Principle (ISP)
- `IContactService` provides focused, specific methods

### Dependency Inversion Principle (DIP)
- `MenuService` depends on `IContactService` abstraction, not concrete implementation

## Additional Principles Applied

- **DRY (Don't Repeat Yourself)**: Common functionality is reused
- **KISS (Keep It Simple, Stupid)**: Simple in-memory storage using `List<Person>`
- **SOC (Separation of Concerns)**: Clear separation between UI, business logic, and data

## Project Structure

```
CustomerContactApp/
├── Models/
│   └── Person.cs              # Data model
├── Services/
│   ├── IContactService.cs     # Service interface
│   ├── ContactService.cs      # Contact management implementation
│   ├── MenuService.cs         # User interface service
│   └── SampleDataService.cs   # Sample data initialization
├── Program.cs                 # Application entry point
└── CustomerContactApp.csproj  # Project file
```

## How to Run

1. Navigate to the CustomerContactApp directory:
   ```bash
   cd CustomerContactApp
   ```

2. Build the application:
   ```bash
   dotnet build
   ```

3. Run the application:
   ```bash
   dotnet run
   ```

## Usage

The application provides an interactive menu with the following options:

1. **Add Contact**: Add a new customer contact
2. **View All Contacts**: Display all stored contacts
3. **Search Contacts**: Find contacts by search term
4. **Update Contact**: Modify an existing contact
5. **Delete Contact**: Remove a contact (with confirmation)
6. **Exit**: Close the application

### Sample Data

The application comes pre-loaded with three sample contacts:
- Alice Johnson (alice.johnson@email.com, 555-0101)
- Bob Williams (bob.williams@email.com, 555-0102)
- Carol Davis (carol.davis@email.com, 555-0103)

## Development Notes

- Built with .NET 8.0
- Uses in-memory storage for simplicity
- All data is lost when the application closes
- Includes null checks and error handling
- Uses nullable reference types for better code safety

## Future Enhancements

The architecture supports easy extension for:
- File-based persistence
- Database integration
- Web API interface
- Additional contact fields
- Import/export functionality