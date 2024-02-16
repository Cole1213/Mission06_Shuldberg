using Microsoft.EntityFrameworkCore;

namespace Mission06_Shuldberg.Models
{
    public class MovieContext : DbContext
    {
        //Constructor
        public MovieContext (DbContextOptions<MovieContext> options) : base(options) { }

        //Create the table
        public DbSet<Class> Movies { get; set; }
    }

}
