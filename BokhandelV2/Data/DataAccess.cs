using BokhandelV2.Models;
using BokhandelV2.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokhandelV2.Data
{
    public class DataAccess
    {
        public List<StockBlance> StockBalance()
        {
            using (var context = new BokhandelContext())
            {
                var shops = context.StockBlances.ToList();
                return shops;
            }
        }

        public void AddingBook(Book book)
        {            
            using (var context = new BokhandelContext())
            {                
                context.Books.Add(book);
                context.SaveChanges();
            }
        }

        public void RemovingBook(Book book)
        {

            using (var context = new BokhandelContext())
            {

                context.Books.Remove(book);
                context.SaveChanges();
            }
        }

        public List<Book> ListAllBooks()
        {
            using (var context = new BokhandelContext())
            {
                var books = context.Books.ToList();

                return books;
            }
        }

        public int AddingAuthor(Author author)
        {
            using (var context = new BokhandelContext())
            {
                context.Authors.Add(author);
                context.SaveChanges();
                Console.WriteLine("AuthorID = {0}", author.Id);
                return author.Id;
            }
        }

        public Author FindAuthor(string firstName, string lastName)
        {
            using (var context = new BokhandelContext())
            {
                var result = context.Authors.SingleOrDefault(a => a.FirstName==firstName && a.LastName==lastName);
                return result;
            }
        }

        public Book FindBook(string ISBN13)
        {
            using (var context = new BokhandelContext())
            {
                var result = context.Books.FirstOrDefault(b => b.Isbn13 == ISBN13);
                return result;
            }
        }
    }
}
