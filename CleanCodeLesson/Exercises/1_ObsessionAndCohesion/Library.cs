namespace CleanCodeLesson.Exercises.VO;

//Инкапсулируйте код

public record Edition()
{
    public int Value { get; init; }
    public int PublicationYear { get; init; }

    public Edition(int value, int publicationYear) : this()
    {
        if (value < 0) throw new ArgumentException("Edition is below zero");
        Value = value;
        
        if (publicationYear < 1450 || publicationYear > DateTime.Now.Year)
            throw new ArgumentException("Invalid Publication Year");
        
        PublicationYear = publicationYear;
    }
}

public record Author
{
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public Author(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Invalid Author Name");

        FirstName = firstName;
        LastName = lastName;
    }
}

public record Identifier
{
    public string Value { get; init; }

    public Identifier(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length != 13 || !value.All(char.IsDigit))
            throw new ArgumentException("Invalid Id");

        Value = value;
    }
}

public record Title
{
    public string Value { get; init;}

    public Title(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length > 100)
            throw new ArgumentException("Invalid Title");

        Value = value;
    }
}

public sealed class Book
{
    public required Identifier Identifier { get; set; }
    public required Title Title { get; set; }
    public required Author Author { get; set; }
    public Edition Edition { get; set; }

    public void UpdateEdition(int edition, int publicationYear)
    {
        Edition = new Edition(edition, publicationYear);
    }
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