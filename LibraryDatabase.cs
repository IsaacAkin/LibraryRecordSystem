namespace LibraryRecordSystem
{
    class LibraryDatabase
    {
        public List<Book> Books = new List<Book>();
        public List<Customer> Customers = new List<Customer>();
        public List<Loan> Loans = new List<Loan>();
        private const string LibrarianPassword = "Bookw0rm";

        Random random = new Random();

        public bool PasswordManager(string password)
        {
            if (password == LibrarianPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*Options relating to adding and removing data*/
        // Methods for adding and removing books.
        public void AddBook(string bookName, string author)
        {
            int isbnNumb = random.Next(10000000, 99999999);
            Book newBook = new Book(bookName, author, isbnNumb, DateTime.Now);
            Books.Add(newBook);
            Console.WriteLine($"{bookName} with ISBN {isbnNumb} added to the database on {DateTime.Now.ToShortDateString()}.");
        }

        public void RemoveBook(int isbnNumb)
        {
            Book bookToRemove = GetBookByISBN(isbnNumb);
            if (bookToRemove != null)
            {
                Books.Remove(bookToRemove);
                Console.WriteLine($"{bookToRemove.Name} with ISBN {isbnNumb} removed from the database.");
            }
            else
            {
                Console.WriteLine($"{bookToRemove.Name} with ISBN {isbnNumb} not found in the database.");
            }
        }

        public Book GetBookByISBN(int isbnNumb)
        {
            foreach (Book book in Books)
            {
                if (book.ISBNnumber == isbnNumb)
                {
                    return book;
                }
            }
            return null;
        }

        // Methods for adding and removing customers.
        public void AddCustomer(string customerName, DateTime dateOfBirth)
        {
            int customerID = random.Next(0, 999);
            Customer newCustomer = new Customer(customerID, customerName, dateOfBirth);
            Customers.Add(newCustomer);
            Console.WriteLine($"{customerName} with date of birth{DateTime.Now.ToShortDateString()} added to the database wit customer ID: {customerID}.");
        }

        public void RemoveCustomer(int customerID)
        {
            Customer customerToRemove = GetCustomerByID(customerID);
            if (customerToRemove != null)
            {
                Customers.Remove(customerToRemove);
                Console.WriteLine($"{customerToRemove.CustomerName} with customer ID {customerID} removed from the database.");
            }
            else
            {
                Console.WriteLine($"{customerToRemove.CustomerName} with customer ID {customerID} not found in the database.");
            }
        }

        public Customer GetCustomerByID(int customerID)
        {
            foreach (Customer customer in Customers)
            {
                if (customer.CustomerID == customerID)
                {
                    return customer;
                }
            }
            return null;
        }

        // Methods for adding and removing loans.
        public void AddLoan(int customerID, int isbnNumb)
        {
            Loan loan = new Loan(customerID, isbnNumb, DateTime.Now.AddDays(14));
            Loans.Add(loan);
            Console.WriteLine($"{customerID} has been given a book {DateTime.Now.AddDays(14).ToShortDateString()}.");
        }

        public void RemoveLoan(int customerID, int isbnNumb)
        {
            Loan loanToRemove = GetLoanByIDandISBN(customerID, isbnNumb);
            if (loanToRemove != null)
            {
                Loans.Remove(loanToRemove);
                Console.WriteLine($"{loanToRemove.CustomerID} has returned the book.");
            }
            else
            {
                Console.WriteLine($"{loanToRemove.CustomerID}, {loanToRemove.ISBNnumber} has not been found in the database.");
            }
        }

        public void RenewLoan(int customerID, int isbnNumb)
        {
            Loan loanToRenew = GetLoanByIDandISBN(customerID, isbnNumb);
            if (loanToRenew != null)
            {
                loanToRenew.DueDate = DateTime.Now.AddDays(14);
                Console.WriteLine($"{loanToRenew.CustomerID} has renewed the book till {loanToRenew.DueDate.ToShortDateString()}.");
            }
            else
            {
                Console.WriteLine($"We were unable to renew {loanToRenew.CustomerID}'s loan as the ISBN number {loanToRenew.ISBNnumber} could not been found in the database.");
            }
        }

        public Loan GetLoanByIDandISBN(int customerID, int isbnNumb)
        {
            foreach (Loan loan in Loans)
            {
                if (loan.CustomerID == customerID && loan.ISBNnumber == isbnNumb)
                {
                    return loan;
                }
            }
            return null;
        }

        /*Options relating to displaying data*/
        public void DisplayBooks()
        {
            if (Books.Count != 0)
            {
                foreach (Book registeredBook in Books)
                {
                    Console.WriteLine(registeredBook.ToString());
                }
            }
            else
            {
                Console.WriteLine("No books in the database.");
            }
        }

        public void DisplayAllCustomers()
        {
            if (Customers.Count != 0)
            {
                foreach (Customer registeredCustomer in Customers)
                {
                    Console.WriteLine(registeredCustomer.ToString());
                }
            }
            else
            {
                Console.WriteLine("No customers in the database.");
            }
        }

        public void DisplayAllLoans()
        {
            if (Loans.Count != 0)
            {
                foreach (Loan registeredLoan in Loans)
                {
                    Console.WriteLine(registeredLoan.ToString());
                }
            }
            else
            {
                Console.WriteLine("No loans in the database.");
            }
        }

        /*Options relating to searching data*/
        public void SearchForBook(string bookName)
        {
            foreach (Book registeredBook in Books)
            {
                if (registeredBook.Name == bookName)
                {
                    Console.WriteLine(registeredBook.ToString());
                }
                else
                {
                    Console.WriteLine("No books with that name in the database.");
                }
            }
        }

        public void SearchForCustomer(string customerName, int customerID)
        {
            foreach (Customer registeredCustomer in Customers)
            {
                if (registeredCustomer.CustomerName == customerName || registeredCustomer.CustomerID == customerID)
                {
                    Console.WriteLine(registeredCustomer.ToString());
                }
                else
                {
                    Console.WriteLine("No customers with that name or ID in the database.");
                }
            }
        }

        public void SearchForBooksOnLoanToCustomer(int customerID)
        {
            foreach (Loan registeredLoan in Loans)
            {
                if (registeredLoan.CustomerID == customerID)
                {
                    Console.WriteLine(registeredLoan.ToString());
                }
                else
                {
                    Console.WriteLine("No books on loan to that customer.");
                }
            }
        }
    }
}