using System.Collections.Generic;
using Library.database;
using Library.Model;

namespace Library.Service
{
    public class BookService : Service<BookDatabase, Book>
    {
        public BookService()
        {
            Database = new BookDatabase();
        }

        public override bool Add(Book book, out string message)
        {
            if (Database.HasElement(book))
            {
                message = "Эта книга уже есть в базе данных (нажмите Enter)";
                
                return false;
            }
            
            Database.Add(book);
            
            message = "Книга добавлена в базу данных (нажмите Enter)";

            return true;
        }

        public override Book GetElementById(int id, out string message)
        {
            Book book = Database.GetElementById(id);

            if (book == null)
            {
                message = $"Книга с id = {id} не найдена (нажмите Enter)";
            }
            else
            {
                message = $"Выбрана книга {book.Name} (нажмите Enter)";
            }
            
            return book;
        }
        
        public override List<string> GetAllElementsAsString()
        {
            List<string> booksAsString = new List<string>();
            
            for (int i = 0; i < Database.Count; i++)
            {
                booksAsString.Add(GetBookAsString(Database.GetElementByIndex(i)));
            }

            return booksAsString;
        }

        public List<string> GetSelectedElementsAsString(List<Book> elements)
        {
            List<string> booksAsString = new List<string>();

            foreach (var element in elements)
            {
                booksAsString.Add(GetBookAsString(element));
            }

            return booksAsString;
        }
        
        public List<Book> GetByName(string name)
        {
            return Database.GetByName(name);
        }
        
        public List<Book> GetByAuthor(string lastName)
        {
            return Database.GetByAuthor(lastName);
        }
        
        public List<Book> GetByReleaseYear(int releaseYear)
        {
            return Database.GetByReleaseYear(releaseYear);
        }
        
        public List<Book> GetByGenre(string genre)
        {
            return Database.GetByGenre(genre);
        }

        private string GetBookAsString(Book book)
        {
            return $"id: {book.Id}; " +
                   $"название: {book.Name}; " +
                   $"автор: {book.Author.FullName}; " +
                   $"жанр: {book.Genre.Name}; " +
                   $"год: {book.ReleaseYear}";
        }
    }
}