using System;
using System.Collections.Generic;
using Book;

namespace Homework1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookDataAccess dal = new BookDataAccess();
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== Library Menu ===");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3. Find Book by ID");
                Console.WriteLine("4. Create Backup");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option (1-5): ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\n--- Add New Book ---");
                        Console.WriteLine("Enter ID: ");
                        int id = int.Parse(Console.ReadLine() ?? "0");
                        Console.WriteLine("Enter Title: ");
                        string title = Console.ReadLine() ?? "";
                        Console.WriteLine("Enter Author: ");
                        string author = Console.ReadLine() ?? "";
                        Console.WriteLine("Enter Price: ");
                        double price = double.Parse(Console.ReadLine() ?? "0");

                        Book.Book newBook = new Book.Book(id, title, author, price);
                        dal.AddBook(newBook);
                        Console.WriteLine("Book added successfully.");
                        break;
                    case "2":
                        List<Book.Book> books = dal.ViewAllBooks();
                        if (books.Count == 0)
                        {
                            Console.WriteLine("No books found.");
                        }
                        else
                        {
                            foreach (Book.Book b in books)
                            {
                                b.DisplayInfo();
                            }
                        }
                        break;
                    case "3":
                        Console.Write("\nEnter Book ID to search: ");
                        int searchId = int.Parse(Console.ReadLine() ?? "0");
                        Book.Book foundBook = dal.FindBookById(searchId);

                        if (foundBook != null)
                        {
                            foundBook.DisplayInfo();
                        }
                        else
                        {
                            Console.WriteLine("Book not found.");
                        }
                        break;
                    case "4":
                        dal.CreateBackup();
                        Console.WriteLine("Backup created successfully.");
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("Exiting application. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please enter a number between 1 and 5.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey();
                }
            }
        }
    }
}
