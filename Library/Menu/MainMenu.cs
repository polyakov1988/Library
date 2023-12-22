using System.Collections.Generic;

namespace Library.Menu
{
    public class MainMenu : Menu
    {
        public const string AddBookCommand = "1";
        public const string DeleteBookCommand = "2";
        public const string ShowAllBooksCommand = "3";
        public const string SearchBooksCommand = "4";
        public const string ExitCommand = "5";
        
        public MainMenu()
        {
            Elements = new Dictionary<string, string>()
            {
                { AddBookCommand, "Добавить книгу" },
                { DeleteBookCommand, "Удалить книгу" },
                { ShowAllBooksCommand, "Показать все книги" },
                { SearchBooksCommand, "Поиск книг" },
                { ExitCommand, "Выход" }
            };
        }
    }
}