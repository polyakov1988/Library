using System.Collections.Generic;
using Library.Model;

namespace Library.database
{
    public class BookDatabase : Database<Book>
    {
        public override bool HasElement(Book book)
        {
            foreach (var element in Repo)
            {
                string elementName = element.Name.ToLower();
                Author elementAuthor = element.Author;

                if (elementName == element.Name.ToLower() && elementAuthor.FullName == book.Author.FullName)
                    return true;
            }
            
            return false;
        }

        public List<Book> GetByName(string name)
        {
            List<Book> foundedBooks = new List<Book>();

            foreach (var element in Repo)
            {
                if (element.Name.ToLower() == name.ToLower())
                    foundedBooks.Add(element);
            }

            return foundedBooks;
        }
        
        public List<Book> GetByAuthor(string lastName)
        {
            List<Book> foundedBooks = new List<Book>();

            foreach (var element in Repo)
            {
                if (element.Author.LastName.ToLower() == lastName.ToLower())
                    foundedBooks.Add(element);
            }

            return foundedBooks;
        }
        
        public List<Book> GetByReleaseYear(int releaseYear)
        {
            List<Book> foundedBooks = new List<Book>();

            foreach (var element in Repo)
            {
                if (element.ReleaseYear == releaseYear)
                    foundedBooks.Add(element);
            }

            return foundedBooks;
        }
        
        public List<Book> GetByGenre(string genre)
        {
            List<Book> foundedBooks = new List<Book>();

            foreach (var element in Repo)
            {
                if (element.Genre.Name == genre)
                    foundedBooks.Add(element);
            }

            return foundedBooks;
        }
    }
}