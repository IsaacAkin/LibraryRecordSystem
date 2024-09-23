namespace LibraryRecordSystem
{
    class Book
    {
        public string NameOfBook;
        public string Author;
        public int ISBNnumber;
        public DateTime AcquisitionDate;

        public Book(string nameOfBook, string author, int isbnNumb, DateTime acquisitionDate)
        {
            NameOfBook = nameOfBook;
            Author = author;
            ISBNnumber = isbnNumb;
            AcquisitionDate = acquisitionDate;
        }

        public override string ToString()
        {
            return $"{NameOfBook} {Author} {ISBNnumber} {AcquisitionDate.ToShortDateString()}";
        }

        public string GetNameOfBook()
        {
            return NameOfBook;
        }

        public void SetNameOfBook(string nameOfBook)
        {
            NameOfBook = nameOfBook;
        }

        public string GetAuthor()
        {
            return Author;
        }

        public void SetAuthor(string author)
        {
            Author = author;
        }

        public int GetISBN()
        {
            return ISBNnumber;
        }

        public void SetISBN(int isbnNumb)
        {
            ISBNnumber = isbnNumb;
        }

        public DateTime GetAcquisitionDate()
        {
            return AcquisitionDate;
        }

        public void SetAcquisitionDate(DateTime acquisitionDate)
        {
            AcquisitionDate = acquisitionDate;
        }
    }
}