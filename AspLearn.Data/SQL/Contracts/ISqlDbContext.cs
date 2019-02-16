using Microsoft.EntityFrameworkCore;

namespace AspLearn.Data.SQL.Contracts {
    public interface ISqlDbContext {
        DbContext DbContext { get; }
    }
}
