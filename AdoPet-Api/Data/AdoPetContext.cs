﻿using AdoPet_Api.Data.Map;
using AdoPet_Api.Model;
using Microsoft.EntityFrameworkCore;

namespace AdoPet_Api.Data
{
    public class AdoPetContext: DbContext
    {
        public AdoPetContext(DbContextOptions<AdoPetContext> opts) : base(opts)
        {
            
        }

        public DbSet<Tutor> Tutores { get; set; }
        public DbSet<Shelter> Shelters { get; set; }
        public DbSet<Pet> Pets { get; set; }

        public DbSet<Adoption> Adoptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PetMap());
            modelBuilder.ApplyConfiguration(new TutorMap());
            modelBuilder.ApplyConfiguration(new ShelterMap());
            modelBuilder.ApplyConfiguration(new AdoptionMap());  
            base.OnModelCreating(modelBuilder);
        }
    }
}
