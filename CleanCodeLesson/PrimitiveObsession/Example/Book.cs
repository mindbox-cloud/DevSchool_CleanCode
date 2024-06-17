namespace CleanCodeLesson.PrimitiveObsession.Example;

public sealed class Book
{
    public Book(string name, DateTime publicationDate, IReadOnlyList<string> authors)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
        foreach (var author in authors) ArgumentException.ThrowIfNullOrWhiteSpace(author, nameof(author));
        
        
        Name = name;
        PublicationDate = publicationDate;
        Authors = authors;
    }

    public string Name { get; private set; }
    public DateTime PublicationDate { get; private set; }
    public IReadOnlyList<string> Authors { get; private set; }
}