using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie3
{
    public class BookEntry
    {
        public int id;
        public Book book;
        public bool isAvailable = true;
        public BookEntry(Book book, int id)
        {
            this.book = book;
            this.id = id;
        }

    }
}
