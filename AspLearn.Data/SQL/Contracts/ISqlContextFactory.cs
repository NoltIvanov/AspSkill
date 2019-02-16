namespace AspLearn.Data.SQL.Contracts {
    public interface ISqlContextFactory {
        ISqlDbContext New();
    }
}
