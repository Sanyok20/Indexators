namespace Indexators
{
    class Book
    {
        private string name;
        private DateTime publicationDate;

        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    name = value;
                else
                    name = "No name";
            }
        }

        public DateTime PublicationDate
        {
            get { return publicationDate; }
            set
            {
                if (value <= DateTime.Now)
                    publicationDate = value;
                else
                    publicationDate = DateTime.Now;
            }
        }

        public Book()
        {
            name = "No name";
            publicationDate = new DateTime(2004, 11, 23);
        }

        public Book(string name, DateTime date)
        {
            Name = name;
            PublicationDate = date;
        }

        public void Print()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Date: {PublicationDate.ToShortDateString()}");
        }
    }

    class BookList
    {
        private Book[] books = new Book[100];
        private int count = 0;

        public int Count
        {
            get { return count; }
        }

        public void AddBook(Book book)
        {
            if (count < books.Length)
            {
                books[count++] = book;
            }
            else
            {
                Console.WriteLine("List is full");
            }
        }

        public void RemoveBook(string name)
        {
            for (int i = 0; i < count; i++)
            {
                if (books[i] != null &&
                    books[i].Name == name)
                {
                    for (int j = i; j < count - 1; j++)
                    {
                        books[j] = books[j + 1];
                    }

                    books[--count] = null;

                    Console.WriteLine("Book removed");
                    return;
                }
            }

            Console.WriteLine("Book not found");
        }

        public bool BookInList(string name)
        {
            for (int i = 0; i < count; i++)
            {
                if (books[i] != null &&
                    books[i].Name == name)
                    return true;
            }

            return false;
        }
        public Book this[int index]
        {
            get
            {
                if (index >= 0 && index < count)
                    return books[index];

                return null;
            }

            set
            {
                if (index >= 0 && index < count)
                    books[index] = value;
            }
        }

        public Book this[string name]
        {
            get
            {
                for (int i = 0; i < count; i++)
                {
                    if (books[i].Name == name)
                        return books[i];
                }

                return null;
            }

            set
            {
                for (int i = 0; i < count; i++)
                {
                    if (books[i].Name == name)
                    {
                        books[i] = value;
                        return;
                    }
                }
            }
        }

        public Book this[DateTime date]
        {
            get
            {
                for (int i = 0; i < count; i++)
                {
                    if (books[i].PublicationDate.Date ==
                        date.Date)
                        return books[i];
                }

                return null;
            }

            set
            {
                for (int i = 0; i < count; i++)
                {
                    if (books[i].PublicationDate.Date ==
                        date.Date)
                    {
                        books[i] = value;
                        return;
                    }
                }
            }
        }

        public void ShowAll()
        {
            for (int i = 0; i < count; i++)
            {
                books[i].Print();
                Console.WriteLine();
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            BookList list = new BookList();

            list.AddBook(
                new Book("Stone cross",
                new DateTime(1900, 6, 26)));

            list.AddBook(
                new Book("Sherlock Holmes",
                new DateTime(1887, 11, 1)));

            Console.WriteLine("Checking Stone cross in list");

            Console.WriteLine(list.BookInList("Stone cross") ? "Book exists" : "Book not found");

            Console.WriteLine();

            list[0].Print();

            Console.WriteLine();

            list["Sherlock Holmes"].Print();

            Console.WriteLine();

            Console.WriteLine("Removing Stone cross from list");

            list.RemoveBook("Stone cross");

            Console.WriteLine("Checking Stone cross in list");

            Console.WriteLine(list.BookInList("Stone cross") ? "Book exists" : "Book not found");

            Console.WriteLine("\nAll books:");
            list.ShowAll();
        }
    }
}