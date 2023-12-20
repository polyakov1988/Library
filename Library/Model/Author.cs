namespace Library.Model
{
    public class Author : Model
    {
        public Author(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}