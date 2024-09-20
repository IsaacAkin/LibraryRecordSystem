namespace LibraryRecordSystem
{
    class Customer
    {
        public int CustomerID;
        public string CustomerName;
        public DateTime DateOfBirth;

        public Customer(int customerID, string customerName, DateTime dateOfBirth)
        {
            CustomerID = customerID;
            CustomerName = customerName;
            DateOfBirth = dateOfBirth;
        }

        public override string ToString()
        {
            return $"{CustomerID} {CustomerName} {DateOfBirth.ToShortDateString()}";
        }

        public int GetCustomerID()
        {
            return CustomerID;
        }

        public void SetCustomerID(int customerID)
        {
            CustomerID = customerID;
        }

        public string GetCustomerName()
        {
            return CustomerName;
        }

        public void SetCustomerName(string customerName)
        {
            CustomerName = customerName;
        }

        public DateTime GetDateOfBirth()
        {
            return DateOfBirth;
        }

        public void SetDateOfBirth(DateTime dateOfBirth)
        {
            DateOfBirth = dateOfBirth;
        }
    }
}