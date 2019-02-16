using AspLearn.Data.Entities;
using AspLearn.Data.SQL.Contracts;
using AspLearn.Data.TransactionUnits.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace AspLearn.Data.TransactionUnits {
    public class TransactionUnit : ITransactionUnit, IDisposable {
        private readonly ISqlDbContext _sqliteDbContext;

        /// <summary>
        ///     ctor().
        /// </summary>
        /// <param name="sqliteContextFactory"></param>
        public TransactionUnit([FromServices] ISqlContextFactory sqliteContextFactory) {
            _sqliteDbContext = sqliteContextFactory.New();
        }

        public DbSet<TEntity> GetTable<TEntity>() where TEntity : EntityBase {
            return _sqliteDbContext.DbContext.Set<TEntity>();
        }

        public void Complete() {
            try {
                _sqliteDbContext.DbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException exc) {

                //foreach (var item in exc.Entries) {
                //    var rowVersion = item.GetDatabaseValues().GetValue<object>(TransactionUnitConstants.VERSION_COLUMN_NAME);

                //    item.Property(TransactionUnitConstants.VERSION_COLUMN_NAME).OriginalValue = rowVersion;
                //}

                _sqliteDbContext.DbContext.SaveChanges();
            }
            catch (DbUpdateException exc) {
                throw;
            }
            catch (Exception exc) {
                Debugger.Break();
            }
        }

        public void Dispose() {
            _sqliteDbContext.DbContext.Dispose();
        }
    }
}
