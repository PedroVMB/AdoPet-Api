using AdoPet_Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdoPet_Api.Data.Map
{
    public class AdoptionMap : IEntityTypeConfiguration<Adoption>
    {
        public void Configure(EntityTypeBuilder<Adoption> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PetId).IsRequired();
            builder.Property(x => x.TutorId).IsRequired();
        }
    }
}
