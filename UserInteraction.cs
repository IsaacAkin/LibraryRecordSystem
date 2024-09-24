using System.Globalization;

namespace LibraryRecordSystem
{
    class UserInteraction
    {
        public static void Main(string[] args)
        {
            // Setting up the database and interfaces
            Database database = new Database();
            LibrarianInterface librarian;
            CustomerInterface customer;

            // Variable to store user choice
            int userChoice;

            do
            {
                int customerID;

                MainMenu();
                userChoice = GetUserChoice();

                switch (userChoice)
                {
                    case 1:
                        bool isAuthenticated = false;
                        while (!isAuthenticated)
                        {
                            Console.WriteLine("Enter the password:");
                            string? password = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(password))
                            {
                                librarian = new LibrarianInterface(database, password);
                                if (librarian.isAuthenticated)
                                {
                                    isAuthenticated = true;
                                    LibrarianMenu(librarian);
                                }
                            }
                        }
                        break;

                    case 2:
                        bool isVerified = false;
                        while (!isVerified)
                        {
                            Console.WriteLine("Enter your customer ID:");
                            string? userInput = Console.ReadLine();
                            if (int.TryParse(userInput, out customerID))
                            {
                                customer = new CustomerInterface(database, customerID);
                                if (customer.isVerified)
                                {
                                    isVerified = true;
                                    CustomerMenu(customer, customerID);
                                }
                            }
                        }
                        break;

                    case 3:
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please select a valid option (1-3):");
                        break;
                }
            } while (userChoice != 3);

        }

        // Method to get user choice of input making sure that it's a valid number
        static int GetUserChoice()
        {
            int userChoice = -1;
            do
            {
                try
                {
                    string? userInput = Console.ReadLine();
                    userChoice = int.Parse(userInput);
                }
                catch
                {
                    Console.WriteLine("Invalid number. Please enter a valid number.");
                }
            } while (userChoice < 1 || userChoice > 8);

            return userChoice;
        }

        // Main Menu
        static void MainMenu()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Log in as librarian");
            Console.WriteLine("2. Log in as customer");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Please select an option (1-3):");
        }

        // Librarian Menu
        static void LibrarianMenu(LibrarianInterface librarian)
        {
            int userChoice;

            do
            {

                Console.WriteLine("Librarian Menu");
                Console.WriteLine("1. Add/remove/update data");
                Console.WriteLine("2. Display data");
                Console.WriteLine("3. Exit to Main Menu");
                Console.WriteLine("Please select an option (1-3):");

                userChoice = GetUserChoice();

                switch (userChoice)
                {
                    case 1:
                        AddRemoveDataMenu(librarian);
                        break;

                    case 2:
                        DisplayDataMenu(librarian);
                        break;

                    case 3:
                        MainMenu();
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please select a valid option (1-3):");
                        break;
                }
            } while (userChoice != 3);
        }

        // Add/Remove/Update Data Menu
        static void AddRemoveDataMenu(LibrarianInterface librarian)
        {

            int userChoice;

            do
            {
                Console.WriteLine("Add/Remove Data");
                Console.WriteLine("1. Add book");
                Console.WriteLine("2. Remove book");
                Console.WriteLine("3. Add customer");
                Console.WriteLine("4. Remove customer");
                Console.WriteLine("5. Add loan");
                Console.WriteLine("6. Return loan");
                Console.WriteLine("7. Renew book");
                Console.WriteLine("8. Exit to Librarian Menu");
                Console.WriteLine("Please select an option (1-8):");

                userChoice = GetUserChoice();

                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("Enter the name of the book you would like to add:");
                        string? nameOfBook = Console.ReadLine();
                        Console.WriteLine("Enter the author of the book:");
                        string? author = Console.ReadLine();
                        librarian.AddBook(nameOfBook, author);
                        break;

                    case 2:
                        Console.WriteLine("Enter the ISBN number of the book you would like to remove:");
                        int isbnNumber = int.Parse(Console.ReadLine());
                        librarian.RemoveBook(isbnNumber);
                        break;

                    case 3:
                        Console.WriteLine("Enter the name of the customer you would like to add:");
                        string? customerName = Console.ReadLine();
                        Console.WriteLine("Enter the date of birth of the customer(DD/MM/YYYY):");
                        // DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
                        DateTime dateOfBirth = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        librarian.AddCustomer(customerName, dateOfBirth);
                        break;

                    case 4:
                        Console.WriteLine("Enter the ID of the customer you would like to remove:");
                        int customerID = int.Parse(Console.ReadLine());
                        librarian.RemoveCustomer(customerID);
                        break;

                    case 5:
                        Console.WriteLine("Enter the ID of the customer who would like to take out a book:");
                        customerID = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the ISBN number of the book:");
                        isbnNumber = int.Parse(Console.ReadLine());
                        librarian.AddLoan(customerID, isbnNumber);
                        break;

                    case 6:
                        Console.WriteLine("Enter the ID of the customer who would like to return their book:");
                        customerID = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the ISBN number of the book:");
                        isbnNumber = int.Parse(Console.ReadLine());
                        librarian.ReturnLoan(customerID, isbnNumber);
                        break;

                    case 7:
                        Console.WriteLine("Enter the ID of the customer who would like to renew their book:");
                        customerID = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the ISBN number of the book:");
                        isbnNumber = int.Parse(Console.ReadLine());
                        librarian.RenewLoan(customerID, isbnNumber);
                        break;

                    case 8:
                        LibrarianMenu(librarian);
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please select a valid option (1-8):");
                        break;
                }
            }
            while (userChoice != 8);
        }

        // Display Data Menu
        static void DisplayDataMenu(LibrarianInterface librarian)
        {
            int userChoice;
            do
            {
                Console.WriteLine("Display Data");
                Console.WriteLine("1. Display all books");
                Console.WriteLine("2. Display all customers");
                Console.WriteLine("3. Display all loans");
                Console.WriteLine("4. Search for a Book");
                Console.WriteLine("5. Search for a Customer");
                Console.WriteLine("6. Search for all books on loan to a customr");
                Console.WriteLine("7. Exit to Librarian Menu");
                Console.WriteLine("Please select an option (1-7):");

                userChoice = GetUserChoice();

                switch (userChoice)
                {
                    case 1:
                        librarian.DisplayAllBooks();
                        break;
                    case 2:
                        librarian.DisplayAllCustomers();
                        break;
                    case 3:
                        librarian.DisplayAllLoans();
                        break;
                    case 4:
                        Console.WriteLine("Enter the name of the book you would like to search for:");
                        string? bookName = Console.ReadLine();
                        librarian.SearchForBook(bookName);
                        break;
                    case 5:
                        Console.WriteLine("Enter the name of the customer you would like to search for:");
                        string? customerName = Console.ReadLine();
                        Console.WriteLine("Enter the ID of the customer you would like to search for:");
                        int customerID = int.Parse(Console.ReadLine());
                        librarian.SearchForCustomer(customerName, customerID);
                        break;
                    case 6:
                        Console.WriteLine("Enter the ID of the customer whose loans you would like to search for:");
                        customerID = int.Parse(Console.ReadLine());
                        librarian.SearchForLoansToCustomer(customerID);
                        break;
                    case 7:
                        LibrarianMenu(librarian);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please select a valid option (1-7):");
                        break;
                }
            } while (userChoice != 7);
        }

        // Customer Menu
        static void CustomerMenu(CustomerInterface customer, int customerID)
        {
            int userChoice;

            do
            {
                Console.WriteLine("Customer Menu");
                Console.WriteLine("1. Return a book");
                Console.WriteLine("2. Search for a book");
                Console.WriteLine("3. Display my current loans");
                Console.WriteLine("4. Exit to Main Menu");
                Console.WriteLine("Please select an option (1-4):");

                userChoice = GetUserChoice();

                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("Enter the ISBN number of the book you would like to return:");
                        int isbnNumber = int.Parse(Console.ReadLine());
                        customer.ReturnLoan(customerID, isbnNumber);
                        break;

                    case 2:
                        Console.WriteLine("Enter the name of the book you would like to search for:");
                        string? bookName = Console.ReadLine();
                        customer.SearchForBook(bookName);
                        break;

                    case 3:
                        customer.SearchForLoansToCustomer(customerID);
                        break;

                    case 4:
                        MainMenu();
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please select a valid option (1-4):");
                        break;
                }
            } while (userChoice != 4);
        }
    }
}