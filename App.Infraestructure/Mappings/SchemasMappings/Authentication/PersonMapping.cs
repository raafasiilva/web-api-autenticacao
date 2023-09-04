using App.Domain.Models.Entities.Schemas.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infraestructure.Mappings.SchemasMappings.Authentication
{
    public class PersonMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("pessoa");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnType("UUID")
                .HasColumnName("id").IsRequired();

            builder.Property(x => x.FirstName).HasMaxLength(64).HasColumnType("VARCHAR(64)")
                .HasColumnName("primeiro_nome").IsRequired();

            builder.Property(x => x.FirstName).HasMaxLength(64).HasColumnType("VARCHAR(64)")
                .HasColumnName("ultimo_nome").IsRequired();

            builder.Property(x => x.FirstName).HasMaxLength(32).HasColumnType("VARCHAR(32)")
                .HasColumnName("apelido").IsRequired(false);

            builder.Property(x => x.BirthDate).HasColumnType("TIMESTAMP WITH TIME ZONE")
                .HasColumnName("data_nascimento").IsRequired();

            builder.Property(x => x.CreationDate).HasColumnType("TIMESTAMP WITH TIME ZONE")
                .HasColumnName("data_criacao").IsRequired();

            builder.Property(x => x.UpdateDate).HasColumnType("TIMESTAMP WITH TIME ZONE")
                .HasColumnName("data_alteracao").IsRequired(false);
        }
    }
}
