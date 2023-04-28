using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie3
{
    public class Client
    {
        public string firstName;
        public string lastName;
        private List<BorrowRecord> booksBorrowed = new List<BorrowRecord>();

        public Client (string firstName, string lastName)
        {
            this.firstName = firstName; 
            this.lastName = lastName;
        }

        public void borrowBook(int bookId, Library library)
        {
            BorrowRecord book = library.borrowBook(bookId, this);
            if (book == null)
            {
                Console.WriteLine("Nie udało się wypożyczyć książki");
                return;
            }
            else
            {
                booksBorrowed.Add(book);
            }
        }

        public void returnBook(int bookId, Library library)
        {
            if (!booksBorrowed.Exists(e => e.bookId == bookId))
            {
                Console.WriteLine("Nie wypożyczałeś/aś takiej książki!");
                return;
            }

            int id = booksBorrowed.Find(e => e.bookId == bookId).id;

            library.returnBook(id);

            int index = booksBorrowed.FindIndex(e => e.bookId == bookId);
            booksBorrowed.RemoveAt(index);
        }

    }
}
