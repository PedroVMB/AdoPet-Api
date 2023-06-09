﻿using AdoPet_Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdoPet_Api.Data.Map
{
    public class ShelterMap : IEntityTypeConfiguration<Shelter>
    {
        public void Configure(EntityTypeBuilder<Shelter> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome);
            builder.Property(x => x.Cidade);
            builder.Property(x => x.Estado);
        }
    }
}
