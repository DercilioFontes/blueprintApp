using static System.Console;
using static System.IO.Path;
using static System.Environment;
using bpApp.Helpers;

namespace bpApp
{
    class Program
    {
        static void Main()
        {
            // Task 1
            WriteLine("BluePrint Software Systems");
            WriteLine();
            WriteLine("Please, enter the organization.xml file absolute path.");
            WriteLine("Or just 'Enter' for using the current location.");
            Write("Path: ");
            string xmlPath = ReadLine();

            if (string.IsNullOrEmpty(xmlPath))
            {
                xmlPath = $"{CurrentDirectory}{DirectorySeparatorChar}organization.xml";
            }

            var organization = OrganizationHelper.FromXml(xmlPath);
            organization.PrintEmployeesReport();

            // Task 2
            WriteLine("Please, enter the absolute path for the json file with switched teams.");
            WriteLine("Or just 'Enter' for using the current location.");
            Write("Path: ");
            string jsonPath = ReadLine();

            if (string.IsNullOrEmpty(jsonPath))
            {
                jsonPath = $"{CurrentDirectory}{DirectorySeparatorChar}organization.json";
            }

            organization.ShitchTeams("Platform Team", "Maintenance Team");
            OrganizationHelper.ToJson(organization, jsonPath);

            WriteLine($"Json file was written successfully to the path: {jsonPath}");
        }
    }
}


// Note: Used the website (https://json2csharp.com/xml-to-csharp) to create the entities from the xml file.