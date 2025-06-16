namespace WpfViewToViewCommunication.EventAggregators;

public class PersonSavedEvent
{
    public string Name { get; }
    public int Age { get; }

    public PersonSavedEvent(string name, int age)
    {
        Name = name;
        Age = age;
    }
}