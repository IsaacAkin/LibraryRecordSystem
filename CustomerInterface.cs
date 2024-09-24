namespace LibraryRecordSystem
{
    class CustomerInterface : LibraryUser
    {
        private Database _database;
        public bool isVerified { get; private set; }

        public CustomerInterface(Database database, int customerID) : base(database)
        {
            _database = database;
            if (database.VerifyCustomerID(customerID))
            {
                isVerified = true;
            }
            else
            {
                isVerified = false;
                Console.WriteLine("Customer ID not found. Please try again.");
            }
        }

        public override void ReturnLoan(int customerID, int isbnNumb)
        {
            _database.ReturnLoan(customerID, isbnNumb);
        }

        public override void SearchForBook(string bookName)
        {
            _database.SearchForBook(bookName);
        }

        public override void SearchForLoansToCustomer(int customerID)
        {
            _database.SearchForLoansToCustomer(customerID);
        }
    }
}