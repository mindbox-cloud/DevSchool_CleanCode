namespace CleanCodeLesson.Exercises.VO;

//Инкапсулируйте код

public sealed class OldBook()
{
    public BookIdentifier Identifier { get; set; }
    public Author Author { get; set; }
    public OldBookInfo Info { get; set; }
}

public sealed class Book
{
    public BookIdentifier Identifier { get; set; }
    public Author Author { get; set; }
    public BookInfo Info { get; set; }
}

public record BookIdentifier
{
    public BookIdentifier(string identifier, string title)
    {
        if (string.IsNullOrWhiteSpace(identifier) || identifier.Length != 13 ||
            !identifier.All(char.IsDigit))
            throw new ArgumentException("Invalid Id");

        if (string.IsNullOrWhiteSpace(title) || title.Length > 100)
            throw new ArgumentException("Invalid Title");
    }

    public required string Identifier { get; set; }
    public required string Title { get; set; }
}

public record Author
{
    public Author(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Invalid Author Name");
    }
}

public record OldBookInfo
{
    public OldBookInfo(int StartYear, int EndYear)
    {
        this.StartYear = StartYear;
        this.EndYear = EndYear;
    }

    public int StartYear { get; init; }
    public int EndYear { get; init; }
}

public record BookInfo
{
    public BookInfo(int publicationYear, int edition)
    {
        if (edition < 0)
            throw new ArgumentException("Edition is below zero");

        if (publicationYear < 1450 || publicationYear > DateTime.Now.Year)
            throw new ArgumentException("Invalid Publication Year");
    }

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
        _books.Add(book);
    }
}