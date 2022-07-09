using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HoneyRyderTask.Infrastructure.PostgreSQL
{
    /// <summary>
    /// DBコンテキスト
    /// </summary>
    public class HoneyRyderTaskDbContext : DbContext
    {
        /// <summary>
        /// DB構成
        /// </summary>
        /// <param name="optionsBuilder">オプションビルダー</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<HoneyRyderTaskDbContext>()
                .Build();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
