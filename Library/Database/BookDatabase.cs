using System.Collections.Generic;
using Library.Model;

namespace Library.database
{
    public class BookDatabase : Database<Book>
    {
        public override bool HasElement(Book book)
        {
            foreach (var element in Elements)
            {
                string elementName = element.Name.ToLower();
                Author elementAuthor = element.Author;

                if (elementName == book.Name.ToLower() && elementAuthor.FullName == book.Author.FullName)
                    return true;
            }
            
            return false;
        }

        public List<Book> GetBooksByName(string name)
        {
            List<Book> foundedBooks = new List<Book>();

            foreach (var element in Elements)
            {
                if (element.Name.ToLower() == name.ToLower())
                    foundedBooks.Add(element);
            }

            return foundedBooks;
        }
        
        public List<Book> GetBooksByAuthor(string lastName)
        {
            List<Book> foundedBooks = new List<Book>();

            foreach (var element in Elements)
            {
                if (element.Author.LastName.ToLower() == lastName.ToLower())
                    foundedBooks.Add(element);
            }

            return foundedBooks;
        }
        
        public List<Book> GetBooksByReleaseYear(int releaseYear)
        {
            List<Book> foundedBooks = new List<Book>();

            foreach (var element in Elements)
            {
                if (element.ReleaseYear == releaseYear)
                    foundedBooks.Add(element);
            }

            return foundedBooks;
        }
        
        public List<Book> GetBooksByGenre(string genre)
        {
            List<Book> foundedBooks = new List<Book>();

            foreach (var element in Elements)
            {
                if (element.Genre.Name == genre)
                    foundedBooks.Add(element);
            }

            return foundedBooks;
        }

        public bool Delete(int id)
        {
            Book book = GetElementById(id);

            if (book == null)
            {
                return false;
            }

            Elements.Remove(book);

            return true;
        }
    }
}