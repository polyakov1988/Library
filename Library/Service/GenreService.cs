using System.Collections.Generic;
using Library.database;
using Library.Model;

namespace Library.Service
{
    public class GenreService : Service<GenreDatabase, Genre>
    {
        public GenreService()
        {
            Database = new GenreDatabase();
        }

        public override bool Add(Genre genre, out string message)
        {
            if (Database.HasElement(genre))
            {
                message = "Этот жанр уже есть в базе данных (нажмите Enter)\n";
                
                return false;
            }
            
            Database.Add(genre);
            
            message = "Жанр добавлен в базу данных (нажмите Enter)\n";

            return true;
        }

        public override Genre GetElementById(int id, out string message)
        {
            Genre genre = Database.GetElementById(id);

            if (genre == null)
            {
                message = $"Жанр с id = {id} не найден (нажмите Enter)\n";
            }
            else
            {
                message = $"Выбран жанр {genre.Name} (нажмите Enter)\n";
            }
            
            return genre;
        }
        
        public override List<string> GetAllElementsAsString()
        {
            List<string> genresAsString = new List<string>();
            
            for (int i = 0; i < Database.Count; i++)
            {
                Genre genre = Database.GetElementByIndex(i);

                string genreAsString = $"id: {genre.Id}; название: {genre.Name}";
                
                genresAsString.Add(genreAsString);
            }

            return genresAsString;
        }
    }
}