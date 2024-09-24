namespace LibraryRecordSystem
{
    class LibrarianInterface : LibraryUser
    {
        private Database _database;
        public bool isAuthenticated { get; private set; }
        public LibrarianInterface(Database database, string password) : base(database)
        {
            _database = database;
            if (database.GetPassword(password))
            {
                isAuthenticated = true;
            }
            else
            {
                isAuthenticated = false;
                Console.WriteLine("Incorrect password. Please try again.");
            }
        }

        public void AddBook(string bookName, string author)
        {
            _database.AddBook(bookName, author);
        }

        public void RemoveBook(int isbnNumb)
        {
            _database.RemoveBook(isbnNumb);
        }

        public void AddCustomer(string customerName, DateTime dateOfBirth)
        {
            _database.AddCustomer(customerName, dateOfBirth);
        }

        public void RemoveCustomer(int customerID)
        {
            _database.RemoveCustomer(customerID);
        }

        public void AddLoan(int customerID, int isbnNumb)
        {
            _database.AddLoan(customerID, isbnNumb);
        }

        public override void ReturnLoan(int customerID, int isbnNumb)
        {
            _database.ReturnLoan(customerID, isbnNumb);
        }

        public void RenewLoan(int customerID, int isbnNumb)
        {
            _database.RenewLoan(customerID, isbnNumb);
        }

        public void DisplayAllBooks()
        {
            _database.DisplayAllBooks();
        }

        public void DisplayAllCustomers()
        {
            _database.DisplayAllCustomers();
        }

        public void DisplayAllLoans()
        {
            _database.DisplayAllLoans();
        }

        public override void SearchForBook(string bookName)
        {
            _database.SearchForBook(bookName);
        }

        public void SearchForCustomer(string customerName, int customerID)
        {
            _database.SearchForCustomer(customerName, customerID);
        }

        public override void SearchForLoansToCustomer(int customerID)
        {
            _database.SearchForLoansToCustomer(customerID);
        }
    }
}