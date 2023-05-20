using AdoPet_Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdoPet_Api.Data.Map
{
    public class PetMap : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Descricao).IsRequired();
            builder.Property(x => x.Adotado).IsRequired();
            builder.Property(x => x.Idade).IsRequired();
            builder.Property(x => x.Endereco).IsRequired();
            builder.Property(x => x.Imagem).IsRequired();

            builder.HasOne(x => x.Shelter);
        }
    }

}
