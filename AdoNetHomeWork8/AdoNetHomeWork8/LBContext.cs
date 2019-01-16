using System.Data.Entity;

namespace AdoNetHomeWork8
{    
    public class LBContext : DbContext
    {       
        public LBContext()
            : base("name=LBContext")
        {
        }
        public DbSet<Person> Persons { get; set; } 
    }   
}