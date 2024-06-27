namespace CleanCodeLesson.Exercises.VO;

//Инкапсулируйте код


public record Identifier
{
    public readonly string Value;
    public Identifier(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length != 13 || !value.All(char.IsDigit))
            throw new ArgumentException("Invalid Id");
        Value = value;
    }
}

public record Title
{
    public readonly string Value;
    public Title(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length > 100)
            throw new ArgumentException("Invalid Title");
        Value = value;
    }
}

public record Author
{
    public readonly string AuthorFirstName;
    public readonly string AuthorLastName;
    public Author(string authorFirstName, string authorLastName)
    {
        if (string.IsNullOrWhiteSpace(authorFirstName) || string.IsNullOrWhiteSpace(authorLastName))
            throw new ArgumentException("Invalid Author Name");

        AuthorFirstName = authorFirstName;
        AuthorLastName = authorLastName;
    }
}

public record Edition
{
    public int Number { get; private set; }
    public int PublicationYear  { get; private set; }

    public Edition(int number, int publicationYear)
    {
        UpdateEdition(number, publicationYear);
    }

    public void UpdateEdition(int number, int publicationYear)
    {
        if (Number < 0)
            throw new ArgumentException("Edition is below zero");

        if (PublicationYear < 1450 || PublicationYear > DateTime.Now.Year && PublicationYear < 0)
            throw new ArgumentException("Invalid Publication Year");
        
        Number = number;
        PublicationYear = publicationYear;
    }
}

public sealed class Book
{
    public required Identifier Identifier { get; set; }
    public required Title Title { get; set; }
    public required Author Author { get; set; }
    public required Edition Edition { get; set; }
}

public class Library
{
    private readonly IList<Book> _books = new List<Book>();

    public IEnumerable<Book> Books => _books;

    public void AddBook(Book book)
    {
        _books.Add(book);
    }
}