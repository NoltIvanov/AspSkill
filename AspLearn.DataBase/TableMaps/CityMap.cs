using AspLearn.Data.Entities;
using AspLearn.DataBase.MapConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspLearn.DataBase.TableMaps {
    public sealed class CityMap : EntityTypeConfiguration<City> {
        public override void Map(EntityTypeBuilder<City> entity) {
            entity.ToTable("City");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.NetUid)
                .HasColumnName("NetUID")
                .HasDefaultValueSql("newid()");

            entity.Property(e => e.Created).HasDefaultValueSql("getutcdate()");

            entity.Property(e => e.Deleted).HasDefaultValueSql("0");

            entity.Property(e => e.Name)
                .HasColumnType("varchar(50)");

            entity.Property(e => e.Description)
                .HasColumnType("varchar(200)");
        }
    }
}
