using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspLearn.DataBase.MapConfigurations {
    public abstract class EntityTypeConfiguration<TEntity> where TEntity : class {
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }
}
