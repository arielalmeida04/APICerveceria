using Microsoft.EntityFrameworkCore;
using university_apibackend.Models.DataModels;
namespace university_apibackend.DataAccess
{
    public class UniversityContext: DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options):base(options) 
        { 
        
        }



        //TODO: Add DBSets (Tables of our Data Base)
        public DbSet<User>? Users { get; set; }
    }

}
