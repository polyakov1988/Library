using System;
using System.Collections.Generic;
using Library.Menu;
using Library.Model;
using Library.Service;

namespace Library
{
    public class LibraryManager
    {
        private const string AddNewCommand = "0";
        
        private readonly AuthorService _authorService = new AuthorService();
        private readonly GenreService _genreService = new GenreService();
        private readonly BookService _bookService = new BookService();
        private readonly Renderer _renderer = new Renderer();
        
        private string _userInput;
        private string _message;

        public LibraryManager()
        {
            FillDb();
        }

        public void Start()
        {
            do
            {
                _renderer.DrawMenu(new MainMenu());
                
                _userInput = _renderer.WaitUserInput("\nВведите команду: ");
                
                switch (_userInput)
                {
                    case MainMenu.AddBookCommand:
                        AddBook();
                        break;
                    
                    case MainMenu.DeleteBookCommand:
                        DeleteBook();
                        break;
                    
                    case MainMenu.ShowAllBooksCommand:
                        ShowAllBooks();
                        break;
                    
                    case MainMenu.SearchBooksCommand:
                        SearchBooks();
                        break;
                }
            } while (_userInput != MainMenu.ExitCommand);
        }

        private void FillDb()
        {
            Author harryHarrison = new Author(_authorService.GetNextId(), "Гарри", "Гаррисон");
            _authorService.Add(harryHarrison, out _message);
            
            Author agathaChristie = new Author(_authorService.GetNextId(), "Агата", "Кристи");
            _authorService.Add(agathaChristie, out _message);
            
            Author stevenKing = new Author(_authorService.GetNextId(), "Стивен", "Кинг");
            _authorService.Add(stevenKing, out _message);
            
            Author nikolayGogol = new Author(_authorService.GetNextId(), "Николай", "Гоголь");
            _authorService.Add(nikolayGogol, out _message);

            Genre fantastic = new Genre(_genreService.GetNextId(), "фантастика");
            _genreService.Add(fantastic, out _message);
            
            Genre detective = new Genre(_genreService.GetNextId(), "детектив");
            _genreService.Add(detective, out _message);
            
            Genre horror = new Genre(_genreService.GetNextId(), "ужасы");
            _genreService.Add(horror, out _message);
            
            Genre comedy = new Genre(_genreService.GetNextId(), "комедия");
            _genreService.Add(comedy, out _message);
            
            _bookService.Add(new Book(_bookService.GetNextId(), "Неукротимая планета", harryHarrison, 1860, fantastic), out _message);
            _bookService.Add(new Book(_bookService.GetNextId(), "Десять негритят", agathaChristie, 1939, detective), out _message);
            _bookService.Add(new Book(_bookService.GetNextId(), "Оно", stevenKing, 1986, horror), out _message);
            _bookService.Add(new Book(_bookService.GetNextId(), "Ревизор", nikolayGogol, 1836, comedy), out _message);
        }

        private void AddBook()
        {
            _renderer.Clear();

            Author author = GetAuthor();
            
            if (author == null)
                return;

            Genre genre = GetGenre();
            
            if (genre == null)
                return;

            string name = GetBookName();

            int releaseYear = GetReleaseYear();

            Book book = new Book(_bookService.GetNextId(), name, author, releaseYear, genre);
            
            _bookService.Add(book, out _message);
            
            _renderer.DrawMessage(_message);
        }

        private Author GetAuthor()
        {
            List<string> authors = _authorService.GetAllElementsAsString();
            
            _renderer.DrawList(authors);
            
            _userInput = _renderer.WaitUserInput($"Введите Id автора или {AddNewCommand} чтобы добавить нового: ");

            Author selectedAuthor;
            
            if (_userInput == AddNewCommand)
            {
                selectedAuthor = GetAuthorByAddingNew();
            }
            else
            {
                selectedAuthor = SelectAuthorById();
            }

            return selectedAuthor;
        }
        
        private Genre GetGenre()
        {
            List<string> genres = _genreService.GetAllElementsAsString();
            
            _renderer.DrawList(genres);
            
            _userInput = _renderer.WaitUserInput($"Введите Id жанра или {AddNewCommand} чтобы добавить новый: ");

            Genre selectedGenre;
            
            if (_userInput == AddNewCommand)
            {
                selectedGenre = GetGenreByAddingNew();
            }
            else
            {
                selectedGenre = SelectGenreById();
            }

            return selectedGenre;
        }

        private Author GetAuthorByAddingNew()
        {
            _userInput = _renderer.WaitUserInput("Введите имя: ");
            string firstName = _userInput;

            if (string.IsNullOrWhiteSpace(firstName))
            {
                _renderer.DrawMessage("Имя не может быть пустым");

                return null;
            }
                
            _userInput = _renderer.WaitUserInput("Введите фамилию: ");
            string lastName = _userInput;
            
            if (string.IsNullOrWhiteSpace(lastName))
            {
                _renderer.DrawMessage("Фамилия не может быть пустой");

                return null;
            }

            Author author = new Author(_authorService.GetNextId(), firstName, lastName);

            bool isAddingNewAuthorSuccess = _authorService.Add(author, out _message);
            
            _renderer.DrawMessage(_message);

            return isAddingNewAuthorSuccess ? author : null;
        }
        
        private Genre GetGenreByAddingNew()
        {
            _userInput = _renderer.WaitUserInput("Введите название: ");
            string name = _userInput;

            if (string.IsNullOrWhiteSpace(name))
            {
                _renderer.DrawMessage("Название не может быть пустым");

                return null;
            }
            
            Genre genre = new Genre(_authorService.GetNextId(), name);

            bool isAddingNewGenreSuccess = _genreService.Add(genre, out _message);
            
            _renderer.DrawMessage(_message);

            return isAddingNewGenreSuccess ? genre : null;
        }

        private Author SelectAuthorById()
        {
            bool isIdCorrect;
            int id;

            do
            {
                isIdCorrect = int.TryParse(_userInput, out id);

                if (isIdCorrect == false || id < 0)
                {
                    _userInput = _renderer.WaitUserInput("Введите корректный id: ");
                }
            } while (isIdCorrect == false);

            Author author = _authorService.GetElementById(id, out _message);
            
            _renderer.DrawMessage(_message);

            return author;
        }
        
        private Genre SelectGenreById()
        {
            bool isIdCorrect;
            int id;

            do
            {
                isIdCorrect = int.TryParse(_userInput, out id);

                if (isIdCorrect == false || id < 0)
                {
                    _userInput = _renderer.WaitUserInput("Введите корректный id: ");
                }
            } while (isIdCorrect == false);

            Genre genre = _genreService.GetElementById(id, out _message);
            
            _renderer.DrawMessage(_message);

            return genre;
        }

        private string GetBookName()
        {
            _userInput = _renderer.WaitUserInput("Введите название книги: ");
            string name = _userInput;

            if (string.IsNullOrWhiteSpace(name))
            {
                _renderer.DrawMessage("Название не может быть пустым");

                return null;
            }

            return name;
        }
        
        private int GetReleaseYear()
        {
            _userInput = _renderer.WaitUserInput("Введите год выхода книги: ");

            bool isIdCorrect;
            int year;

            do
            {
                isIdCorrect = int.TryParse(_userInput, out year);

                if (isIdCorrect == false || year < 0 || year > DateTime.Now.Year)
                {
                    _userInput = _renderer.WaitUserInput("Введите корректный год: ");
                }
            } while (isIdCorrect == false);

            return year;
        }
        
        private void DeleteBook()
        {
            _userInput = _renderer.WaitUserInput("Выберите автора или введите 0 чтобы добавить нового: ");
        }
        
        private void ShowAllBooks()
        {
            List<string> books = _bookService.GetAllElementsAsString();
            _renderer.DrawList(books);
            _renderer.DrawMessage("Для продолжения нажмите Enter");
        }
        
        private void SearchBooks()
        {
            _renderer.DrawMenu(new SearchMenu());
            
            _userInput = _renderer.WaitUserInput("\nВведите команду: ");
            
            switch (_userInput)
            {
                case SearchMenu.SearchByNameCommand:
                    SearchByName();
                    break;
                    
                case SearchMenu.SearchByAuthorCommand:
                    SearchByAuthor();
                    break;
                    
                case SearchMenu.SearchByYearCommand:
                    SearchByYear();
                    break;
                    
                case SearchMenu.SearchByGenreCommand:
                    SearchByGenre();
                    break;
            }
        }

        private void SearchByName()
        {
            _userInput = _renderer.WaitUserInput("\nВведите название книги: ");

            if (string.IsNullOrWhiteSpace(_userInput))
            {
                _renderer.DrawMessage("Название книги не может быть пустым");
                
                return;
            }

            List<Book> foundedBooks = _bookService.GetBooksByName(_userInput);

            ShowSearchResult(foundedBooks);
        }
        
        private void SearchByAuthor()
        {
            _userInput = _renderer.WaitUserInput("\nВведите фамилию автора: ");

            if (string.IsNullOrWhiteSpace(_userInput))
            {
                _renderer.DrawMessage("Фамилия не может быть пустой");
                
                return;
            }

            List<Book> foundedBooks = _bookService.GetBooksByAuthor(_userInput);

            ShowSearchResult(foundedBooks);
        }
        
        private void SearchByYear()
        {
            _userInput = _renderer.WaitUserInput("\nВведите год выхода книги: ");

            bool isIdCorrect;
            int year;

            do
            {
                isIdCorrect = int.TryParse(_userInput, out year);

                if (isIdCorrect == false || year < 0 || year > DateTime.Now.Year)
                {
                    _userInput = _renderer.WaitUserInput("Введите корректный год: ");
                }
            } while (isIdCorrect == false);
            
            List<Book> foundedBooks = _bookService.GetBooksByReleaseYear(year);
            
            ShowSearchResult(foundedBooks);
        }
        
        private void SearchByGenre()
        {
            _userInput = _renderer.WaitUserInput("\nВведите название жанра: ");

            if (string.IsNullOrWhiteSpace(_userInput))
            {
                _renderer.DrawMessage("Название не может быть пустым");
                
                return;
            }

            List<Book> foundedBooks = _bookService.GetBooksByGenre(_userInput);

            ShowSearchResult(foundedBooks);
        }

        private void ShowSearchResult(List<Book> foundedElements)
        {
            if (foundedElements.Count == 0)
            {
                _renderer.DrawMessage("Нет результатов по вашему запросу (нажмите enter)");
                
                return;
            }
            
            _renderer.DrawList(_bookService.GetSelectedElementsAsString(foundedElements));
            _renderer.DrawMessage("Для продолжения нажмите Enter");
        }
    }
}