namespace CleanCodeLesson.Exercises.VO;

public interface IBook {}

public record Identifier
{
    public string Value { get; set; }
    public Identifier(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length != 13 || !value.All(char.IsDigit))
            throw new ArgumentException("Invalid Id");

        Value = value;
    }
}

public record Title
{
    public string Value { get; set; }

    public Title(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length > 100)
            throw new ArgumentException("Invalid Title");

        Value = value;
    }
}

public record Author
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Author(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Invalid Author Name");

        FirstName = firstName;
        LastName = lastName;
    }
}

public record Edition
{
    public Edition(int editionValue, int publicationYear)
    {
        if (editionValue < 0)
            throw new ArgumentException("Edition is below zero");

        if (publicationYear < 1450 || publicationYear > DateTime.Now.Year)
            throw new ArgumentException("Invalid Publication Year");

        EditionValue = editionValue;
        PublicationYear = publicationYear;
    }

    public int EditionValue { get; set; }
    public int PublicationYear { get; set; }

    public void UpdateEdition(int edition, int publicationYear)
    {
        if (edition < 0) throw new ArgumentException("Edition is below zero");
        if (publicationYear < 0) throw new ArgumentException("Invalid Publication Year");

        EditionValue = edition;
        PublicationYear = publicationYear;
    }
}

public record PublicationRange
{
    public int MinPublicationYear { get; set; }
    public int MaxPublicationYear { get; set; }
    public PublicationRange(int minYear, int maxYear)
    {
        if (minYear < 0) throw new ArgumentException("Invalid min publication year");
        if (maxYear > 1450) throw new ArgumentException("Invalid max publication year");

        MinPublicationYear = minYear;
        MaxPublicationYear = maxYear;
    }
}

public sealed class OldBook : IBook
{
    public required Identifier Identifier { get; set; }
    public required Title Title { get; set; }
    public required Author Author { get; set; }
    public required PublicationRange PublicationRange { get; set; }
}

public sealed class Book : IBook
{
    public required Identifier Identifier { get; set; }
    public required Title Title { get; set; }
    public required Author Author { get; set; }
    public Edition? Edition { get; set; }
}


public class Library
{
    private readonly IList<IBook> _books = new List<IBook>();

    public IEnumerable<IBook> Books => _books;

    public void AddBook(IBook book)
    {
        _books.Add(book);
    }
}