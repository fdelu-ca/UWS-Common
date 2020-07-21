using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ArcelorMittal.UnifiedWeightSystem.Common.DbContext
{
    public class UwsDbContextFactory
    {
        //readonly string _connectionString;
        //    public UwsDbContextFactory(string connectionString) => _connectionString = connectionString;
        //public UwsDbContext Create()
        //{
        //    var options = new DbContextOptionsBuilder<UwsDbContext>()
        //        .UseSqlServer(_connectionString).Options;
        //    return new UwsDbContext(options);
        //}

        readonly string _connectionString;
        public UwsDbContextFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("UwsConString");
        }

        public UwsDbContext Create() => new UwsDbContext(
                new DbContextOptionsBuilder<UwsDbContext>()
                .UseSqlServer(_connectionString)
                .Options);
    }
}