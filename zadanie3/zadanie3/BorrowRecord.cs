using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie3
{
    public class BorrowRecord
    {
        public int id;
        public Client client;
        public int bookId;
        public DateTime borrowedFrom;
        public DateTime borrowedTo;
        public bool isReturned;

        public BorrowRecord(int id, Client client, int bookId, DateTime borrowedFrom, DateTime borrowedTo)
        {
            this.id = id;
            this.client = client;
            this.bookId = bookId;
            this.borrowedFrom = borrowedFrom;
            this.borrowedTo = borrowedTo;
            this.isReturned = false;
        }
    }
}
// dodać id do borrowrecord 
// cala reszta