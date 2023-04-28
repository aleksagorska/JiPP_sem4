using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie3
{
    public class Library
    {
        private List<BookEntry> books = new List<BookEntry>();
        private List<BorrowRecord> borrowRecords = new List<BorrowRecord>();

        public void addBook(Book book, int id)
        {
            if (books.Exists(e => e.id == id))
            {
                Console.WriteLine("Książka o takim ID (" + id + ") już istnieje w systemie!");
                return;
            }
            books.Add(new BookEntry(book, id));
        }

        public void removeBook(int id)
        {
            int index = books.FindIndex(e => e.id == id);
            if (index == -1)
            {
                Console.WriteLine("Książka o takim ID (" + id + ") nie istnieje w systemie!");
                return;
            } 
            books.RemoveAt(index);
        }

        public BorrowRecord borrowBook(int bookId, Client client)
        {
            if (!books.Exists(e => e.id == bookId))
            {
                Console.WriteLine("Książka o takim ID (" + bookId + ") nie istnieje w systemie!");
                return null;
            }
            BookEntry bookEntry = books.Find(e => e.id == bookId);

            if (!bookEntry.isAvailable)
            {
                Console.WriteLine("Ta książka jest obecnie wypożyczona!");
                return null;
            }
            borrowRecords.Add(new BorrowRecord (borrowRecords.Count, client, bookId, DateTime.Now, DateTime.Now.AddMonths(1)));
            bookEntry.isAvailable = false;
            return borrowRecords.Last();
        }

        public void returnBook(int recordId)
        {
            BorrowRecord borrowRecord = borrowRecords.Find(e => e.id == recordId);
            borrowRecord.isReturned = true;
            int bookId = borrowRecord.bookId;
            books.Find(e => e.id == bookId).isAvailable = true;
        }
        public void showBooks()
        {
            Console.WriteLine("Lista książek: ");
            foreach (var book in books)
            {
                Console.WriteLine("ID: " + book.id + ", " + 
                    "Dostępna: " + (book.isAvailable ? "tak" : "nie") + ", " +
                    book.book.author + ", " +
                    book.book.title + ", " +
                    book.book.genre);
            }
        }

        public void showBooks(List<BookEntry> filteredBooks)
        {
            Console.WriteLine("Lista książek: ");
            foreach (var book in filteredBooks)
            {
                Console.WriteLine("ID: " + book.id + ", " +
                    "Dostępna: " + (book.isAvailable ? "tak" : "nie") + ", " +
                    book.book.author + ", " +
                    book.book.title + ", " +
                    book.book.genre);
            }
        }

        public void searchByTitle(string title)
        {
            List<BookEntry> filteredBooks = books.FindAll(e => e.book.title.ToLower().Contains(title));
            showBooks(filteredBooks);
           
        }

        public void searchByAuthor(string author)
        {
            List<BookEntry> filteredBooks = books.FindAll(e => e.book.author.ToLower().Contains(author));
            showBooks(filteredBooks);
        }

        public void searchByGenre(string genre)
        {
            List<BookEntry> filteredBooks = books.FindAll(e => e.book.genre.ToLower().Contains(genre));
            showBooks(filteredBooks);
        }

        public void showBorrowed()
        {
            bool atLeastOne = false;
            Console.WriteLine("Lista wypożyczonych książek: ");
            foreach (var entry in borrowRecords)
            {
                if (entry.isReturned == false)
                {
                    atLeastOne = true;
                    BookEntry bookEntry = books.Find(e => e.id == entry.bookId);
                    
                    Console.WriteLine("ID: " + bookEntry.id + ", " +
                       bookEntry.book.author + ", " +
                       bookEntry.book.title + ", " +
                       bookEntry.book.genre + ", wypożyczona przez: " +
                       entry.client.firstName + " " + entry.client.lastName);
                }

            }

            if (!atLeastOne)
            {
                Console.WriteLine("Lista jest pusta");
            }
        }

    }
}
