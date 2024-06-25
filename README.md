# CashRegisterApp

## Overview

This project is a C# console application designed to simulate daily purchase transactions in a retail setting. It focuses on debugging and exception handling. The application manages a cash register's money till, calculates the change to be returned to the customer, and handles exceptions that may occur during transactions.

## Features

- Simulate purchase transactions
- Calculate and return change
- Track denominations in the cash register
- Implement detailed exception handling with specific error messages
- Safely end transactions when the till is out of bills

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)

### Running the Project

1. **Clone the repository:**


2. **Build the project:**
    ```sh
    dotnet build
    ```

3. **Run the application:**
    ```sh
    dotnet run --project src/CashRegisterApp
    ```

## Project Details

The `MakeChange` method manages the cash till during transactions. It accepts cash payments and returns change. The method now includes enhanced exception handling to cover specific scenarios where the till may be out of certain denominations, and throws an exception to end transactions when necessary.

### Key Updates

- **Improved Console Messages:** Updated to provide clear transaction details and outcomes.
- **Detailed Exception Handling:** Specific messages for insufficient payment and till running out of bills.
- **Conditional Store Closure:** The program now conditionally stops further transactions and closes the store when the till is out of necessary bills.

### Debugging and Exception Handling

- **Debugging:** Use Visual Studio Code to configure breakpoints, step through code, and inspect variables to identify issues.
- **Exception Handling:** Implemented a try-catch pattern in the top-level statements. Specific exceptions are created and thrown in the `MakeChange` method and are caught in the main application logic to ensure precise error handling.

### Example Scenario

When a transaction cannot be completed due to the till being out of certain denominations, the application will output a message such as:

```
"The till is unable to make change for the cash provided! Out of ten dollar bills! Store closed!"
```

This ensures the program ends gracefully when the till is unable to provide the correct change.

## Certification

This project is part of a training and certification combo on foundational C# offered by Microsoft and freeCodeCamp.org.

## Summary

This project provided experience with:

- Using the Visual Studio Code debugger.
- Implementing try-catch patterns.
- Creating and throwing specific exceptions.
- Handling exceptions at a higher level of the call stack.
- Managing a cash till with various denominations.

By reviewing, debugging, and implementing exception handling in the cash register application, you gain the skills needed to develop stable and reliable applications.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contributing

Contributions are welcome. Please fork this repository and submit pull requests. For major changes, open an issue first to discuss what you would like to change.
