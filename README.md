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
├── LMS.Tests/                  # Test project
│   ├── LMS.Tests.csproj        # Test project file
│   └── LibraryManagementSystemShould.cs  # Test class
└── README.md                   # This file
```

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- Visual Studio 2022 or VS Code
- Git

### Running the Tests

```bash
# Navigate to the test project
cd LMS.Tests

# Run all tests
dotnet test

# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"
```

## Development Approach

This project follows Test-Driven Development principles:

1. **Red** - Write a failing test
2. **Green** - Write the minimum code to make the test pass
3. **Refactor** - Clean up the code while keeping tests green

## Features (Planned)

- [ ] Book management (add, remove, search)
- [ ] User management (register, update, delete)
- [ ] Borrowing system (checkout, return, overdue tracking)
- [ ] Inventory tracking
- [ ] Reporting and analytics

## Contributing

This is a learning project focused on TDD practices. Feel free to explore the code and learn from the implementation approach.

## License

This project is open source and available under the MIT License.
