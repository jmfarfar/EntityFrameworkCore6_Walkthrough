// See https://aka.ms/new-console-template for more information
using EFCore_DBLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCore_Activity0201
{
    class Program
    {
        private static IConfigurationRoot? _configuration;
        private static DbContextOptionsBuilder<AdventureWorks2012Context>? _optionsBuilder;

        static void Main(string[] args)
        {
            BuildConfiguration();
            BuildOptions();
            ListPeople();

            Console.WriteLine($"CNSTR: {_configuration.GetConnectionString("AdventureWorks")}");
        }

        static void BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _configuration = builder.Build();
        }

        static void BuildOptions()
        {
            _optionsBuilder = new DbContextOptionsBuilder<AdventureWorks2012Context>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("AdventureWorks"));
        }

        static void ListPeople()
        {
            using (var db = new AdventureWorks2012Context(_optionsBuilder.Options))
            {
                var people = db.People.OrderByDescending(x => x.LastName).Take(20).ToList();

                foreach (var person in people)
                {
                    Console.WriteLine($"{person.FirstName} {person.LastName}");
                }
            }
        }
    }
}

