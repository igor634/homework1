namespace homework7_A_
{
    using System;
    using System.Collections.Generic;

    public enum BookFormat
    {
        Hardcover,  
        Paperback,  
        Ebook,     
        Audiobook   
    }

    public enum BookGenre
    {
        Fiction,        
        NonFiction,      
        Mystery,         
        ScienceFiction  
    }

    public class Book
    {
        public readonly string Title;
        public readonly string Author;
        public readonly BookFormat Format;
        public readonly BookGenre Genre;

        public Book(string title, string author, BookFormat format, BookGenre genre)
        {
            Title = title;
            Author = author;
            Format = format;
            Genre = genre;
        }

        public override string ToString()
        {
            return $"{Title} by {Author}, Format: {Format}, Genre: {Genre}";
        }
    }

    public static class LibraryConfig
    {
       
        public static readonly int MaxBooksInLibrary = 100;
        
        private static List<Book> Books = new List<Book>();
       
        public static int TotalBorrowedBooks { get; private set; }

        
        public static bool AddBook(Book book)
        {
            if (Books.Count < MaxBooksInLibrary)
            {
                Books.Add(book);
                Console.WriteLine($"Book '{book.Title}' added to the library.");
                return true;
            }
            else
            {
                Console.WriteLine("Library is full, cannot add more books.");
                return false;
            }
        }

        
        public static bool BorrowBook(string title)
        {
            Book bookToBorrow = Books.Find(book => book.Title == title);
            if (bookToBorrow != null)
            {
                Books.Remove(bookToBorrow);
                TotalBorrowedBooks++;
                Console.WriteLine($"Book '{title}' has been borrowed.");
                return true;
            }
            else
            {
                Console.WriteLine($"Book '{title}' is not available.");
                return false;
            }
        }

        
        public static bool ReturnBook(Book book)
        {
            if (Books.Count < MaxBooksInLibrary)
            {
                Books.Add(book);
                TotalBorrowedBooks--;
                Console.WriteLine($"Book '{book.Title}' has been returned.");
                return true;
            }
            else
            {
                Console.WriteLine("Library is full, cannot return the book.");
                return false;
            }
        }

        
        public static bool IsBookAvailable(string title)
        {
            return Books.Exists(book => book.Title == title);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            
            Book book1 = new Book("Dune", "Frank Herbert", BookFormat.Hardcover, BookGenre.ScienceFiction);
            Book book2 = new Book("1984", "George Orwell", BookFormat.Paperback, BookGenre.Fiction);
            Book book3 = new Book("Becoming", "Michelle Obama", BookFormat.Ebook, BookGenre.NonFiction);

            
            LibraryConfig.AddBook(book1);
            LibraryConfig.AddBook(book2);
            LibraryConfig.AddBook(book3);

            
            Console.WriteLine($"Is 'Dune' available? {LibraryConfig.IsBookAvailable("Dune")}");

           
            LibraryConfig.BorrowBook("Dune");

            
            Console.WriteLine($"Is 'Dune' available? {LibraryConfig.IsBookAvailable("Dune")}");

           
            LibraryConfig.ReturnBook(book1);

            
            Console.WriteLine($"Total borrowed books: {LibraryConfig.TotalBorrowedBooks}");
        }
    }
}
