using Library.Model;

namespace Library.database
{
    public class GenreDatabase : Database<Genre>
    {
        public override bool HasElement(Genre genre)
        {
            foreach (var element in Repo)
            {
                string elementName = element.Name.ToLower();

                if (elementName == genre.Name)
                    return true;
            }
            
            return false;
        }
    }
}