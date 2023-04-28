using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie3
{
    public class Book
    {
        public string title;
        public string author;
        public int year;
        public string publisher;
        public string isbn;
        public string genre;

        public Book (string title, string author, int year, string publisher, string isbn, string genre)
        {
            this.title = title;
            this.author = author;
            this.year = year;
            this.publisher = publisher;
            this.isbn = isbn;
            this.genre = genre;
        }
    }
}
