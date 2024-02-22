namespace ExceptionArticle.Models;

public class YourEntity
{
    public int Id { get; }
    
    public string Name { get; }
    
    public int SomeValue { get; }

    public YourEntity(string name, int someValue)
    : this(0, name, someValue)
    {
        
    }

    public YourEntity(int id, string name, int someValue)
    {
        Id = id;
        Name = name;
        SomeValue = someValue;
    }
}