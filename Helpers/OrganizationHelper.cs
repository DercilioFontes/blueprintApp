using System.IO;
using System.Xml.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Console;

namespace bpApp.Helpers
{
    public static class OrganizationHelper
    {
        public static Organization FromXml(string path)
        {
            Organization organization = null;
            XmlSerializer serializer = new(typeof(Organization));

            try
            {
                using (StreamReader reader = new(path))
                {
                    organization = (Organization)serializer.Deserialize(reader);
                }
            }
            catch (System.Exception ex)
            {
                WriteLine($"Error: {ex.Message}");
            }

            return organization;
        }

        public static void ToJson(Organization organization, string jsonPath)
        {
            try
            {
                using (FileStream createStream = File.Create(jsonPath))
                {
                    JsonSerializer.SerializeAsync(createStream, organization);
                }
            }
            catch (System.Exception ex)
            {
                WriteLine($"Error: {ex.Message}");
            }
        }

    }
}
