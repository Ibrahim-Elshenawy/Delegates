using System;
using System.Collections.Generic;
using System.Text;

namespace Delegates
{
    public delegate string GetData(Book book);
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }
        public Book(string _ISBN, string _Title,
        string[] _Authors, DateTime _PublicationDate,
       decimal _Price)
        {

            ISBN = _ISBN;
            Title = _Title;
            Authors = _Authors;
            PublicationDate = _PublicationDate;
            Price = _Price;
        }
        public override string ToString()
        {
            StringBuilder authors = new();
            foreach (var author in Authors) {
                authors.Append(author).Append(", ");
            }
          var auth =  authors.ToString().TrimEnd(',');
            return $"{ISBN}:::{Title}:::{auth}:::{PublicationDate}:::{Price}";
        }
    }
    public class BookFunctions
    {
        public static string GetTitle(Book B)
        {
            return B.Title;
        }
        public static string GetAuthors(Book B)
        {
            StringBuilder authors = new();
            foreach (var author in B.Authors)
            {
                authors.Append(author).Append(",");
            }
            var results = authors.ToString().TrimEnd(',');
            return results;
        }
        public static string GetPrice(Book B)
        {
            return B.Price.ToString();
        }
    }
    public class LibraryEngine
    {

        public static void ProcessBooks(List<Book> bList
      , GetData fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }
        public static void ProcessBooks(List<Book> bList
       , Func<Book, string> fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }
    }

    class Program
    {
    

        static void Main(string[] args)
        {
            List<Book> books = new List<Book>() {
                new Book (  "_ISBN1",  "Title1",
        new string[] {"_Authors1","_Authors2" }, DateTime.Now ,
        123 ),
                new Book (  "_ISBN2",  "Title2",
        new string[] {"_Authors3","_Authors4" }, DateTime.Now ,
        456 ),
                new Book (  "_ISBN3",  "Title3",
        new string[] {"_Authors5","_Authors6" }, DateTime.Now ,
        789 ),
                new Book (  "_ISBN4",  "Title4",
        new string[] {"_Author7","_Authors8" }, DateTime.Now ,
        532 ) };


            GetData getData = BookFunctions.GetPrice;

            Func<Book, string> func = BookFunctions.GetPrice;

            Func<Book, string> getISBNDelegate = delegate(Book book) {
                return book.ISBN;
            };

            Func<Book, string> getPublicationDateExpression = b => b.PublicationDate.ToString();

            //LibraryEngine.ProcessBooks(books, getData);
            //LibraryEngine.ProcessBooks(books, func);

            //LibraryEngine.ProcessBooks(books, getISBNDelegate);
            LibraryEngine.ProcessBooks(books, getPublicationDateExpression);





        }
    }
}
