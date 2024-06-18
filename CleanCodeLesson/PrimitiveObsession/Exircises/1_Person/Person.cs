namespace CleanCodeLesson.PrimitiveObsession.Exircises._1_Person;

public class Person
{
    public string FirstName { get; set; }
    
    public string? Email { get; set; }
}

public class Email
{
    public string From { get; set; }
    public string To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}

public class InvitationService
{
    public void SendInvitationToCustomer(Person person, Email email)
    {
        if (person.Email == null) throw new ArgumentNullException(person.Email);
        
        if (string.IsNullOrEmpty(email.Subject)) throw new ArgumentException(person.Email);
        if (string.IsNullOrEmpty(email.Subject)) throw new ArgumentException(person.Email);
        if (string.IsNullOrEmpty(email.Subject)) throw new ArgumentException(person.Email);
        if (string.IsNullOrEmpty(email.Subject)) throw new ArgumentException(person.Email);
    }
}