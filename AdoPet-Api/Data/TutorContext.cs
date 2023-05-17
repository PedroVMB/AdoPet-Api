using AdoPet_Api.Model;
using Microsoft.EntityFrameworkCore;

namespace AdoPet_Api.Data
{
    public class TutorContext: DbContext
    {
        public TutorContext(DbContextOptions<TutorContext> opts) : base(opts)
        {
            
        }


        public DbSet<TutorModel> Tutores { get; set; }
        public DbSet<ShelterModel> Shelters { get; set; }
    }
}
