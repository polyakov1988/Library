namespace Library.Model
{
    public class Genre : Model
    {
        public Genre(int id, string name)
        {
            Id = id;
            Name = name;
        }
        
        public string Name { get; private set; }
    }
}