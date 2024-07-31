using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace ImdbClone.Persistence;
public class FilmDbContextFactory : IDesignTimeDbContextFactory<FilmDbContext>
{
    public FilmDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        
        var builder = new DbContextOptionsBuilder<FilmDbContext>();
        var connectionString = configuration.GetConnectionString("FilmConnectionString");
        
        builder.UseSqlServer(connectionString, b => b.MigrationsAssembly("ImdbClone.Persistence"));
        
        return new FilmDbContext(builder.Options);
    }
}