using AdoPet_Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdoPet_Api.Data.Map
{
    public class TutorMap : IEntityTypeConfiguration<Tutor>
    {
        public void Configure(EntityTypeBuilder<Tutor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Telefone).IsRequired();
            builder.Property(x => x.Cidade).IsRequired();
            builder.Property(x => x.Descricao).IsRequired();

        }
    }
}
