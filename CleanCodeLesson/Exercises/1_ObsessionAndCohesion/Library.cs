namespace CleanCodeLesson.Exercises.VO;

//Инкапсулируйте код

public sealed class Book
{
    public required string Identifier { get; set; }
    public required string Title { get; set; }
    public required string AuthorFirstName { get; set; }
    public required string AuthorLastName { get; set; }
    public int PublicationYear { get; set; }
    public int Edition { get; set; }

    public void UpdateEdition(int edition, int publicationYear)
    {
        if (Edition < 0) throw new ArgumentException("Edition is below zero");
        if (PublicationYear < 0) throw new ArgumentException("Invalid Publication Year");

        Edition = edition;
        PublicationYear = publicationYear;
    }
}

public class Library
{
    private readonly IList<Book> _books = new List<Book>();

    public IEnumerable<Book> Books => _books;

    public void AddBook(Book book)
    {
        if (string.IsNullOrWhiteSpace(book.Identifier) || book.Identifier.Length != 13 || !book.Identifier.All(char.IsDigit))
            throw new ArgumentException("Invalid Id");

        if (string.IsNullOrWhiteSpace(book.Title) || book.Title.Length > 100)
            throw new ArgumentException("Invalid Title");

        if (string.IsNullOrWhiteSpace(book.AuthorFirstName) || string.IsNullOrWhiteSpace(book.AuthorLastName))
            throw new ArgumentException("Invalid Author Name");

        if (book.Edition < 0)
            throw new ArgumentException("Edition is below zero");

        if (book.PublicationYear < 1450 || book.PublicationYear > DateTime.Now.Year)
            throw new ArgumentException("Invalid Publication Year");

        _books.Add(book);
    }
}