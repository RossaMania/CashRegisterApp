# CashRegisterApp

## Overview

This project is a C# console application designed to simulate daily purchase transactions in a retail setting. It focuses on debugging and exception handling. The application manages a cash register's money till, calculates the change to be returned to the customer, and handles exceptions that may occur during transactions.

## Features

- Simulate purchase transactions
- Calculate and return change
- Track denominations in the cash register
- Implement exception handling with try-catch patterns

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)

### Running the Project

1. **Clone the repository:**
    ```sh
    git clone https://github.com/yourusername/CashRegisterApp.git
    cd CashRegisterApp
    ```

2. **Build the project:**
    ```sh
    dotnet build
    ```

3. **Run the application:**
    ```sh
    dotnet run --project src/CashRegisterApp
    ```

## Project Details

The `MakeChange` method manages the cash till during transactions. It accepts cash payments and returns change. Exceptions are thrown from within this method and are caught in the calling application.

### Debugging and Exception Handling

- **Debugging:** Use Visual Studio Code to configure breakpoints, step through code, and inspect variables to identify issues.
- **Exception Handling:** Implemented a try-catch pattern in the top-level statements. Created and threw specific exceptions in the `MakeChange` method and caught them in the calling application to ensure precise error handling.

## Certification

This project is part of a training and certification combo on foundational C# offered by Microsoft and freeCodeCamp.org.
## Summary

This project provided experience with:

- Using the Visual Studio Code debugger.
- Implementing try-catch patterns.
- Creating and throwing exceptions.
- Catching exceptions at a higher level of the call stack.

By reviewing, debugging, and implementing exception handling in the cash register application, you gain the skills needed to develop stable and reliable applications.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contributing

Contributions are welcome. Please fork this repository and submit pull requests. For major changes, open an issue first to discuss what you would like to change.
