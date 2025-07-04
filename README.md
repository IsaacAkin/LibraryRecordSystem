# LibraryRecordSystem

## Overview

The `Library Record System` is a console-based application designed to manage library operations. The system supports two types of users: librarians and customers. Each user type has distinct functionalities:

- `Librarians` can: add, remove, and manage books, customers, and loans.
- `Customers` can: return books, search for books, and view their current loans.

The application is built using C# and user interaction is handled using the command line.

## Pre-requisites

- Install [.NET SDK](https://dotnet.microsoft.com/en-us/download).

## Features

### Librarian Features

- `Add/Remove Books`: Manage the library’s collection of books.
- `Add/Remove Customers`: Maintain a list of library members.
- `Add/Return/Renew Loans`: Manage book loans for customers.
- `View Data`: Display all books, customers, and current loans.
- `Search Functionality`: Search for specific books or customer details.

### Customer Features

- `Return Books`: Return borrowed books to the library.
- `Search for Books`: Search the library catalog for available books.
- `View Current Loans`: Check the list of books currently on loan to the customer.

### General Features

- `User Authentication`: Librarians are authenticated by password; customers are verified via their unique customer ID.
- `Date Input Validation`: The system ensures proper formatting of dates (e.g., customer birthdates).

## Getting Started

1. Clone the repository:

```
git clone https://github.com/IsaacAkin/LibraryRecordSystem.git
cd LibraryRecordSystem
```

2. Build the project:

```
dotnet build
```

3. Run the application:

```
dotnet run
```

## Usage

### Main menu

Upon starting the application, users will be presented with a main menu:

```
Main Menu
1. Log in as librarian
2. Log in as customer
3. Exit
```

Users can select an option by entering the corresponding number.

### Librarian Operations

After successfully logging in as a librarian (via password: `Bookw0rm`), users will access the `Librarian Menu`:

```
Librarian Menu
1. Add/remove/update data
2. Display data
3. Exit to Main Menu
```

#### Add/Remove/Update Data

Librarians can choose to add, remove, or update data such as books, customers, and loans.

#### Display Data

Librarians can view:

- All books in the library.
- All registered customers.
- All current loans.

#### Search Functionality

Search for specific books, customers, or loans using keywords or IDs.

### Customer Operations

Upon logging in as a customer (via customer ID), users will access the `Customer Menu`:

```
Customer Menu
1. Return a book
2. Search for a book
3. Display my current loans
4. Exit to Main Menu
```

Customers can search for books, return borrowed books, and view their current loans.
