using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Staris.Domain.Entities;

namespace Staris.Infra.Data.Configurations;

public class StarshipFilmConfiguration : IEntityTypeConfiguration<StarshipFilm>
{
    public void Configure(EntityTypeBuilder<StarshipFilm> builder)
    {
        builder
          .Property(vf => vf.FilmId)
          .IsRequired();

        builder
          .Property(vf => vf.StartshipId)
          .IsRequired();

        builder
          .HasKey(vf => new { vf.FilmId, vf.StartshipId });

        builder
          .HasOne(vf => vf.Film)
          .WithMany(f => f.Starships)
          .HasForeignKey(vf => vf.FilmId);

        builder
          .HasOne(vf => vf.Startship)
          .WithMany(v => v.Films)
          .HasForeignKey(vf => vf.StartshipId);

        builder.ToTable("StarshipFilms");
    }
}
