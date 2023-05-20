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
            builder.HasKey(x => x.Nome);
            builder.HasKey(x => x.Descricao);
            builder.HasKey(x => x.Adotado);
            builder.HasKey(x => x.Idade);
            builder.HasKey(x => x.Endereco);
            builder.HasKey(X => X.Imagem);
            builder.HasKey(x => x.ShelterId);


            builder.HasOne(x => x.Shelter);
        }
    }
}
