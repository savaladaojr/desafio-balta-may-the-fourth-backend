using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Staris.Domain.Entities;


namespace Staris.Infra.Data.Configurations
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder) 
        {
            builder.Property(f => f.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(f => f.Episode)
                .HasColumnType("integer")
                .IsRequired();

            builder.Property(f => f.OpeningCrawl)
                .HasColumnType("text")
                .IsRequired();

            builder.Property(f => f.Director)
                .HasColumnType("text")
                .IsRequired();

            builder.Property(f => f.Producer)
                .HasColumnType("text")
                .IsRequired();

            builder.Property(f => f.ReleaseDate)
                .HasColumnType("real")
                .IsRequired();

            // removendo a dependencia de VeichleFilms, pois o id do starship
            // é o mesmo de vehicle
            // se remover essa linha, o ef estava criando o
            // relacionamento na tabela VehicleFilms para o starship            
            builder
                .Ignore(f => f.Starships);

            builder.HasKey(f => f.Id);

            builder.ToTable("Films");
                



        }

    }
}
