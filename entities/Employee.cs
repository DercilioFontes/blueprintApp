using System.Xml.Serialization;
using static System.Console;


[XmlRoot(ElementName = "Employee")]
public class Employee
{

    [XmlAttribute(AttributeName = "Title")]
    public string Title { get; set; }

    [XmlText]
    public string Name { get; set; }

    public void PrintInfo()
    {
        WriteLine($"  Name: {Name}");
        WriteLine($"  Title: {Title}");
    }
}