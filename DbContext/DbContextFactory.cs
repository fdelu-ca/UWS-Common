using Microsoft.EntityFrameworkCore;

namespace ArcelorMittal.UnifiedWeightSystem.Common.DbContext
{
    public class UwsDbContextFactory
    {
        readonly string _connectionString;
            public UwsDbContextFactory(string connectionString) => _connectionString = connectionString;
        public UwsDbContext Create()
        {
            var options = new DbContextOptionsBuilder<UwsDbContext>()
                .UseSqlServer(_connectionString).Options;
            return new UwsDbContext(options);
        }
    }
}