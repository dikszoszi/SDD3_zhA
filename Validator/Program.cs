using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ValidatorProject.Tables;

[assembly: CLSCompliant(false)]
namespace ValidatorProject
{
    /* Tools - NuGet Package Manager - Package Manager Console => paste and run:
     * Scaffold-DbContext "Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\PersonDb.mdf; Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Tables
     */
    internal static class Program
    {
        private static void Main()
        {
            IEnumerable<Person> people = GetPersonFromXml(@"Resources\people.xml");
            PersonDbContext ctx = new PersonDbContext();
            foreach (Person person in people)
            {
                PersonTable personT = new PersonTable();
                Converter.ConvertProperties(person, personT);
                ctx.People.Add(personT);
            }
            ctx.SaveChanges();
            ctx.People.PrintToConsole("All People");
            ctx.Dispose();
        }

        private static IList<Person> GetPersonFromXml(string path)
        {
            XDocument xDoc = XDocument.Load(path);
            int id = 0;
            List<Person> persons = new List<Person>();
            foreach (XElement element in xDoc.Descendants("person"))
            {
                Person newPerson = new Person(element)
                {
                    Id = ++id,
                };
                if (Validator.Validate(newPerson, out string result))
                {
                    persons.Add(newPerson);
                }
                else
                {
                    Console.WriteLine(result);
                }
            }
            return persons;
        }
    }
}
