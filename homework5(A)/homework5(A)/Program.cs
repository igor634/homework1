using System.ComponentModel.Design;
using System.Runtime.Intrinsics.X86;

namespace homework5_A_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Book b1 = new Book("It", "Stephen King", 2011, 215, "horror");
            Book b2 = new Book("Vampire", "Hershel Snitch", 1967, 165, "detective");
            Book b3 = new Book("Romeo and Juliet", "William Shakespeare", 1595, 196, "drama");

            
            Console.WriteLine("Введите год для выбора книг: ");
            int inputYear = Convert.ToInt32(Console.ReadLine());

            
            List<Book> selectedBooks = GetBooksByYear(inputYear, b1, b2, b3);

            if (selectedBooks.Count > 0)
            {
                Console.WriteLine("Подходящие книги:");
                foreach (var book in selectedBooks)
                {
                    Console.WriteLine(book.ToString());
                }

                
                Reader reader = new Reader("Иван", "Иванов", "123456");

                foreach (var book in selectedBooks)
                {
                    reader.BorrowBook(book);
                }

                
                reader.ListBorrowedBooks();

                
                foreach (var book in selectedBooks)
                {
                    reader.ReturnBook(book);
                }

                
                reader.ListBorrowedBooks();
            }
            else
            {
                Console.WriteLine("Нет книг, выпущенных после введенного года.");
            }
        }

        public static List<Book> GetBooksByYear(int year, params Book[] books)
        {
            List<Book> matchingBooks = new List<Book>();

            foreach (var book in books)
            {
                if (book.data >= year)
                {
                    matchingBooks.Add(book);
                }
            }

            return matchingBooks;
        }

        public class Book
        {
            public string name;
            public string author;
            public int data; // Год
            public int pages;
            public string type;

            public Book(string name, string author, int data, int pages, string type)
            {
                this.name = name;
                this.author = author;
                this.data = data;
                this.pages = pages;
                this.type = type;
            }

            public override string ToString()
            {
                return $"Название: {name}, Автор: {author}, Год: {data}, Страницы: {pages}, Жанр: {type}";
            }
        }

        public class Reader
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string TicketNumber { get; set; }
            public List<Book> BorrowedBooks { get; private set; }

            public Reader(string firstName, string lastName, string ticketNumber)
            {
                FirstName = firstName;
                LastName = lastName;
                TicketNumber = ticketNumber;
                BorrowedBooks = new List<Book>();
            }

            public void BorrowBook(Book book)
            {
                BorrowedBooks.Add(book);
                Console.WriteLine($"{FirstName} {LastName} borrowed \"{book.name}\".");
            }

            public void ReturnBook(Book book)
            {
                if (BorrowedBooks.Remove(book))
                {
                    Console.WriteLine($"{FirstName} {LastName} returned \"{book.name}\".");
                }
                else
                {
                    Console.WriteLine($"{FirstName} {LastName} did not borrow \"{book.name}\".");
                }
            }

            public void ListBorrowedBooks()
            {
                Console.WriteLine($"{FirstName} {LastName} has borrowed the following books:");
                foreach (var book in BorrowedBooks)
                {
                    Console.WriteLine($"- \"{book.name}\" by {book.author}");
                }
            }
        }
    }
}