using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spotify.Domain.Account.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Repository.Mapping.Account
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(nameof(Usuario));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DtNascimento).IsRequired();
            builder.HasMany(x => x.Cartoes).WithOne();
            builder.HasMany(x => x.Assinaturas).WithOne();

            builder.OwnsOne(x => x.Senha, p =>
            {
                p.Property(f => f.Valor).HasColumnName("Senha").IsRequired();
            });

            builder.OwnsOne(x => x.Email, p =>
            {
                p.Property(f => f.Valor).HasColumnName("Email").IsRequired().HasMaxLength(200);
            });

            builder.HasMany(x => x.Playlists).WithOne(x => x.Usuario)


            // builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            //builder.Property(x => x.Senha).IsRequired().HasMaxLength(100);
            
            ;
        }
    }
}
