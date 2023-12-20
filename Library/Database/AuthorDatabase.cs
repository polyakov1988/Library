using Library.Model;

namespace Library.database
{
    public class AuthorDatabase : Database<Author>
    {
        public override bool HasElement(Author author)
        {
            foreach (var element in Repo)
            {
                string elementFullName = element.FullName.ToLower();
                string newAuthorFullName = author.FullName.ToLower();

                if (elementFullName == newAuthorFullName)
                    return true;
            }
            
            return false;
        }
    }
}