using FoccoEmFrente.Kanban.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoccoEmFrente.Kanban.Application.Mapping
{
    public class MusicMap : IEntityTypeConfiguration<Music>
    {
        public void Configure(EntityTypeBuilder<Music> builder)
        {
            builder.ToTable("Musics");

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Tittle)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Style)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.HumorPrincipal)
               .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.HumorSecundary)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(c => c.UserId)
                .IsRequired();
        }
    
    }
}
