namespace Library.Model
{
    public class Book : Model
    {
        public Book(int id, string name, Author author, int releaseYear, Genre genre)
        {
            Id = id;
            Name = name;
            Author = author;
            ReleaseYear = releaseYear;
            Genre = genre;
        }

        public string Name { get; private set; }
        public Author Author { get; private set; }
        public int ReleaseYear { get; private set; }
        public Genre Genre { get; private set; }
    }
}