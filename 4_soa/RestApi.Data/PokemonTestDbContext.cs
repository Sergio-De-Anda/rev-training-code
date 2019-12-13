using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RestApi.Data.Models;

namespace RestApi.Data
{
  public class PokemonTestDbContext : DbContext
  {
    public DbSet<Pokemon> Pokemon { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder dbContext)
    {
      dbContext.UseInMemoryDatabase("pokemondb");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Pokemon>(o => o.HasKey(k => k.Id));
      builder.Entity<Pokemon>().Property(p => p.Id).UseSerialColumn().ValueGeneratedOnAdd();
        
      builder.Entity<Pokemon>().HasData(new List<Pokemon>()
      {
        new Pokemon(){ Id = 1, Name = "bulbasaur"},
        new Pokemon(){ Id = 2, Name = "ivysaur"},
        new Pokemon(){ Id = 3, Name = "venusaur"},
      });
    }
  }
}