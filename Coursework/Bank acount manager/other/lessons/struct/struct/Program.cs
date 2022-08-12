using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @struct
{
    class Program
    {
        struct Book
        {
           public string title;
            public string author;
            public int realeaseDate;
            public int pages;
            public bool read;
        }
        static string bookInspector(Book book)
        {
             return $"Author: {book.author} \nTitle: {book.title} \nRealease Date: {book.realeaseDate} \nPages: {book.pages} \nRead or not: {book.read} \n";
        }

        static void Main(string[] args)
        {
            Book book1 = new Book();
            Console.WriteLine("Enter the number of books: ");
            int n = int.Parse(Console.ReadLine());
            Book[] massBook = new Book[n];
            for (int i = 0; i < massBook.Length; i++)
            {
                Console.WriteLine("Enter Title: ");
                massBook[i].title = Console.ReadLine();
                Console.WriteLine("Enter Author: ");
                massBook[i].author = Console.ReadLine();
                Console.WriteLine("Enter Realease Date ");
                massBook[i].realeaseDate = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Pages ");
                massBook[i].pages = int.Parse(Console.ReadLine());
                Console.WriteLine("Have you read it? ");
                massBook[i].read = Console.ReadLine() == "y" ? true : false; //Console.ReadLine()=="y";
            }
            // Book book1 = new Book();
            // book1.title = "Harry Potter and philosophers stone";
            // book1.author = "J.K. Rowling";
            // book1.realeaseDate = 1997;
            // book1.pages = 280;
            // book1.read = false;
            //
            // Book book2 = new Book();
            // book2.title = "Chamber of secrets";
            // book2.author = "J.K. Rowling";
            // book2.realeaseDate = 1998;
            // book2.pages = 290;
            // book2.read = false;
            //
            for (int i = 0; i < massBook.Length; i++)
            {
                Console.WriteLine(bookInspector(massBook[i]));
            }
           // Console.WriteLine(bookInspector(book1));
            //Console.WriteLine(bookInspector(book2));
        }
    }
}
