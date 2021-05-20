using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using static System.Console;

[XmlRoot(ElementName = "Organization")]
public class Organization
{

    [XmlElement(ElementName = "Employee")]
    public List<Employee> Employees { get; set; }

    [XmlElement(ElementName = "Units")]
    public Units Units { get; set; }

    [XmlAttribute(AttributeName = "Name")]
    public string Name { get; set; }

    [XmlText]
    public string Text { get; set; }

    public void PrintEmployeesReport()
    {
        WriteLine();
        WriteLine($"Organization: {Name}");
        WriteLine();

        WriteLine($"C-Level Employees:");
        foreach (Employee employee in Employees)
        {
            employee.PrintInfo();
            WriteLine();
        }

        WriteLine($"Employees:");
        Units.PrintUnitsInfo();
        WriteLine();
    }

    public void ShitchTeams(string unitName1, string unitName2)
    {
        var unit1 = Units.GetUnitByName(unitName1);
        if (unit1 == null)
        {
            throw new ArgumentException($"Unit {unitName1} does not exits!");
        }

        var unit2 = Units.GetUnitByName(unitName2);
        if (unit2 == null)
        {
            throw new ArgumentException($"Unit {unitName2} does not exits!");
        }

        var tempEmployees = unit1.Employees;
        unit1.Employees = unit2.Employees;
        unit2.Employees = tempEmployees;
    }
}