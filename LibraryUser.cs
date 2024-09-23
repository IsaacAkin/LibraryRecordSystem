namespace LibraryRecordSystem
{
    abstract class LibraryUser
    {
        protected Database _Database;

        public LibraryUser(Database database)
        {
            _Database = database;
        }

        public abstract void ReturnLoan(int customerID, int isbnNumb);

        public abstract void SearchForBook(string bookName);

        public abstract void SearchForLoansToCustomer(int customerID);
    }
}