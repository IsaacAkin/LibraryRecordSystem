namespace LibraryRecordSystem
{
    class Loan
    {
        public int CustomerID;
        public int ISBNnumber;
        public DateTime DueDate;

        public Loan(int customerID, int bookISBN, DateTime dueDate)
        {
            CustomerID = customerID;
            ISBNnumber = bookISBN;
            DueDate = dueDate;
        }

        public override string ToString()
        {
            return $"{CustomerID} {ISBNnumber} {DueDate.ToShortDateString()}";
        }

        public int GetCustomerID()
        {
            return CustomerID;
        }

        public void SetCustomerID(int customerID)
        {
            CustomerID = customerID;
        }

        public int GetBookISBN()
        {
            return ISBNnumber;
        }

        public void SetBookISBN(int bookISBN)
        {
            ISBNnumber = bookISBN;
        }

        public DateTime GetDueDate()
        {
            return DueDate;
        }

        public void SetDueDate(DateTime dueDate)
        {
            DueDate = dueDate;
        }
    }
}