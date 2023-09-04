using App.Domain.Models.Entities.Schemas.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infraestructure.Mappings.SchemasMappings.Authentication
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("endereco");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnType("UUID")
                .HasColumnName("id").IsRequired();

            builder.Property(x => x.StateCode).HasMaxLength(2)
                .HasColumnType("VARCHAR(2)").HasColumnName("estado").IsRequired();

            builder.Property(x => x.City).HasMaxLength(64)
                .HasColumnType("VARCHAR(64)").HasColumnName("cidade").IsRequired();

            builder.Property(x => x.ZipCode).HasMaxLength(8)
                .HasColumnType("VARCHAR(10)").HasColumnName("cep").IsRequired();

            builder.Property(x => x.District).HasMaxLength(64)
                .HasColumnType("VARCHAR(64)").HasColumnName("bairro").IsRequired();

            builder.Property(x => x.Street).HasMaxLength(64)
                .HasColumnType("VARCHAR(128)").HasColumnName("logradouro").IsRequired();

            builder.Property(x => x.Number).HasMaxLength(8)
                .HasColumnType("VARCHAR(10)").HasColumnName("numero").IsRequired();

            builder.Property(x => x.Complement).HasMaxLength(64)
               .HasColumnType("VARCHAR(128)").HasColumnName("complemento").IsRequired(false);

            builder.Property(x => x.CreationDate).HasColumnType("TIMESTAMP WITH TIME ZONE")
                .HasColumnName("data_criacao").IsRequired();

            builder.Property(x => x.UpdateDate).HasColumnType("TIMESTAMP WITH TIME ZONE")
                .HasColumnName("data_alteracao").IsRequired(false);
        }
    }
}