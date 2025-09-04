# C# Library Management System - TDD Approach

A Library Management System built in C# using Test-Driven Development (TDD) principles.

## Project Overview

This project demonstrates building a Library Management System from scratch using TDD methodology. The goal is to create a robust, well-tested system for managing library operations including book management, user management, and borrowing/returning processes.

## Technology Stack

- **.NET 8.0**
- **NUnit** for testing framework
- **C#** as the primary language
- **Test-Driven Development (TDD)** methodology

## Project Structure

```
LibraryManager/
├── LibraryManager.sln          # Solution file
├── LMS.BusinessLogic/          # Business logic project
│   ├── Book.cs                 # Book entity
│   ├── BookRepository.cs       # Book data access (Repository pattern)
│   └── LMS.BusinessLogic.csproj # Business logic project file
├── LMS.Tests/                  # Test project
│   ├── LMS.Tests.csproj        # Test project file
│   └── LibraryManagementSystemShould.cs  # Test class (27 test cases)
├── TDDBookManagement.md        # Detailed TDD implementation guide
└── README.md                   # This file
```

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- Visual Studio 2022 or VS Code
- Git

### Running the Tests

```bash
# Run all tests from the solution root
dotnet test

# Run tests with verbose output
dotnet test --verbosity normal

# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"
```

## Current Implementation

### ✅ **Completed Features**

- **Book Management** - Complete with Repository pattern
  - Add books with duplicate prevention
  - Remove books by ISBN
  - Get book count
  - Retrieve books by ISBN
  - Check if book exists

### 📊 **Test Coverage**

- **27 test cases** covering all functionality
- **7 test methods** using comprehensive `[TestCase]` attributes
- **100% coverage** for implemented features
- **Edge cases** and **error scenarios** included

### 🏗️ **Architecture**

- **BookRepository**: Data access layer using Repository pattern
- **Book**: Domain entity with immutable properties
- **Clear separation** of concerns
- **Future-proof** for database integration

## Development Approach

This project follows Test-Driven Development principles:

1. **Red** - Write a failing test
2. **Green** - Write the minimum code to make the test pass
3. **Refactor** - Clean up the code while keeping tests green

### TDD Process Demonstrated

- **Test-First Development**: All functionality was test-driven
- **Incremental Implementation**: Features added one at a time
- **Comprehensive Testing**: Edge cases and error scenarios covered
- **Refactoring**: Code improved while maintaining test coverage

## Features (Planned)

- [x] Book management (add, remove, search) ✅ **COMPLETED**
- [ ] User management (register, update, delete)
- [ ] Borrowing system (checkout, return, overdue tracking)
- [ ] Inventory tracking
- [ ] Reporting and analytics

## Key Classes

### BookRepository
```csharp
public class BookRepository
{
    public void AddBook(Book book)           // Add with duplicate prevention
    public bool HasBook(string isbn)         // Check if book exists
    public void RemoveBook(string isbn)       // Remove by ISBN
    public int GetBookCount()                // Get total count
    public Book GetBookByIsbn(string isbn)    // Retrieve by ISBN
}
```

### Book
```csharp
public class Book
{
    public string Title { get; }   // Book title
    public string Author { get; }  // Book author
    public string Isbn { get; }    // Unique identifier
}
```

## Documentation

- **TDDBookManagement.md**: Detailed TDD implementation guide
- **Test Cases**: Living documentation of expected behavior
- **Code Comments**: Clear explanations of functionality

## Contributing

This is a learning project focused on TDD practices. Feel free to explore the code and learn from the implementation approach.

## License

This project is open source and available under the MIT License.
