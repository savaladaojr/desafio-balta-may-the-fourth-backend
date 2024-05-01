using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Staris.Domain.Entities;


namespace Staris.Infra.Data.Configurations
{
    public class StarshipConfiguration : IEntityTypeConfiguration<Starship>    
    {
        public void Configure(EntityTypeBuilder<Starship> builder)
        {
            builder.Property(s => s.VehicleId)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(s => s.HyperdriveRating)
                .HasColumnType("real")
                .IsRequired();

            builder.Property(s => s.MaximumMegalights)
                .HasColumnType("integer")
                .IsRequired();

            builder.HasKey(s => s.VehicleId);

			builder.HasOne(p => p.Vehicle)
				.WithOne(o => o.Starship)
				.HasForeignKey<Starship>(pf => pf.VehicleId)
                .HasPrincipalKey<Vehicle>(k => k.Id)
				.HasConstraintName("fk_Vechicles_Starships");

			builder.ToTable("Starships");

		}


    }
}
