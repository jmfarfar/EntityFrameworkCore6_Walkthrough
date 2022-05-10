using Microsoft.EntityFrameworkCore;

namespace EFCore_DBLibrary
{
    public class ApplicationDbContext : DbContext
    {
        // add default constructor if scaffolding is needed
        public ApplicationDbContext()
        {

        }

        // add the complex constructor for allowing dependency injection
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }
    }
}