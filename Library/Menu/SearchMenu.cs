using System.Collections.Generic;

namespace Library.Menu
{
    public class SearchMenu : Menu
    {
        public const string SearchByNameCommand = "1";
        public const string SearchByAuthorCommand = "2";
        public const string SearchByYearCommand = "3";
        public const string SearchByGenreCommand = "4";

        public SearchMenu()
        {
            Elements = new Dictionary<string, string>
            {
                { SearchByNameCommand, "Поиск по названию книги" },
                { SearchByAuthorCommand, "Поиск по фамилии автора" },
                { SearchByYearCommand, "Поиск по году выхода книги" },
                { SearchByGenreCommand, "Поиск по жанру" }
            };
        }
    }
}