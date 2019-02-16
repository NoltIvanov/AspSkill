using AspLearn.Data.Entities;
using AspLearn.DataBase.MapConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspLearn.DataBase.TableMaps {
    public sealed class PointOfInterestMap : EntityTypeConfiguration<PointOfInterest> {
        public override void Map(EntityTypeBuilder<PointOfInterest> entity) {
            entity.ToTable("PointOfInterest");

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
