namespace LibraryRecordSystem
{
    class Book
    {
        public string Name;
        public string Author;
        public int ISBNnumber;
        public DateTime AcquisitionDate;

        public Book(string name, string author, int isbnNumb, DateTime acquisitionDate)
        {
            Name = name;
            Author = author;
            ISBNnumber = isbnNumb;
            AcquisitionDate = acquisitionDate;
        }

        public override string ToString()
        {
            return $"{Name} {Author} {ISBNnumber} {AcquisitionDate.ToShortDateString()}";
        }

        public string GetName()
        {
            return Name;
        }

        public void SetName(string name)
        {
            Name = name;
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