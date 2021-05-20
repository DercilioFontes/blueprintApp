using System.Xml.Serialization;
using System.Collections.Generic;
using static System.Console;

[XmlRoot(ElementName = "Unit")]
public class Unit
{

    [XmlElement(ElementName = "Employee")]
    public List<Employee> Employees { get; set; }

    [XmlAttribute(AttributeName = "Name")]
    public string Name { get; set; }

    [XmlText]
    public string Text { get; set; }

    [XmlElement(ElementName = "Units")]
    public Units Units { get; set; }

    public void PrintUnitInfo()
    {
        foreach (Employee employee in Employees)
        {
            employee.PrintInfo();
            WriteLine($"  Unit: {Name}");
            WriteLine();
        }

        if (Units != null)
        {
            Units.PrintUnitsInfo();
        }
    }
}

[XmlRoot(ElementName = "Units")]
public class Units
{
    [XmlElement(ElementName = "Unit")]
    public List<Unit> Unit { get; set; }

    public void PrintUnitsInfo()
    {
        foreach (Unit unit in Unit)
        {
            unit.PrintUnitInfo();
        }
    }

    public Unit GetUnitByName(string name)
    {
        Unit result = Unit.Find(u => u.Name.Equals(name));

        if (result == null)
        {
            foreach (Unit unit in Unit)
            {
                result = unit.Units?.GetUnitByName(name);
                if (result != null)
                {
                    return result;
                }
            }
        }

        return result;
    }
}