using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vini.Domain.Entities;

namespace Vini.Infra.Data.Mappings
{    
    public class HelloMap : IEntityTypeConfiguration<Hello>
    {
        public void Configure(EntityTypeBuilder<Hello> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Message)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired(); 
        }
    }
}
