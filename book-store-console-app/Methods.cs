using book_store_console_app.Models;
using Microsoft.EntityFrameworkCore;

namespace book_store_console_app
{
    internal static class Methods
    {
        public static void Welcome()
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("Welcome to The Book Store App");
            Console.WriteLine("*****************************");
            Console.WriteLine("");
        }

        public static void ShowMenu()
        {
            Console.WriteLine("========================================================");
            Console.WriteLine("What would you like to do next? Please select an option:");
            Console.WriteLine("1. See all available books");
            Console.WriteLine("2. Search a book");
            Console.WriteLine("3. Exit");
            Console.WriteLine("========================================================");
            Console.WriteLine("");
        }

        public static void GetBooks(string? keyword)
        {
            var context = new BookStoreContext();
            var books = context.TblBooks
                                  .FromSql($"usp_get_books {keyword}")
                                  .ToList();
            if(books.Count == 0)
            {
                Console.WriteLine("***************");
                Console.WriteLine("Book not found!");
                Console.WriteLine("***************");
            }

            if (string.IsNullOrEmpty(keyword))
            {
                Console.WriteLine("***************************");
                Console.WriteLine("List of all available books");
                Console.WriteLine("***************************");
            }

            foreach (var book in books)
                if (string.IsNullOrEmpty(keyword))
                    Console.WriteLine("ISBN: " + book.VcIsbn + ", Title: " + book.VcTitle);
                else
                {
                    Console.WriteLine("************");
                    Console.WriteLine("Book details");
                    Console.WriteLine("************");
                    Console.WriteLine("ISBN: " + book.VcIsbn);
                    Console.WriteLine("Title: " + book.VcTitle);
                    Console.WriteLine("Author: " + book.VcAuthor);
                    Console.WriteLine("Publisher: " + book.VcPublisher);
                    Console.WriteLine("Edition: " + book.VcEdition);
                    Console.WriteLine("Price: $" + book.DecPrice.ToString());
                    Console.WriteLine("Year: $" + book.IntYear.ToString());
                }
        }
    }
}
