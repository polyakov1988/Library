using System.Collections.Generic;
using Library.database;
using Library.Model;

namespace Library.Service
{
    public class AuthorService : Service<AuthorDatabase, Author>
    {
        public AuthorService()
        {
            Database = new AuthorDatabase();
        }

        public override bool Add(Author author, out string message)
        {
            if (Database.HasElement(author))
            {
                message = "Этот автор уже есть в базе данных (нажмите Enter)\n";
                
                return false;
            }
            
            Database.Add(author);
            
            message = "Автор добавлен в базу данных (нажмите Enter)\n";

            return true;
        }

        public override Author GetElementById(int id, out string message)
        {
            Author author = Database.GetElementById(id);

            if (author == null)
            {
                message = $"Автор с id = {id} не найден (нажмите Enter)\n";
            }
            else
            {
                message = $"Выбран автор {author.FullName} (нажмите Enter)\n";
            }
            
            return author;
        }

        public override List<string> GetAllElementsAsString()
        {
            List<string> authorsAsString = new List<string>();
            
            for (int i = 0; i < Database.Count; i++)
            {
                Author author = Database.GetElementByIndex(i);

                string authorAsString = $"id: {author.Id}; имя: {author.FullName}";
                
                authorsAsString.Add(authorAsString);
            }

            return authorsAsString;
        }
    }
}