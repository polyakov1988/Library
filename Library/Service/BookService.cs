using System.Collections.Generic;
using Library.database;
using Library.Model;

namespace Library.Service
{
    public class BookService : Service<BookDatabase, Book>
    {
        public BookService(BookDatabase database) : base(database) {}

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
        
        public bool Delete(int id, out string message)
        {
            if (Database.Delete(id))
            {
                message = $"Книга с id = {id} удалена (нажмите Enter)";
                
                return true;
            }
            
            message = $"Книга с id = {id} не найдена (нажмите Enter)";

            return false;
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
        
        public List<Book> GetBooksByName(string name)
        {
            return Database.GetBooksByName(name);
        }
        
        public List<Book> GetBooksByAuthor(string lastName)
        {
            return Database.GetBooksByAuthor(lastName);
        }
        
        public List<Book> GetBooksByReleaseYear(int releaseYear)
        {
            return Database.GetBooksByReleaseYear(releaseYear);
        }
        
        public List<Book> GetBooksByGenre(string genre)
        {
            return Database.GetBooksByGenre(genre);
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