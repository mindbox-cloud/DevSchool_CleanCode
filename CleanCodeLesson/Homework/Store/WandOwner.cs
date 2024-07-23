namespace CleanCodeLesson.Homework;

public record WandOwner
{
    public WandOwner(string name, int age)
    {
        if(string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name should not be empty or null");
        }
        if(age < 0)
        {
            throw new ArgumentException("Age should be greater than 0");
        }
        Age = age;
        Name = name;
    }
    public string Name { get; }
    
    public int Age { get; }
}