using AspLearn.Data.SQL.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AspLearn.Data.SQL {
    public class SqlDbContext : ISqlDbContext {
        public SqlDbContext(DbContext dbContext) {
            DbContext = dbContext;
        }

        public DbContext DbContext { get; }
    }
}
