using System;

namespace zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            library.addBook(new Book("Zbronia i Kara", "Fiodor Dostojewski", 1950, "Wydawnictwo Warszawskie", "123-123-242", "kryminał"), 1);
            library.addBook(new Book("Zbronia i Kara", "Fiodor Dostojewski", 1950, "Wydawnictwo Warszawskie", "123-123-242", "kryminał"), 2);
            library.addBook(new Book("Lalka", "Bolesław Prus", 1950, "Wydawnictwo Śląskie", "121-123-242", "obyczajowa"), 3);

            library.showBooks();
            library.showBorrowed();
            Client Ola = new Client("Aleksandra", "Gorska");
            Ola.borrowBook(1,library);
            library.showBorrowed();
            Ola.returnBook(1, library);
            library.showBorrowed();
        }
    }
}
