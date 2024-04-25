using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Staris.Domain.Entities;

namespace Staris.Infra.Data.Configurations;

public class VehicleFilmConfiguration : IEntityTypeConfiguration<VehicleFilm>
{
    public void Configure(EntityTypeBuilder<VehicleFilm> builder)
    {
        builder
          .Property(vf => vf.FilmId)
          .IsRequired();

        builder
          .Property(vf => vf.VehicleId)
          .IsRequired();

        builder
          .HasKey(vf => new { vf.FilmId, vf.VehicleId });

        builder
          .HasOne(vf => vf.Film)
          .WithMany(f => f.Vehicles)
          .HasForeignKey(vf => vf.FilmId);

        builder
          .HasOne(vf => vf.Vehicle)
          .WithMany(v => v.Films)
          .HasForeignKey(vf => vf.VehicleId);

        builder.ToTable("VeichleFilms");
    }
}
