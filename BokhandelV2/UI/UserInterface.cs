using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BokhandelV2.UI;
using BokhandelV2.Data;
using BokhandelV2.Models;

namespace BokhandelV2.UI
{
    public class UserInterface
    {
        DataAccess db = new DataAccess();

        public void UserUI()   //Menu
        {
           
            Console.WriteLine("-----------------------------------------Welcome to the bokhandel application---------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Below you can find multiple key options on how to use the application.");
            Console.WriteLine();
            Console.WriteLine("Press \"S\" to showcase the Stockbalance.");
            Console.WriteLine("Press \"A\" to add a book.");
            Console.WriteLine("Press \"R\" to remove a book");
            Console.WriteLine("Press \"L\" to list all books");
            Console.WriteLine("Press \"X\" to Exit program");
            
        }

        public void ButtonOptions() //Button options for completing different tasks.
        {
            while (true)
            {
                UserUI();
                
                char InitialInput = (char)Console.Read();
                InitialInput = char.ToUpper(InitialInput);
                switch (InitialInput)
                {
                    case 'S':
                        Console.WriteLine("[ID]\t[ISBN13]\t   [Quantity]");
                        showStockBalance();
                        break;
                    case 'A':
                        AddBook();
                        Console.WriteLine("The book has been successfully added...");
                        break;
                    case 'R':
                        Console.WriteLine("Which book do you want to delete?");
                        showAllBooks();
                        RemoveInput();
                        break;
                    case 'L':
                        Console.WriteLine("[ISBN13]\t\t  [Title]\t\t\t [Language]  [Price] [Release date]     [AuthorID]");
                        showAllBooks();
                        break;
                    case 'X':
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid key, try again");
                        break;
                }
            }
        }

        public int AddAuthor()
        {
            var result = new Author();
            Console.WriteLine("What is the first, lastname and birthdate of the author for the book you want to add?");

            string nothing = Console.ReadLine();

            Console.Write("FirstName: ");
            result.FirstName = Console.ReadLine();

            Console.Write("LastName: ");
            result.LastName = Console.ReadLine();

            Console.WriteLine("Birthdate: ");
            result.Birthdate = DateTime.Parse(Console.ReadLine());


            var author = db.FindAuthor(result.FirstName, result.LastName);
            

            if (author == null)
            {
                return db.AddingAuthor(result);
            }
            else
            {
                Console.WriteLine("This author already exist and his/her authorID is {0}.", author.Id);
                return author.Id;
            }
        }

        private void showAllBooks()
        {
            var books = db.ListAllBooks();
            foreach (var book in books)
            {
                Console.WriteLine("{0, -20} {1, -38} {2, -10} {3, -5} {4, -15} {5, 6}", book.Isbn13, book.Title, book.Language, book.Price, book.ReleaseDate, book.AuthorId);
            }
        }

        private void showStockBalance()
        {
            var shops = db.StockBalance();
            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.ShopsId}\t   {shop.BooksIsbn13}\t   {shop.Quantity}");
            }

        }

        public Book UserInputBook()   //The neccessary inputs to add an existing och a new book.
        {
            var result = new Book();

            Console.WriteLine("Put in the neccessary information to add a new book(ENTER to continue after each input).");
            Console.Write("(Unique)ISBN13:");
            result.Isbn13 = Console.ReadLine();

            Console.Write("Title:");
            result.Title = Console.ReadLine();

            Console.Write("Language:");
            result.Language = Console.ReadLine();

            Console.Write("Price:");
            result.Price = float.Parse(Console.ReadLine());

            Console.Write("Release Date:");
            result.ReleaseDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("AuthorID:");
            result.AuthorId = int.Parse(Console.ReadLine());

            return result;

        }

        public void RemoveInput()   //The userinput for the specific book to be removed.
        {
            var result = new Book();

            Console.WriteLine("Put in the (Unique)ISBN13 for the book you want to remove(Enter to continue).");
            Console.Write("(Unique)ISBN13: ");
            string nothing = Console.ReadLine();
            result.Isbn13 = Console.ReadLine();

            var bookRemove = db.FindBook(result.Isbn13);
            if (bookRemove != null)
            {
                db.RemovingBook(result);
                Console.WriteLine("Deleted successfully.....");
            }
            else
            {
                Console.WriteLine("This book doesn't exists in the database.");
            }
        }

        public void AddBook()
        {
            showAllBooks();
            Console.WriteLine("Does the book you want to add exist? Press 'Y' if yes or 'N' if no.");
            string nth = Console.ReadLine();
            char answer = (char)Console.Read();
            answer = char.ToUpper(answer);

            switch (answer)
            {
                case 'Y':
                    var book = UserInputBook();
                    db.AddingBook(book);
                    break;
                case 'N':
                    AddAuthor();
                    var book2 = UserInputBook();
                    db.AddingBook(book2);
                    break ;

                default:
                    break;
            }
        }
    }
}
