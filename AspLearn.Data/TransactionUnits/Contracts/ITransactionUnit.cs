using AspLearn.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspLearn.Data.TransactionUnits.Contracts {
    public interface ITransactionUnit {
        void Complete();

        DbSet<TEntity> GetTable<TEntity>() where TEntity : EntityBase;
    }
}
